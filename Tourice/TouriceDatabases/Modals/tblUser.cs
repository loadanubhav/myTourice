using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TouriceDatabases.Modals
{
    public class tblUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string   Password { get; set; }
        public string Role { get; set; }
        
    }
}
