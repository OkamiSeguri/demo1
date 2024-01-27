using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CodePulse.API.Models.Domain
{
    // Models/User.cs
    public class User : IdentityUser<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime? DOB { get; set; }
        public string Status { get; set; } = "Active";

    }
}
