using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApp.Models;

namespace HotelApp.Controllers.api
{
    public class OrderController : ApiController
    {
        static string connectionString = "Data Source=SHIMONSAMAY;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        HotelsDBDataContextDataContext HotelsDB = new HotelsDBDataContextDataContext(connectionString);
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(HotelsDB.Orders.ToList());
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

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(HotelsDB.Orders.First(order => order.Id == id));
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

        public IHttpActionResult Post([FromBody]Order newOrerd)
        {
            try
            {
                HotelsDB.Orders.InsertOnSubmit(newOrerd);
                HotelsDB.SubmitChanges();
                return Ok(HotelsDB.Orders.ToList());
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

        public IHttpActionResult Put(int id, [FromBody] Order update)
        {

            try
            {
                Order oredrToUpdate = HotelsDB.Orders.First(oredr => oredr.Id == id);
                oredrToUpdate.PersonId = update.PersonId;
                oredrToUpdate.OrderDate = update.OrderDate;
                oredrToUpdate.PaymentPrice = update.PaymentPrice;
                oredrToUpdate.Price = update.Price;
                oredrToUpdate.WorkerId = update.WorkerId;   
                HotelsDB.SubmitChanges();
                return Ok(HotelsDB.Orders.ToList());
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

        public IHttpActionResult Delete(int id)
        {
            try
            {
                HotelsDB.Orders.DeleteOnSubmit(HotelsDB.Orders.First(order => order.Id == id));
                HotelsDB.SubmitChanges();
                return Ok(HotelsDB.Orders.ToList());
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
    }
}
