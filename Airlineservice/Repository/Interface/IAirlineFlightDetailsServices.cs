using Airlineservice.Models;
using FlightBookingService.Airline.DTO.Request;
using FlightBookingService.Airline.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Airline.Repository.Interface
{
    public interface IAirlineFlightDetailsServices
    {
        Task<bool> AddAirlineSchedule(AirlineFlightDetailsRequest airlineFlightDetailsRequest);

        Task<List<AirlineFlightDetailsResponse>> SearchFlight(string frmplace,string toplace);

        Task<List<AirlineFlightDetailsResponse>> GetAllFlights();

        Task<long> BookFlights(BookFlight bookFlight);

        Task<BookFlight> searchTicket(long PNR);
        Task<List<BookFlight>> GetallTickets();

        Task<string> CancelTicket(long PNR);

        Task<bool> AddCoupon(DiscountCoupon coupon);
        Task<DiscountCoupon> GetCoupon(string couponcode);
        Task<List<DiscountCoupon>> GetAllCoupon();
    }
}
