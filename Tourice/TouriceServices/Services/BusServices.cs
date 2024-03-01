using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouriceDatabases;
using TouriceDatabases.MapperClass;
using TouriceDatabases.Modals;
using TouriceServices.IServices;

namespace TouriceServices.Services
{
    public class BusServices :IBusServices
    {
        private readonly TouriceDatabaseContext _context;
        private IMapper _mapper;
        public BusServices(TouriceDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Bus>> GetAllBus()
        {
            List<Bus> busList = new List<Bus>();
            try
            {
                List<tblbus> buses =_context.Set<tblbus>().ToList();
                busList = _mapper.Map<List<Bus>>(buses);
            }
            catch (Exception)
            {
                throw;
            }
            return busList;
        }

        public async Task<Bus> GetBusFromBusId(int id)
        {
            Bus specificBus = new Bus();
            try
            {
                tblbus busDetail = _context.Buses.Find(id);// Buss Mapper;
                specificBus = _mapper.Map<Bus>(busDetail);
            }
            catch (Exception)
            {
                 throw;
            }
            return specificBus;
        }

        public async Task<string> AddBus(Bus busDetails)
        {
            try
            {
              await  _context.AddAsync<tblbus>(_mapper.Map<tblbus>(busDetails));
                await _context.SaveChangesAsync();
                return "Bus Added";
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<string> RemoveBus(int id)
        {
            try
            {
                var bus =await _context.Buses.FindAsync(id);
                 _context.Remove(bus);
               await _context.SaveChangesAsync();
                return "Buss Removed";
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<Bus>> GetBusForDestination(string from , string to)
        {
            try
            {
                List<tblbus> searchResult = new List<tblbus>();
                if(from=="all" || to == "all")
                {
                 searchResult = _context.Buses.ToList();
                }
                else
                {
                 searchResult = _context.Buses.Where(x=>  x.ToCity.ToLower() == to.ToLower() && ( x.FromCity.ToLower()==from.ToLower() || x.ViaCities.ToLower() ==from.ToLower())  ).ToList();
                }
                return _mapper.Map<List<Bus>>(searchResult);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
