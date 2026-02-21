namespace back_point.DTO
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Code { get; set; }
        public List<PointResponseDTO> Points { get; set; } = new();
    }

    public class PointResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime DateHour { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Code { get; set; }
    }
}
