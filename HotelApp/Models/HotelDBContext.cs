using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HotelApp.Models
{
    public partial class HotelDBContext : DbContext
    {
        public HotelDBContext()
            : base("name=HotelDBContext")
        {
        }
        public virtual DbSet<Guest> Guests { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
