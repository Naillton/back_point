namespace back_point.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Enterprise
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        public string EnterprisePassword { get; set; }

        public string Cnpj { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}