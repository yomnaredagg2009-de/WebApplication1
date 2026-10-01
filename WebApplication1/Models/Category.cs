using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key] public int Id { get; set; }
        [Required , MaxLength(100)] public string Name { get; set; }
        [MaxLength(200)] public string ?Description { get;set; }

        public ICollection<Vehicle> vehicles { get; set; }
        
    }
}
