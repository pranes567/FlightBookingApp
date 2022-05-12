﻿using Airlineservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Airline.DTO.Response
{
    public class AirlineFlightDetailsResponse
    {
        public string FlightNumber { get; set; }

        public string Airline { get; set; }

        public string FromPlaceName { get; set; }

        public string ToPlaceName { get; set; }

        public DateTime FlightStartDateTime { get; set; }
        public DateTime FlightToDateTime { get; set; }

        public int TotalBusinessSeats { get; set; }

        public int TotalNonBusinessSeats { get; set; }

        public decimal TicketCost { get; set; }

        public int FlightSeatRow { get; set; }

        public string Meal { get; set; }
    }
}
