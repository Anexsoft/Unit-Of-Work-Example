using Microsoft.EntityFrameworkCore;
using Model;

namespace UnitOfWorkPersistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=UnitOfWorkExampleDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<UserExample> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
