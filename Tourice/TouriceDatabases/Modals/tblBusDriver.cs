using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouriceDatabases.Modals
{
    public class tblBusDriver
    {
        [Key]
        public int BusDriverId { get; set; }
        public string   BusDriverName { get; set; }
        public string CityAddress { get; set;}
        public string DLNumber { get; set; }
        public int ContactNumber { get; set; }
        public string Password { get; set; }
   
        [ForeignKey("AdminUserId")]
        public int UserId { get; set; }
        public tblUser tblUser { get; set; }
    }
}
