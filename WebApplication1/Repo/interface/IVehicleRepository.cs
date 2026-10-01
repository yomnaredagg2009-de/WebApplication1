using WebApplication1.Models;

namespace WebApplication1.Repo
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
       ICollection<Vehicle> GetAvailableVehicles();
    }

}
