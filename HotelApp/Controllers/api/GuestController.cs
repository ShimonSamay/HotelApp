using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HotelApp.Models;

namespace HotelApp.Controllers.api
{
    public class GuestController : ApiController
    {
        public HotelDBContext hotedDB = new HotelDBContext();

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(hotedDB.Guests.ToList());
            }
            catch(SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        public async Task <IHttpActionResult> Get(int id)
        {
            try
            {
                return Ok(await hotedDB.Guests.FindAsync(id));
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public async Task<IHttpActionResult> Post([FromBody]Guest newGuest)
        {
            try
            {
                hotedDB.Guests.Add(newGuest);
                await hotedDB.SaveChangesAsync();
                return Ok(hotedDB.Guests.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public async Task<IHttpActionResult> Put(int id, [FromBody] Guest updated)
        {
            try
            {
                Guest guestToUpdate = await hotedDB.Guests.FindAsync(id);
                guestToUpdate.FirstName = updated.FirstName;
                guestToUpdate.LastName = updated.LastName;
                guestToUpdate.BirthDate = updated.BirthDate;    
                guestToUpdate.Gender = updated.Gender;  
                guestToUpdate.CheckInDate = updated.CheckInDate;    
                await hotedDB.SaveChangesAsync();
                return Ok(hotedDB.Guests.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                hotedDB.Guests.Remove(await hotedDB.Guests.FindAsync(id));
                await hotedDB.SaveChangesAsync();
                return Ok(hotedDB.Guests.ToList());
            }
            catch(SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
