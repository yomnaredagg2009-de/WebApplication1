using System.ComponentModel.DataAnnotations;
using static WebApplication1.Models.Vehicle;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key] public int Id { get; set; }

        [Required, MaxLength(150)] public string FullName { get; set; }

        [Required, MaxLength(100)] public string Position { get; set; }

        [Required, EmailAddress, MaxLength(150)] public string Email { get; set; }

        [MaxLength(20)] public string Phone { get; set; }

        [Required] public DateTime HireDate { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
