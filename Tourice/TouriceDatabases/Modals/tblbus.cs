using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouriceDatabases.Modals
{
    public class tblbus
    {
        [Key]
        public int BusId { get; set; }
        public string BusName { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string ViaCities { get; set; }

        public int BusNo { get; set; }
        //Implement User Id Foreign key Relationship
    }
}
