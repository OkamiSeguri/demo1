using CodePulse.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace CodePulse.API.Data

{
    public class ApplicationDbContext : DbContext
    {
        internal readonly object UserRoles;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
        }

    }
}
