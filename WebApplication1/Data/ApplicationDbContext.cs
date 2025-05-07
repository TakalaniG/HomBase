using HomBaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomBaseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    :   base(options) { }

        public DbSet<HomBaseAPI.Model.Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}


//public DbSet<HomBaseAPI.Model.Property> Properties { get; set; }