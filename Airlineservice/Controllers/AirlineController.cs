using Airlineservice.Models;
using FlightBookingService.Airline.DTO.Request;
using FlightBookingService.Airline.DTO.Response;
using FlightBookingService.Airline.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightBookingService.Airline.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        #region
        private readonly IAirlineFlightDetailsServices _airlineFlightDetailsServices;
        #endregion

        #region Controller

        public AirlineController(IAirlineFlightDetailsServices airlineFlightDetailsServices)
        {
            _airlineFlightDetailsServices = airlineFlightDetailsServices ?? throw new ArgumentNullException(nameof(airlineFlightDetailsServices));
        }
         
        #endregion

        // GET: api/<AirlineController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost, ActionName("Inventory")]
        [HttpPost]
        public async Task<bool> Register([FromBody] AirlineFlightDetailsRequest airlineFlightDetailsRequest)
        {
            var result = await _airlineFlightDetailsServices.AddAirlineSchedule(airlineFlightDetailsRequest);

            return result;
        }

        [HttpPost, ActionName("bookflight")]
        [HttpPost]
        public async Task<long>Bookflightfrtrip([FromBody] BookFlight bookflight)
        {
            var result = await _airlineFlightDetailsServices.BookFlights(bookflight);

            return result;
        }
        [HttpGet,ActionName("SearchFlight")]
        public async Task<List<AirlineFlightDetailsResponse>> SearchFlight(string frmplace,string toplace)
        {
            var flightlist = await _airlineFlightDetailsServices.SearchFlight(frmplace,toplace);

            return flightlist;
        }

        [HttpGet, ActionName("GetallFlight")]
        public async Task<List<AirlineFlightDetailsResponse>> GetallFlight()
        {
            var flightlist = await _airlineFlightDetailsServices.GetAllFlights();

            return flightlist;
        }
        [HttpGet,ActionName("Ticket")]
        public async Task<BookFlight> getTicket(long PNR)
        {
            var tickets = await _airlineFlightDetailsServices.searchTicket(PNR);

            return tickets;
        }
        [HttpGet, ActionName("AllTicket")]
        public async Task<List<BookFlight>> getAllTicket()
        {
            var tickets = await _airlineFlightDetailsServices.GetallTickets();

            return tickets;
        }
        [HttpPut, ActionName("Cancel")]
        public async Task<string> cancelTicket(long pnr)
        {
            var tickets = await _airlineFlightDetailsServices.CancelTicket(pnr);

            return tickets;
        }

        [HttpPost,ActionName("AddDiscoundCoupon")]
        public async Task<bool> AddDiscoundCoupon(DiscountCoupon coupon)
        {
            var discoundcoupon = await _airlineFlightDetailsServices.AddCoupon(coupon);
            return discoundcoupon;
        }
        [HttpGet,ActionName("GetDiscountCoupon")]
        public async Task<DiscountCoupon> GetDiscountCoupon(string coupon)
        {
            var result = await _airlineFlightDetailsServices.GetCoupon(coupon);
            return result;
        }
        [HttpGet,ActionName("GetAllDiscountCoupon")]
        public async Task<List<DiscountCoupon>> GetAllDiscountCoupon()
        {
            var result = await _airlineFlightDetailsServices.GetAllCoupon();
            return result;
        }

        // GET api/<AirlineController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AirlineController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AirlineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AirlineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
