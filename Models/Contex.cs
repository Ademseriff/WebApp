using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class Contex:DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=localhost;database=WebApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
        }

        public DbSet<Admin> admins { get; set; }

    }
}
