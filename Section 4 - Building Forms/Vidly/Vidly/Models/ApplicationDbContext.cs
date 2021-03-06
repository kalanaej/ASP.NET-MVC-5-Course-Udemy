using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        // Section 3
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        // Section 4
        public DbSet<MembershipType> MembershipType { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}