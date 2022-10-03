using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClimbingInfo.Models
{
    public class ClimbingContext : DbContext
    {
        public ClimbingContext(DbContextOptions<ClimbingContext> options) : base(options) { }
        public DbSet<Members> Membership { get; set; }
        public DbSet<Experience> Experience { get; set; }

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
                    cell = "231-360-5236"
                }                
                );

            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    ID = 1,
                    years = 1,
                    freq = "2-3 days a week!",
                    MembersID = 1
                }
                );
        }
    }
}
