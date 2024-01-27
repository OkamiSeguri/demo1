using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CodePulse.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "1ff61a50-8315-49f9-917e-fb19c5bc12f1";
            var writerRoleId = "1cd46348-5215-4a88-b369-e5e41d394ada";


            // Create Reader and Writer Role
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole()
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = writerRoleId
                }
            };

            // Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            //Create an Admin user
            var adminUserId = "3fcefa35-66d7-41b7-8b6b-c72390edd09c";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@codepulse.com",
                Email = "admin@codepulse.com",
                NormalizedEmail = "admin@codepulse.com".ToUpper(),
                NormalizedUserName = "admin@codepulse.com".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);

            // Give Role To Admin

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

            // Create a Regular User
            var regularUserId = "2e78cfb7-33d2-4d41-9d4a-02a68a23643b";
            var regularUser = new IdentityUser()
            {
                Id = regularUserId,
                UserName = "user@codepulse.com",
                Email = "user@codepulse.com",
                NormalizedEmail = "user@codepulse.com".ToUpper(),
                NormalizedUserName = "user@codepulse.com".ToUpper()
            };

            regularUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(regularUser, "User@123");

            builder.Entity<IdentityUser>().HasData(regularUser);

            // Give Role To Regular User (e.g., Reader role)
            var regularUserRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    UserId = regularUserId,
                    RoleId = readerRoleId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(regularUserRoles);

        }
    }
}
