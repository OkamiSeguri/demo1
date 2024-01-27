using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodePulse.API.Migrations.Auth
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cd46348-5215-4a88-b369-e5e41d394ada", "1cd46348-5215-4a88-b369-e5e41d394ada", "Writer", "WRITER" },
                    { "1ff61a50-8315-49f9-917e-fb19c5bc12f1", "1ff61a50-8315-49f9-917e-fb19c5bc12f1", "Reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3fcefa35-66d7-41b7-8b6b-c72390edd09c", 0, "f4ce8fbf-1b63-4b82-aa11-b9fc556fb025", "admin@codepulse.com", false, false, null, "ADMIN@CODEPULSE.COM", "ADMIN@CODEPULSE.COM", "AQAAAAIAAYagAAAAEN7AyLO9z0D6TUDjVuVmZLLhmVchLhVHDrmvyOMZ0wbD0JiMyPSnTxWETO2iiStGDQ==", null, false, "35caeba8-80f6-436e-a105-abf85d95ae34", false, "admin@codepulse.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1cd46348-5215-4a88-b369-e5e41d394ada", "3fcefa35-66d7-41b7-8b6b-c72390edd09c" },
                    { "1ff61a50-8315-49f9-917e-fb19c5bc12f1", "3fcefa35-66d7-41b7-8b6b-c72390edd09c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1cd46348-5215-4a88-b369-e5e41d394ada", "3fcefa35-66d7-41b7-8b6b-c72390edd09c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ff61a50-8315-49f9-917e-fb19c5bc12f1", "3fcefa35-66d7-41b7-8b6b-c72390edd09c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cd46348-5215-4a88-b369-e5e41d394ada");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff61a50-8315-49f9-917e-fb19c5bc12f1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fcefa35-66d7-41b7-8b6b-c72390edd09c");
        }
    }
}
