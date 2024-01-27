namespace CodePulse.API.Models.DTO
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateOnly DOB { get; set; }
        public string Status { get; set; } = "Pending"; // Default to Pending
    }
}
