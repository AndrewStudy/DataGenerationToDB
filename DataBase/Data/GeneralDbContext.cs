using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Data
{
    public class GeneralDbContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        //public GeneralDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DataGenerateTestDb;Trusted_Connection=True;");
        }
    }
}
