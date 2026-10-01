using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CustomerProfile
    {
        [Key] public int Id { get; set; }

        [Required, MaxLength(250)] public string Address { get; set; }

        [MaxLength(100)] public string City { get; set; }

        [MaxLength(50)] public string Nationality { get; set; }

        public DateTime? DateOfBirth { get; set; }


        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
