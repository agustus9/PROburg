namespace PROburg.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PROburg.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PROburg.DataContext.PROburgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PROburg.DataContext.PROburgContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var events = new List<Events>
            {
                new Events
                {
                Title = "MeetUp",
                Tagline = "Tech is making its presence known in every aspect of our lives.",
                LongDescription = "This is a very exciting meetup for me because I have been wanted to play with voice recognition and audio for a long time.",
                Address = "4300 West Cypress Street #900 · Tampa, FL",
                City = "Tampa",
                State = "Florida",
                Zip = 33610,
                AgeLimit = 18,
                Price = 10.00,
                DateHappening = new DateTime(2018, 11, 12)
                },
                new Events
                {
                    Title = "Water Slide",
                    Tagline = "Come join us the the worlds biggest water slide",
                    LongDescription = "Bring family and friends for an exciting time.",
                    Address = "1300 East Branch St.",
                    City = "Tampa",
                    State = "Florida",
                    Zip = 33619,
                    AgeLimit = 10,
                    Price = 15.00,
                    DateHappening = new DateTime(2018, 12, 12)
                },
            new Events
            {
                Title = "Bowling",
                Tagline = "Family bowling night for all to enjoy",
                LongDescription = "Must be accompanied by an adult",
                Address = "300 East South St.",
                City = "Tampa",
                State = "Florida",
                Zip = 33609,
                AgeLimit = 10,
                Price = 0.00,                                                                               
                DateHappening = new DateTime(2018, 12, 3)
            },
            new Events
            {
                Title = "River Ralpting",
                Tagline = "Enjoy a day on the hillsborough river",
                LongDescription = "Ralfts will be given one per family",
                Address = "100 Hillsborough Ave.",
                City = "Tampa",
                State = "Florida",
                Zip = 33619,
                AgeLimit = 7,
                Price = 5.00,
                DateHappening = new DateTime(2018, 07, 10)
            } };

            var cities = new List<City>
            {
                new City {Name = "Rosebury"},
                new City {Name = "Tyrace"},
                new City {Name = "Bonita"},
                new City {Name = "Larson"}
            };

            var attendees = new List<Attendee>()
            {
                new Attendee(){ Email = "claud@gmail.com" },
                new Attendee(){ Email = "jake@gmail.com" },
                new Attendee(){ Email = "mike@gmail.com" },
                new Attendee(){ Email = "tom@gmail.com" },
            };

            events.ForEach(e =>
            {
                foreach (var person in attendees)
                {
                    e.Attendees.Add(person);
                }
                    db.Events.AddOrUpdate(t => t.Title, e);
            });

            cities.ForEach(c =>
            {
                db.Citys.AddOrUpdate(n => n.Name);
            });

            attendees.ForEach(a =>
            {
                db.Attendees.AddOrUpdate(e => e.Email);
            });
            
            db.SaveChanges();

        }
    }
}
