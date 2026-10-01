using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repo.Implemntation
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        private readonly AppDBContext _context;
        public VehicleRepository(AppDBContext context) : base(context) => _context = context;

        public ICollection<Vehicle> GetAvailableVehicles()
        {
            return _context.Vehicles
                .Where(v => v.Status == "Available")
                .OrderByDescending(v => v.Year)
                .ThenBy(e => e.Price).ToList();
        }
    }
    
}
