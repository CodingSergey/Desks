using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desks.Models
{
    public class Desk
    {
        public int ID { get; set; }
        public Boolean booked { get; set; }
        public int owner_ID { get; set; }
        public int location_ID { get; set; }
        public DateTime bookedUntil { get; set; }
    }
}
