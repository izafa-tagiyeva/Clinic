using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinic.Models;

namespace Clinic.DataAccessLayer
{
    public class ClininCDbContext : DbContext
    {

       public  DbSet<Department> Departments;
       public  DbSet<Doctors> Doctors;

        public ClininCDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClininCDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
