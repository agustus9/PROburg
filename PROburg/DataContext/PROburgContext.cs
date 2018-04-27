using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PROburg.Models;
using System.Data.Entity;

namespace PROburg.DataContext
{
    public class PROburgContext: DbContext
    {
        public PROburgContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<City> Citys { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
    }
}