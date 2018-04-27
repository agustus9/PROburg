using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROburg.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public ICollection<Events> Event { get; set; } = new HashSet<Events>();
    }
}