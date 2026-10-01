using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Sale
    {
        [Key] public int Id { get; set; }

        [Required] public DateTime SaleDate { get; set; }

        [Required, Range(1, double.MaxValue)]
        [Column(TypeName = "decimal(12,2)")]
        public decimal SalePrice { get; set; }

        [Required, MaxLength(30)] public string PaymentMethod { get; set; }

        [MaxLength(300)] public string Notes { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [ForeignKey(nameof(Vehicle))]

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
