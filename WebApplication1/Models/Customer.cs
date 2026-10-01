using System.ComponentModel.DataAnnotations;
using static WebApplication1.Models.Vehicle;

namespace WebApplication1.Models
{
    public class Customer
    {
        [Key] public int Id { get; set; }

        [Required, MaxLength(150)] public string FullName { get; set; }

        [Required, EmailAddress, MaxLength(150)] public string Email { get; set; }

        [Required, MaxLength(20)] public string Phone { get; set; }

        [Required, MaxLength(30)] public string DriverLicenseNumber { get; set; }

        public CustomerProfile Profile { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
