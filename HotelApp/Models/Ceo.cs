using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApp.Models
{
    public class Ceo
    {
        public int Id;
        public string FullName;
        public int Age;
        public string Email;
        public int Wage;

        public Ceo (int _id , string _fullname , int _age , string _email , int _wage)
        {
            this.Id = _id;
            this.FullName = _fullname;
            this.Age = _age;
            this.Email = _email;
            this.Wage = _wage;
        }

        public Ceo () { }
    }
}