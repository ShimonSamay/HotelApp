using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApp.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string CheckInDate { get; set; }

        public Guest (int _id , string _firstname , string _lastname , string _gender , string _birthdate , string _checkInDate)
        {
            this.Id = _id;
            this.FirstName = _firstname;
            this.LastName = _lastname;
            this.Gender = _gender;
            this.BirthDate = _birthdate;
            this.CheckInDate = _checkInDate;    
        }

        public Guest () { }
    }
}