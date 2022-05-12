using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airlineservice.Models
{
    public class Passenger
    {
        public int passengerID { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Gender { get; set; }
        public long pnr { get; set; }
    }
}
