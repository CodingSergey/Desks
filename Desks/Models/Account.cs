using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desks.Models
{
    public class Account
    {
        public int ID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public Boolean Admin { get; set; }
        public Boolean desk_Reserved { get; set; }
        public int desk_ID { get; set; }
    }
}
