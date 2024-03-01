using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouriceDatabases.MapperClass;
using TouriceDatabases.Modals;

namespace TouriceServices
{
    public class touriceAutoMapper:Profile
    {
        public touriceAutoMapper()
        {
            CreateMap<tblUserLogin, tblUser>()
                .ReverseMap();
            // Buss Mapper
            CreateMap<tblbus , Bus>()
                .ReverseMap();
            CreateMap<tblBusDriver, BusDriver>()
              .ReverseMap();
        }
    }
}
