using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using WebApplication1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static VehicleRepository;

namespace WebApplication1.Dtos
{
    public class VehicleRequestDtos
    {

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int CategoryId { get; set; }

    }
}










// Custom Repository Example















//📌 Mapping(AutoMapper Profile)
//csharp
//public class MappingProfile : Profile
//    {
//        public MappingProfile()
//        {
//            CreateMap<Vehicle, VehicleReadDto>()
//                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
//            CreateMap<VehicleCreateDto, Vehicle>();

//            CreateMap<Customer, CustomerReadDto>()
//                .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
//                .ForMember(dest => dest.TotalVehiclesPurchased, opt => opt.MapFrom(src => src.Sales.Count))
//                .ForMember(dest => dest.TotalMoneySpent, opt => opt.MapFrom(src => src.Sales.Sum(s => s.SalePrice)));
//            CreateMap<CustomerCreateDto, Customer>();

//            CreateMap<CustomerProfile, CustomerProfileDto>().ReverseMap();

//            CreateMap<Employee, EmployeeReadDto>()
//                .ForMember(dest => dest.SalesCount, opt => opt.MapFrom(src => src.Sales.Count));
//            CreateMap<EmployeeCreateDto, Employee>();

//            CreateMap<Sale, SaleReadDto>()
//                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
//                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName))
//                .ForMember(dest => dest.VehicleModel, opt => opt.MapFrom(src => src.Vehicle.Model));
//            CreateMap<SaleCreateDto, Sale>();
//        }
//    }
//📌 Controllers(Endpoints)
//VehicleController
//csharp
//[ApiController]
//[Route("api/[controller]")]
//    public class VehiclesController : ControllerBase
//    {
//        private readonly IVehicleRepository _repo;
//        private readonly IMapper _mapper;

//        public VehiclesController(IVehicleRepository repo, IMapper mapper)
//        {
//            _repo = repo;
//            _mapper = mapper;
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddVehicle(VehicleCreateDto dto)
//        {
//            var vehicle = _mapper.Map<Vehicle>(dto);
//            await _repo.AddAsync(vehicle);
//            await _repo.SaveAsync();
//            return Ok(_mapper.Map<VehicleReadDto>(vehicle));
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAvailableVehicles()
//        {
//            var vehicles = await _repo.GetAvailableVehiclesAsync();
//            return Ok(_mapper.Map<IEnumerable<VehicleReadDto>>(vehicles));
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateVehicle(int id, VehicleCreateDto dto)
//        {
//            var vehicle = await _repo.GetByIdAsync(id);
//            if (vehicle == null) return NotFound();
//            _mapper.Map(dto, vehicle);
//            _repo.Update(vehicle);
//            await _repo.SaveAsync();
//            return Ok(_mapper.Map<VehicleReadDto>(vehicle));
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteVehicle(int id)
//        {
//            var vehicle = await _repo.GetByIdAsync(id);
//            if (vehicle == null || vehicle.Sale != null) return BadRequest("Vehicle already sold.");
//            _repo.Delete(vehicle);
//            await _repo.SaveAsync();
//            return NoContent();
//        }
//    }
//    CustomerController
//    csharp
//    [ApiController]
//[Route("api/[controller]")]
//    public class CustomersController : ControllerBase
//    {
//        private readonly ICustomerRepository _repo;
//        private readonly IMapper _mapper;

//        public CustomersController(ICustomerRepository repo, IMapper mapper)
//        {
//            _repo = repo;
//            _mapper = mapper;
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateCustomer(CustomerCreateDto dto)
//        {
//            var customer = _mapper.Map<Customer>(dto);
//            await _repo.AddAsync(customer);
//            await _repo.SaveAsync();
//            return Ok(_mapper.Map<CustomerReadDto>(customer));
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetCustomer(int id)
//        {
//            var customer = await _repo.GetCustomerWithHistoryAsync(id);
//            if (customer == null) return NotFound();
//            return Ok(_mapper.Map<CustomerReadDto>(customer));
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCustomer(int id)
//        {
//            var customer = await _repo.GetByIdAsync(id);
//            if (customer == null || customer.Sales.Any()) return BadRequest("Customer has sales.");
//            _repo.Delete(customer);
//            await _repo.SaveAsync();
//            return NoContent();
//        }
//    }
//    EmployeeController + SaleController
//    بنفس الشكل:

//EmployeeController → GET employees ordered by sales count.

//SaleController → POST sale (vehicle must be Available → set Sold), GET sales grouped by employee with revenue, DELETE sale → vehicle back to Available.

//🎯 الخلاصة
