using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouriceDatabases.Modals;

namespace TouriceServices.IServices
{
    public interface IUserServices
    {
        string Login(tblUser user);
        Task<string> SignUpUser(tblUser user);
    }
}
