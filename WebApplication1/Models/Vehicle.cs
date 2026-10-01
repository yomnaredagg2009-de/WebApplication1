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

      

        

       

      

    
        }

public interface IGenericRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task AddAsync(T entity);
            void Update(T entity);
            void Delete(T entity);
            Task SaveAsync();
        }

        public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            private readonly ApplicationDbContext _context;
            private readonly DbSet<T> _dbSet;

            public GenericRepository(ApplicationDbContext context)
            {
                _context = context;
                _dbSet = _context.Set<T>();
            }

            public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
            public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
            public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
            public void Update(T entity) => _dbSet.Update(entity);
            public void Delete(T entity) => _dbSet.Remove(entity);
            public async Task SaveAsync() => await _context.SaveChangesAsync();
        }

        // Custom Repository Example
        public interface IVehicleRepository : IGenericRepository<Vehicle>
        {
            Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync();
        }

        public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
        {
            private readonly ApplicationDbContext _context;
            public VehicleRepository(ApplicationDbContext context) : base(context) => _context = context;

            public async Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync()
            {
                return await _context.Vehicles
                    .Where(v => v.Status == "Available")
                    .OrderByDescending(v => v.Year)
                    .Then
        













📌 DTOs(Data Transfer Objects)
        csharp
        // Vehicle DTOs
public class VehicleCreateDto
            {
                public string Make { get; set; }
                public string Model { get; set; }
                public int Year { get; set; }
                public decimal Price { get; set; }
                public int Mileage { get; set; }
                public string VIN { get; set; }
                public int CategoryId { get; set; }
            }

            public class VehicleReadDto
            {
                public int Id { get; set; }
                public string Make { get; set; }
                public string Model { get; set; }
                public int Year { get; set; }
                public decimal Price { get; set; }
                public string Status { get; set; }
                public string CategoryName { get; set; }
            }

            // Customer DTOs
            public class CustomerCreateDto
            {
                public string FullName { get; set; }
                public string Email { get; set; }
                public string Phone { get; set; }
                public string DriverLicenseNumber { get; set; }
                public CustomerProfileDto Profile { get; set; }
            }

            public class CustomerProfileDto
            {
                public string Address { get; set; }
                public string City { get; set; }
                public string Nationality { get; set; }
                public DateTime? DateOfBirth { get; set; }
            }

            public class CustomerReadDto
            {
                public int Id { get; set; }
                public string FullName { get; set; }
                public string Email { get; set; }
                public CustomerProfileDto Profile { get; set; }
                public int TotalVehiclesPurchased { get; set; }
                public decimal TotalMoneySpent { get; set; }
            }

            // Employee DTOs
            public class EmployeeCreateDto
            {
                public string FullName { get; set; }
                public string Position { get; set; }
                public string Email { get; set; }
                public DateTime HireDate { get; set; }
            }

            public class EmployeeReadDto
            {
                public int Id { get; set; }
                public string FullName { get; set; }
                public string Position { get; set; }
                public int SalesCount { get; set; }
            }

            // Sale DTOs
            public class SaleCreateDto
            {
                public int CustomerId { get; set; }
                public int EmployeeId { get; set; }
                public int VehicleId { get; set; }
                public decimal SalePrice { get; set; }
                public string PaymentMethod { get; set; }
                public string Notes { get; set; }
            }

            public class SaleReadDto
            {
                public int Id { get; set; }
                public DateTime SaleDate { get; set; }
                public decimal SalePrice { get; set; }
                public string PaymentMethod { get; set; }
                public string CustomerName { get; set; }
                public string EmployeeName { get; set; }
                public string VehicleModel { get; set; }
            }
📌 Mapping(AutoMapper Profile)
        csharp
        public class MappingProfile : Profile
            {
                public MappingProfile()
                {
                    CreateMap<Vehicle, VehicleReadDto>()
                        .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
                    CreateMap<VehicleCreateDto, Vehicle>();

                    CreateMap<Customer, CustomerReadDto>()
                        .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
                        .ForMember(dest => dest.TotalVehiclesPurchased, opt => opt.MapFrom(src => src.Sales.Count))
                        .ForMember(dest => dest.TotalMoneySpent, opt => opt.MapFrom(src => src.Sales.Sum(s => s.SalePrice)));
                    CreateMap<CustomerCreateDto, Customer>();

                    CreateMap<CustomerProfile, CustomerProfileDto>().ReverseMap();

                    CreateMap<Employee, EmployeeReadDto>()
                        .ForMember(dest => dest.SalesCount, opt => opt.MapFrom(src => src.Sales.Count));
                    CreateMap<EmployeeCreateDto, Employee>();

                    CreateMap<Sale, SaleReadDto>()
                        .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                        .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName))
                        .ForMember(dest => dest.VehicleModel, opt => opt.MapFrom(src => src.Vehicle.Model));
                    CreateMap<SaleCreateDto, Sale>();
                }
            }
📌 Controllers(Endpoints)
        VehicleController
        csharp
        [ApiController]
        [Route("api/[controller]")]
            public class VehiclesController : ControllerBase
            {
                private readonly IVehicleRepository _repo;
                private readonly IMapper _mapper;

                public VehiclesController(IVehicleRepository repo, IMapper mapper)
                {
                    _repo = repo;
                    _mapper = mapper;
                }

                [HttpPost]
                public async Task<IActionResult> AddVehicle(VehicleCreateDto dto)
                {
                    var vehicle = _mapper.Map<Vehicle>(dto);
                    await _repo.AddAsync(vehicle);
                    await _repo.SaveAsync();
                    return Ok(_mapper.Map<VehicleReadDto>(vehicle));
                }

                [HttpGet]
                public async Task<IActionResult> GetAvailableVehicles()
                {
                    var vehicles = await _repo.GetAvailableVehiclesAsync();
                    return Ok(_mapper.Map<IEnumerable<VehicleReadDto>>(vehicles));
                }

                [HttpPut("{id}")]
                public async Task<IActionResult> UpdateVehicle(int id, VehicleCreateDto dto)
                {
                    var vehicle = await _repo.GetByIdAsync(id);
                    if (vehicle == null) return NotFound();
                    _mapper.Map(dto, vehicle);
                    _repo.Update(vehicle);
                    await _repo.SaveAsync();
                    return Ok(_mapper.Map<VehicleReadDto>(vehicle));
                }

                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteVehicle(int id)
                {
                    var vehicle = await _repo.GetByIdAsync(id);
                    if (vehicle == null || vehicle.Sale != null) return BadRequest("Vehicle already sold.");
                    _repo.Delete(vehicle);
                    await _repo.SaveAsync();
                    return NoContent();
                }
            }
            CustomerController
            csharp
            [ApiController]
        [Route("api/[controller]")]
            public class CustomersController : ControllerBase
            {
                private readonly ICustomerRepository _repo;
                private readonly IMapper _mapper;

                public CustomersController(ICustomerRepository repo, IMapper mapper)
                {
                    _repo = repo;
                    _mapper = mapper;
                }

                [HttpPost]
                public async Task<IActionResult> CreateCustomer(CustomerCreateDto dto)
                {
                    var customer = _mapper.Map<Customer>(dto);
                    await _repo.AddAsync(customer);
                    await _repo.SaveAsync();
                    return Ok(_mapper.Map<CustomerReadDto>(customer));
                }

                [HttpGet("{id}")]
                public async Task<IActionResult> GetCustomer(int id)
                {
                    var customer = await _repo.GetCustomerWithHistoryAsync(id);
                    if (customer == null) return NotFound();
                    return Ok(_mapper.Map<CustomerReadDto>(customer));
                }

                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteCustomer(int id)
                {
                    var customer = await _repo.GetByIdAsync(id);
                    if (customer == null || customer.Sales.Any()) return BadRequest("Customer has sales.");
                    _repo.Delete(customer);
                    await _repo.SaveAsync();
                    return NoContent();
                }
            }
            EmployeeController + SaleController
            بنفس الشكل:

EmployeeController → GET employees ordered by sales count.

SaleController → POST sale (vehicle must be Available → set Sold), GET sales grouped by employee with revenue, DELETE sale → vehicle back to Available.

🎯 الخلاصة
            }
}
