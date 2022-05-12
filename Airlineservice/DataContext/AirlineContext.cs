using Airlineservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airlineservice.DataContext
{
    public class AirlineContext:DbContext
    {
        public AirlineContext(DbContextOptions<AirlineContext> options) : base(options)
        {

        }

        public DbSet<FlightDetails> FlightDetails { get; set; }

        public DbSet<BookFlight> bookFlights { get; set; }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}
