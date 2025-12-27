namespace back_point.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Point
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime DateHour { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}