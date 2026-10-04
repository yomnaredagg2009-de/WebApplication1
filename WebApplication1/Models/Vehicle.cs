using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static WebApplication1.Models.Vehicle;
using static WebApplication1.Models.Vehicle.VehicleRepository;

namespace WebApplication1.Models
{
    public class Vehicle
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(100)] public string Make { get; set; }
        [Required, MaxLength(100)] public string Model { get; set; }
        [Required] public int Year { get; set; }
        [MaxLength(50)] public string Color { get; set; }

        [Required, Range(1, double.MaxValue)]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }

        [Required, Range(0, int.MaxValue)] public int Mileage { get; set; }

        [Required, MaxLength(17)] public string VIN { get; set; }

        [MaxLength(30)] public string FuelType { get; set; }

        [MaxLength(30)] public string Transmission { get; set; }

        [Required] public string Status { get; set; } = "Available";


        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Sale Sale { get; set; }

    }

      


