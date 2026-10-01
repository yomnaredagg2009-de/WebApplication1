using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Sales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // No duplicate category names.
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(c => c.VIN).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.DriverLicenseNumber).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();


            // Sale Price and Vehicle Price
            modelBuilder.Entity<Vehicle>().Property(e => e.Price).HasPrecision(12, 2);
            modelBuilder.Entity<Sale>().Property(e => e.SalePrice).HasPrecision(12, 2);

            // All Relations
            modelBuilder.Entity<Category>()
                  .HasMany(c => c.vehicles)
                  .WithOne(v => v.Category)
                  .HasForeignKey(v => v.CategoryId);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Profile)
                .WithOne(p => p.Customer)
                .HasForeignKey<CustomerProfile>(p => p.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Sales)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Sale)
                .WithOne(s => s.Vehicle)
                .HasForeignKey<Sale>(s => s.VehicleId);


            modelBuilder.Entity<Category>().HasData(
                  new Category { Id = 1, Name = "Sedan", Description = "Comfortable passenger cars" },
                  new Category { Id = 2, Name = "SUV", Description = "Sport utility vehicles" },
                  new Category { Id = 3, Name = "Hatchback", Description = "Compact practical cars" }
              );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2024, Color = "White", Price = 650000, Mileage = 12000, VIN = "VIN00000000000001", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 1 },
                new Vehicle { Id = 2, Make = "Hyundai", Model = "Elantra", Year = 2023, Color = "Black", Price = 590000, Mileage = 18000, VIN = "VIN00000000000002", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 1 },
                new Vehicle { Id = 3, Make = "Kia", Model = "Sportage", Year = 2024, Color = "Gray", Price = 980000, Mileage = 9000, VIN = "VIN00000000000003", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 2 }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Mostafa Nabil", Position = "Sales Manager", Email = "mostafa.nabil@autodrive.com", Phone = "01020000001", HireDate = new DateTime(2021 - 01 - 10) });

        }


    
    }
}
