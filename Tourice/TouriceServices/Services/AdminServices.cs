using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouriceDatabases;
using TouriceDatabases.Modals;
using TouriceServices.IServices;

namespace TouriceServices.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly TouriceDatabaseContext _context;
        private IMapper _mapper;

        public AdminServices(TouriceDatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<tblBusDriver>> GetBusDriver(){
            try
            {
                List<tblBusDriver> driverList = _context.Set<tblBusDriver>().ToList();
                return driverList;
            }catch(Exception ex)
            {
                throw;
            }

        }
        public async Task<string> AddDriver(tblBusDriver driver)
        {
            try
            {
                await _context.AddAsync<tblBusDriver>(driver);
                await _context.SaveChangesAsync();
                return "Driver Added Successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> RemoveDriver(int driverID)
        {
            try
            {
              tblBusDriver driverDetail =   await _context.BusDrivers.FindAsync(driverID);
                 _context.Remove(driverDetail);
                await _context.SaveChangesAsync();
                return "Bus Driver Removed";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
