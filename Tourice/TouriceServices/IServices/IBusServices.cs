using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouriceDatabases.MapperClass;

namespace TouriceServices.IServices
{
    public interface IBusServices
    {
         Task<List<Bus>> GetAllBus();
         Task<Bus> GetBusFromBusId(int id);
         Task<string> AddBus(Bus busDetails);
         Task<string> RemoveBus(int id);
        Task<List<Bus>> GetBusForDestination(string from, string to);
    }
}
