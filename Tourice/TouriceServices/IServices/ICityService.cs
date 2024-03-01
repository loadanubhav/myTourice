using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouriceDatabases.Modals;

namespace TouriceServices.IServices
{
    public interface ICityService
    {
        Task<List<tblCity>> getCityList();
    }
}
