using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClimbingInfo.Models;

namespace ClimbingInfo.Models
{
    public class ClimbingContext : DbContext
    {
        public ClimbingContext(DbContextOptions<ClimbingContext> options) : base(options) { }
        public DbSet<Members> Membership { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Gear> Gear { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {





            modelBuilder.Entity<Members>().HasData(
                new Members
                {
                    ID = 1,
                    name = "Greg",
                    gender = "male",
                    address = "555 madeup Street",
                    city = "Traverse City",
                    state = "MI",
                    zip = "49684",
                    email = "greengregsandham@gmail.com",
                    cell = "231-360-5236",
                    ExperienceId = 1,
                    GearId = 1,
                },
                 new Members
                 {
                     ID = 2,
                     name = "Bob",
                     gender = "male",
                     address = "555 madeup Street",
                     city = "Traverse City",
                     state = "MI",
                     zip = "49684",
                     email = "Bobbytown@bob.com",
                     cell = "231-360-5236",
                     ExperienceId = 2,
                     GearId = 2,
                 }, 
                 new Members
                 {
                     ID = 3,
                     name = "Mitch",
                     gender = "wizard",
                     address = "555 madeup Street",
                     city = "Traverse City",
                     state = "MI",
                     zip = "49684",
                     email = "dontditchmitch@gmail.com",
                     cell = "231-360-5236",
                     ExperienceId = 1,
                     GearId = 3,
                 }, 
                 new Members
                 {
                     ID = 4,
                     name = "Utrid",
                     gender = "female",
                     address = "555 madeup Street",
                     city = "Traverse City",
                     state = "MI",
                     zip = "49684",
                     email = "Utridisavalidname@gmail.com",
                     cell = "231-360-5236",
                     ExperienceId = 3,
                     GearId = 5,
                 }, 
                 new Members
                 {
                     ID = 5,
                     name = "Jamalle",
                     gender = "undisclosed",
                     address = "555 madeup Street",
                     city = "Traverse City",
                     state = "MI",
                     zip = "49684",
                     email = "JamwithJamalle@gmail.com",
                     cell = "231-360-5236",
                     ExperienceId = 2,
                     GearId = 1,
                 }, 
                 new Members
                 {
                     ID = 6,
                     name = "Gregggggg",
                     gender = "male",
                     address = "555 madeup Street",
                     city = "Traverse City",
                     state = "MI",
                     zip = "49684",
                     email = "greengregggggsandham@gmail.com",
                     cell = "231-360-5236",
                     ExperienceId = 1,
                     GearId = 1,
                 }, 
                 new Members
                 {
                     ID = 7,
                     name = "Lucy",
                     gender = "female",
                     address = "555 madeup Street",
                     city = "Traverse City",
                     state = "MI",
                     zip = "49684",
                     email = "Lucy2022@gmail.com",
                     cell = "231-360-5236",
                     ExperienceId = 1,
                     GearId = 1,
                 }, 
                 new Members
                 {
                     ID = 8,
                     name = "Craig",
                     gender = "male",
                     address = "555 madeup Street",
                     city = "Traverse City",
                     state = "MI",
                     zip = "49684",
                     email = "Craigisloud@gmail.com",
                     cell = "231-360-5236",
                     ExperienceId = 4,
                     GearId = 3,
                 }
                );

            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    ExperienceId = 1,
                    ExperienceName = "Gregs exp",
                    years = 1,
                    freq = "2-3 days a week!",
                },
                new Experience
                {
                    ExperienceId = 2,
                    ExperienceName = "More exp",
                    years = 5,
                    freq = "twice a week.",
                },
                new Experience
                {
                    ExperienceId = 3,
                    ExperienceName = "Others sxp",
                    years = 1,
                    freq = "7 days a week!",
                },
                new Experience
                {
                    ExperienceId = 4,
                    ExperienceName = "Mine exp",
                    years = 20,
                    freq = "1 day a month.",
                }

                );

            modelBuilder.Entity<Gear>().HasData(
               new Gear
               {
                   GearId = 1,
                   SetupName = "Fun setup",
                   Shoes = "Scarpa Helix",
                   Harness = "Black Diamond Momentum",
                   Chalk_Bag = "Custom",
               },
               new Gear
               {
                   GearId = 2,
                   SetupName = "Mitch",
                   Shoes = "La Sportiva Tarantulace",
                   Harness = "Mammut Ophir",
                   Chalk_Bag = "Cotopaxi",
               },
               new Gear
               {
                   GearId = 3,
                   SetupName = "Berrygood",
                   Shoes = "evolv Shaman",
                   Harness = "petzl Corax",
                   Chalk_Bag = "Kavu Peak Seeker",
               },
               new Gear
               {
                   GearId = 4,
                   SetupName = "aggressive set",
                   Shoes = "Black Diamond Momentum",
                   Harness = "Wild Country Session",
                   Chalk_Bag = "Static Waxed",
               },
               new Gear
               {
                   GearId = 5,
                   SetupName = "Medium setup",
                   Shoes = "Butora Gomi",
                   Harness = "Arc'teryx Konseal",
                   Chalk_Bag = "8BPLUS Lilly",
               }
               );
        }

       
    }
}
