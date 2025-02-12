namespace HomBaseAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using HomBaseAPI.Model;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<HomBaseAPI.Model.Property> Properties { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
