using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(
        b =>
        {
            b.HasKey("Id");
            b.Property(e => e.FirstName);
            b.Property(e => e.LastName);
            b.Property(e => e.Address);
            //b.Property(e => e.Phone);
            //b.Property(e => e.Salary);
        });
        }
    }
}
