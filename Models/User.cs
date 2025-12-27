namespace back_point.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Role { get; set; }

        [ForeignKey("EnterpriseId")]
        public Guid EnterpriseId { get; set; }
        public Enterprise? Enterprise { get; set; }

        public ICollection<Point> Points { get; set; } = new List<Point>();
    }
}