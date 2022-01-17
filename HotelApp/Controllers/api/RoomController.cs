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
    public class RoomController : ApiController
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False";
        
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(getAllRooms(stringConnection));
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
                return Ok(getRoom(stringConnection, id));
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

        
        public IHttpActionResult Post([FromBody]Room newRoom)
        {
            try
            {
                addRoom(stringConnection, newRoom);
                return Ok(getAllRooms(stringConnection));
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

        
        public IHttpActionResult Put(int id, [FromBody] Room updateRoom)
        {
            try
            {
                updatSomeRoom(stringConnection, updateRoom, id);
                return Ok(getAllRooms(stringConnection));
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
                deleteRoom(stringConnection, id);
                return Ok(getAllRooms(stringConnection));
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







        private List<Room> getAllRooms (string connection)
        {
            List<Room> roomsList =  new List<Room>();   
            using (SqlConnection DBConnection = new SqlConnection(connection))
            {
                DBConnection.Open();
                string query = "SELECT * FROM Rooms";
                SqlCommand commad = new SqlCommand(query, DBConnection);
                SqlDataReader Data = commad.ExecuteReader();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        roomsList.Add(new Room(Data.GetInt32(0), Data.GetInt32(1), Data.GetString(2), Data.GetBoolean(3), Data.GetInt32(4)));
                    }
                    DBConnection.Close();
                    return roomsList;
                }
                   return roomsList;
            }
        }

        private Room getRoom (string connection , int id)
        {
            Room room = new Room();
            using(SqlConnection DBConnection = new SqlConnection( connection))
            {
                DBConnection.Open();
                string query = $@"SELECT * FROM Rooms WHERE Id = {id}";
                SqlCommand sqlCommand = new SqlCommand(query, DBConnection);
                SqlDataReader Data = sqlCommand.ExecuteReader();    
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        room = new Room(Data.GetInt32(0), Data.GetInt32(1), Data.GetString(2), Data.GetBoolean(3), Data.GetInt32(4));
                    }
                    DBConnection.Close();
                    return room;
                }
                return room;
            }
        }

        private void addRoom (string connection , Room newRoom)
        {
            using(SqlConnection DBConnection = new SqlConnection(connection))
            {
                DBConnection.Open();
                string query = $@"INSERT INTO Rooms (RoomNumber , RoomType , IsAvalible , Price)
                                  VALUES ({newRoom.RoomNumber} , '{newRoom.RoomType}' , '{newRoom.IsAvalible}' , {newRoom.Price})";
                SqlCommand Command = new SqlCommand( query, DBConnection);
                Command.ExecuteNonQuery();
                DBConnection.Close();
            }
        }

        private void updatSomeRoom (string connection, Room updateRoom , int id)
        {
            using (SqlConnection DBConnection = new SqlConnection(connection))
            {
                DBConnection.Open();
                string query = $@"UPDATE Rooms 
                               SET RoomNumber = {updateRoom.RoomNumber} , 
                               RoomType = '{updateRoom.RoomType}' ,
                               IsAvalible = '{updateRoom.IsAvalible}' , 
                               Price = {updateRoom.Price}
                               WHERE Id = {id}";   
                SqlCommand Command = new SqlCommand( query,DBConnection);
                Command.ExecuteNonQuery ();
                DBConnection.Close();
            }
        }

        private void deleteRoom (string connection , int id)
        {
            using (SqlConnection DBConnection = new SqlConnection(connection))
            {
                DBConnection.Open ();
                string query = $@"DELETE FROM Rooms WHERE Id = {id}";
                SqlCommand command = new SqlCommand( query, DBConnection);
                command.ExecuteNonQuery ();
                DBConnection.Close();
            }
        }
    }
}
