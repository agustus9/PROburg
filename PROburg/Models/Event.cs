using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROburg.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string LongDescription { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int AgeLimit { get; set; }
        public double Price { get; set; }
        public DateTime DateHappening { get; set; }

        public int? CityId { get; set; }
        public City Citys { get; set; }

        public ICollection<Attendee> Attendees { get; set; } = new HashSet<Attendee>();
    }
}