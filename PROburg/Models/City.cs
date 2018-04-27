using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace PROburg.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Events> Events { get; set; } = new HashSet<Events>();
    }
}