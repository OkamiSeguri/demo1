namespace CodePulse.API.Models.DTO
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateOnly DOB { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
