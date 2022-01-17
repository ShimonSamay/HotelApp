using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApp.Models
{
    public class Room
    {
        public int Id;
        public int RoomNumber;
        public string RoomType ;
        public bool IsAvalible;
        public int Price;

        public Room (int _id , int _roomNumber , string _roomTtpe , bool _isAvalible , int _price )
        {
            this.Id = _id;
            this.RoomNumber = _roomNumber;
            this.RoomType = _roomTtpe;
            this.IsAvalible = _isAvalible;
            this.Price = _price;
        }

        public Room() { }
    }
}