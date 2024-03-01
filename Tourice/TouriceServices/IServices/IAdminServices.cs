using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouriceDatabases.Modals;

namespace TouriceServices.IServices
{
    public  interface IAdminServices
    {
        Task<List<tblBusDriver>> GetBusDriver();
        Task<string> AddDriver(tblBusDriver driver);
        Task<string> RemoveDriver(int driverID);
    }
}
