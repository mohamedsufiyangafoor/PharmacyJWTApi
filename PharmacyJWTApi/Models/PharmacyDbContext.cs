using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PharmacyJWTApi.Models
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

        }
        public DbSet<UserDetail> UserDetails { get; set; }
       

    }
}
