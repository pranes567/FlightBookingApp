using Airlineservice.DataContext;
using Airlineservice.Models;
using FlightBookingService.Airline.DTO.Request;
using FlightBookingService.Airline.DTO.Response;
using FlightBookingService.Airline.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Airline.Repository.Services
{
    public class AirlineFlightDetailsServices : IAirlineFlightDetailsServices
    {

        #region 
        private readonly AirlineContext _airlineServiceContext;
        #endregion

        #region Controller
        public AirlineFlightDetailsServices(AirlineContext airlineServiceContext)
        {
            _airlineServiceContext = airlineServiceContext ?? throw new ArgumentNullException(nameof(airlineServiceContext));
        }
        #endregion

        public async Task<bool> AddAirlineSchedule(AirlineFlightDetailsRequest airlineFlightDetailsRequest)
        {
            if (airlineFlightDetailsRequest == null)
                throw new ArgumentNullException(nameof(airlineFlightDetailsRequest));

            bool result = false;
            FlightDetails airlineFlightDetails;

            var airlineDetails = await _airlineServiceContext.FlightDetails.Where(d => d.FlightNumber == airlineFlightDetailsRequest.FlightNumber).FirstOrDefaultAsync();
            if (airlineDetails == null)
            {
                airlineFlightDetails = new FlightDetails()
                {
                    FlightNumber = airlineFlightDetailsRequest.FlightNumber,
                    Airline = airlineFlightDetailsRequest.Airline,
                    FromPlaceName = airlineFlightDetailsRequest.FromPlaceName,
                    ToPlaceName = airlineFlightDetailsRequest.ToPlaceName,
                    FlightStartDateTime = airlineFlightDetailsRequest.FlightStartDateTime,
                    FlightToDateTime = airlineFlightDetailsRequest.FlightToDateTime,
                    TotalBusinessSeats = airlineFlightDetailsRequest.TotalBusinessSeats,
                    TotalNonBusinessSeats = airlineFlightDetailsRequest.TotalNonBusinessSeats,
                    TicketCost = airlineFlightDetailsRequest.TicketCost,
                    FlightSeatRow = airlineFlightDetailsRequest.FlightSeatRow,
                    Meal = airlineFlightDetailsRequest.Meal,
                    CreateDate = DateTime.Now,
                    Flag = 0
                };
                await _airlineServiceContext.AddAsync(airlineFlightDetails);
            }
            else
            {
                airlineDetails.Airline = airlineFlightDetailsRequest.Airline;
                airlineDetails.FromPlaceName = airlineFlightDetailsRequest.FromPlaceName;
                airlineDetails.ToPlaceName = airlineFlightDetailsRequest.ToPlaceName;
                airlineDetails.FlightStartDateTime = airlineFlightDetailsRequest.FlightStartDateTime;
                airlineDetails.FlightToDateTime = airlineFlightDetailsRequest.FlightToDateTime;
                airlineDetails.TotalBusinessSeats = airlineFlightDetailsRequest.TotalBusinessSeats;
                airlineDetails.TotalNonBusinessSeats = airlineFlightDetailsRequest.TotalNonBusinessSeats;
                airlineDetails.TicketCost = airlineFlightDetailsRequest.TicketCost;
                airlineDetails.FlightSeatRow = airlineFlightDetailsRequest.FlightSeatRow;
                airlineDetails.Meal = airlineFlightDetailsRequest.Meal;
                airlineDetails.CreateDate = DateTime.Now;
                airlineDetails.Flag = 0;
            }

            await _airlineServiceContext.SaveChangesAsync();
            return result;
        }

        public async Task<List<AirlineFlightDetailsResponse>> SearchFlight(string frmplace,string toplace)
        {



            //var searchList = await _airlineServiceContext.FlightDetails.Where(d =>d.ToPlaceName.Contains(toplace) &&
            //                                           d.FromPlaceName.Contains(frmplace)).Select(p => new AirlineFlightDetailsResponse
            //                                           {
            //                                               FlightNumber = p.FlightNumber,
            //                                               Airline = p.Airline,
            //                                               FromPlaceName = p.FromPlaceName,
            //                                               ToPlaceName = p.ToPlaceName,
            //                                               FlightStartDateTime = p.FlightStartDateTime,
            //                                               FlightToDateTime = p.FlightToDateTime,
            //                                               TotalBusinessSeats = p.TotalBusinessSeats,
            //                                               TotalNonBusinessSeats = p.TotalNonBusinessSeats,
            //                                               TicketCost = p.TicketCost,
            //                                               FlightSeatRow = p.FlightSeatRow,
            //                                               Meal = p.Meal
            //                                           }).ToListAsync();

            //var airlineFlightDetailsResponseList = new AirlineFlightDetailsResponseList
            //{
            //    airlineFlightDetailsResponsesList = searchList
            //};
            //return airlineFlightDetailsResponseList;
            List<AirlineFlightDetailsResponse> airlineFlightDetailsResponseList = new List<AirlineFlightDetailsResponse>();
            try
            {
                var searchList = await _airlineServiceContext.FlightDetails.Where(d => d.ToPlaceName.Contains(toplace) &&
                                                      d.FromPlaceName.Contains(frmplace)).Select(p => new AirlineFlightDetailsResponse
                {
                    FlightNumber = p.FlightNumber,
                    Airline = p.Airline,
                    FromPlaceName = p.FromPlaceName,
                    ToPlaceName = p.ToPlaceName,
                    FlightStartDateTime = p.FlightStartDateTime,
                    FlightToDateTime = p.FlightToDateTime,
                    TotalBusinessSeats = p.TotalBusinessSeats,
                    TotalNonBusinessSeats = p.TotalNonBusinessSeats,
                    TicketCost = p.TicketCost,
                    FlightSeatRow = p.FlightSeatRow,
                    Meal = p.Meal
                }).ToListAsync();

                airlineFlightDetailsResponseList = searchList;

            }
            catch (Exception)
            {

                throw;
            }
            return airlineFlightDetailsResponseList;
        }



        //public Task<long> addflightbooking(BookFlight bookFlight)
        //{
        //    //if (bookFlight == null)
        //    //    throw new ArgumentNullException(nameof(bookFlight));

        //    //BookFlight bookflightdetails;

        //    //Random rnd = new Random();
        //    //long randomno = rnd.Next(10000000, 99999999);


        //    //var flightdetails =  _airlineServiceContext.bookFlights.Where(d => d.FlightNumber == bookFlight.FlightNumber).FirstOrDefault();
        //    //if (flightdetails == null)
        //    //{
        //    //    bookflightdetails = new BookFlight()
        //    //    {
        //    //        FlightNumber = bookFlight.FlightNumber,
        //    //        FlightID = bookFlight.FlightID,
        //    //        UserName = bookFlight.UserName,
        //    //        FromPlaceName = bookFlight.FromPlaceName,
        //    //        ToPlaceName = bookFlight.ToPlaceName,
        //    //        FlightStartDateTime = bookFlight.FlightStartDateTime,
        //    //        FlightToDateTime = bookFlight.FlightToDateTime,
        //    //        No_of_Seats = bookFlight.No_of_Seats,
        //    //        TicketCost = bookFlight.TicketCost,
        //    //        FlightSeatNo = bookFlight.FlightSeatNo,
        //    //        Meal = bookFlight.Meal,
        //    //        CreateDate = DateTime.Now,
        //    //        DiscountCouponID = 0,
        //    //        FinalPrice = Convert.ToInt32(bookFlight.TicketCost),
        //    //        PNR = randomno,
        //    //        status = "Booked"

        //    //    };
        //    //     _airlineServiceContext.AddAsync(bookflightdetails);
        //    //}
        //    //else
        //    //{
        //    //    flightdetails.FlightID = bookFlight.FlightID;
        //    //    flightdetails.UserName = bookFlight.UserName;
        //    //    flightdetails.FromPlaceName = bookFlight.FromPlaceName;
        //    //    flightdetails.ToPlaceName = bookFlight.ToPlaceName;
        //    //    flightdetails.FlightStartDateTime = bookFlight.FlightStartDateTime;
        //    //    flightdetails.FlightToDateTime = bookFlight.FlightToDateTime;
        //    //    flightdetails.No_of_Seats = bookFlight.No_of_Seats;
        //    //    flightdetails.TicketCost = bookFlight.TicketCost;
        //    //    flightdetails.FlightSeatNo = bookFlight.FlightSeatNo;
        //    //    flightdetails.Meal = bookFlight.Meal;
        //    //    flightdetails.CreateDate = DateTime.Now;
        //    //    flightdetails.PNR = randomno;
        //    //    flightdetails.status = "Booked";
        //    //}

        //    // _airlineServiceContext.SaveChangesAsync();
        //    //return randomno;
        //}

        public async Task<long> BookFlights(BookFlight bookFlight)
        {
            if (bookFlight == null)
                throw new ArgumentNullException(nameof(bookFlight));

            BookFlight bookflightdetails;

            Random rnd = new Random();
            long randomno = rnd.Next(10000000, 99999999);
            


            var flightdetails = _airlineServiceContext.bookFlights.Where(d => d.FlightNumber == bookFlight.FlightNumber).FirstOrDefault();
            if (flightdetails != null)
            {
                int FinalPrice =Convert.ToInt32(bookFlight.TicketCost);
                var findcoupon = _airlineServiceContext.DiscountCoupons.Where(a => a.DiscountCouponID == bookFlight.DiscountCouponID).FirstOrDefault();
                if(findcoupon != null)
                {
                    FinalPrice = Convert.ToInt32(bookFlight.TicketCost - findcoupon.couponvalue);
                }


                bookflightdetails = new BookFlight()
                {
                    FlightNumber = bookFlight.FlightNumber,
                    FlightID = bookFlight.FlightID,
                    UserName = bookFlight.UserName,
                    FromPlaceName = bookFlight.FromPlaceName,
                    ToPlaceName = bookFlight.ToPlaceName,
                    FlightStartDateTime = bookFlight.FlightStartDateTime,
                    FlightToDateTime = bookFlight.FlightToDateTime,
                    No_of_Seats = bookFlight.No_of_Seats,
                    TicketCost = bookFlight.TicketCost,
                    FlightSeatNo = bookFlight.FlightSeatNo,
                    Meal = bookFlight.Meal,
                    CreateDate = DateTime.Now,
                    DiscountCouponID = bookFlight.DiscountCouponID,
                    FinalPrice = FinalPrice,
                    PNR = randomno,
                    status = "Booked"

                };
                //bookflightdetails = new BookFlight()
                //{
                //    FlightNumber = "k123",
                //    FlightID = 2,
                //    UserName = "pranes",
                //    FromPlaceName = "Bangalore",
                //    ToPlaceName = "Chennai",
                //    FlightStartDateTime = Convert.ToDateTime("2022 - 05 - 09 23:20:53.0410000"),
                //    FlightToDateTime = Convert.ToDateTime("2022 - 05 - 10 23:20:53.0410000"),
                //    No_of_Seats = 2,
                //    TicketCost = 3500,
                //    FlightSeatNo = 23,
                //    Meal = "Veg",
                //    CreateDate = DateTime.Now,
                //    DiscountCouponID = bookFlight.DiscountCouponID,
                //    FinalPrice = 3000,
                //    PNR = randomno,
                //    status = "Booked"

                //};
                await _airlineServiceContext.AddAsync(bookflightdetails);
            }
            else
            {
                //bookflightdetails = new BookFlight()
                //{
                //    FlightNumber = "k123",
                //    FlightID = 2,
                //    UserName ="pranes456",
                //    FromPlaceName = "Bangalore",
                //    ToPlaceName = "Chennai",
                //    FlightStartDateTime = Convert.ToDateTime("2022 - 05 - 09 23:20:53.0410000"),
                //    FlightToDateTime = Convert.ToDateTime("2022 - 05 - 10 23:20:53.0410000"),
                //    No_of_Seats = 2,
                //    TicketCost = 3500,
                //    FlightSeatNo = 23,
                //    Meal = MealEnum.Veg,
                //    CreateDate = DateTime.Now,
                //    DiscountCouponID = bookFlight.DiscountCouponID,
                //    FinalPrice = 3000,
                //    PNR = randomno,
                //    status = "Booked"

                //};
                //await _airlineServiceContext.AddAsync(bookflightdetails);

                flightdetails.FlightNumber = bookFlight.FlightNumber;
                flightdetails.FlightID = bookFlight.FlightID;
                flightdetails.UserName = "pranes467";
                flightdetails.FromPlaceName = bookFlight.FromPlaceName;
                flightdetails.ToPlaceName = bookFlight.ToPlaceName;
                flightdetails.FlightStartDateTime = bookFlight.FlightStartDateTime;
                flightdetails.FlightToDateTime = bookFlight.FlightToDateTime;
                flightdetails.No_of_Seats = bookFlight.No_of_Seats;
                flightdetails.TicketCost = bookFlight.TicketCost;
                flightdetails.FlightSeatNo = bookFlight.FlightSeatNo;
                flightdetails.Meal = bookFlight.Meal;
                flightdetails.CreateDate = DateTime.Now;
                flightdetails.PNR = randomno;
                flightdetails.status = "Booked";
            }

            await _airlineServiceContext.SaveChangesAsync();
            return randomno;
        }

        public async Task<BookFlight> searchTicket(long PNR)
        {
            var searchList = await _airlineServiceContext.bookFlights.Where(d => d.PNR == PNR).FirstOrDefaultAsync();

            return searchList;
        }

        public async Task<string> CancelTicket(long PNR)
        {
            var bookedticket = await _airlineServiceContext.bookFlights.Where(t => t.PNR == PNR).FirstOrDefaultAsync();
            string result = string.Empty;
            if (bookedticket != null)
            {
                bookedticket.status = "Cancelled";
                result = "Ticket Cancelled Successfully";
            }
            else
            {
                result = "Ticket Not Found";
            }
            await _airlineServiceContext.SaveChangesAsync();
            return result;
        }

        public async Task<List<AirlineFlightDetailsResponse>> GetAllFlights()
        {
            List<AirlineFlightDetailsResponse> airlineFlightDetailsResponseList = new List<AirlineFlightDetailsResponse>();
            try
            {
                var searchList = await _airlineServiceContext.FlightDetails.Select(p => new AirlineFlightDetailsResponse
                {
                    FlightNumber = p.FlightNumber,
                    Airline = p.Airline,
                    FromPlaceName = p.FromPlaceName,
                    ToPlaceName = p.ToPlaceName,
                    FlightStartDateTime = p.FlightStartDateTime,
                    FlightToDateTime = p.FlightToDateTime,
                    TotalBusinessSeats = p.TotalBusinessSeats,
                    TotalNonBusinessSeats = p.TotalNonBusinessSeats,
                    TicketCost = p.TicketCost,
                    FlightSeatRow = p.FlightSeatRow,
                    Meal = p.Meal
                }).ToListAsync();

                airlineFlightDetailsResponseList = searchList;

            }
            catch (Exception)
            {

                throw;
            }
            return airlineFlightDetailsResponseList;
        }

        public async Task<bool> AddCoupon(DiscountCoupon coupon)
        {
            bool result = false;
            try
            {
                if (coupon == null)
                    throw new ArgumentNullException(nameof(coupon));

                var checkcoupon = await _airlineServiceContext.DiscountCoupons.Where(d => d.CouponCode == coupon.CouponCode).FirstOrDefaultAsync();
                if (checkcoupon == null)
                {
                    DiscountCoupon discountCoupon = new DiscountCoupon() { CouponCode = coupon.CouponCode, couponvalue = coupon.couponvalue, Remarks = coupon.Remarks };
                    await _airlineServiceContext.DiscountCoupons.AddAsync(discountCoupon);
                    await _airlineServiceContext.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

           

            return result;

        }

        public async Task<DiscountCoupon> GetCoupon(string couponcode)
        {
            DiscountCoupon discountCoupon = new DiscountCoupon();
            try
            {
                
                var couponcheck = await _airlineServiceContext.DiscountCoupons.Where(d => d.CouponCode == couponcode).FirstOrDefaultAsync();
                if (couponcheck != null)
                {
                    discountCoupon = couponcheck;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return discountCoupon;
        }

        public async Task<List<DiscountCoupon>> GetAllCoupon()
        {
            List<DiscountCoupon> couponlist = new List<DiscountCoupon>();
            try
            {
                var result = await _airlineServiceContext.DiscountCoupons.ToListAsync();
                if(result.Count>0)
                {
                    couponlist = result;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return couponlist;
        }

        public async Task<List<BookFlight>> GetallTickets()
        {
            var searchList = await _airlineServiceContext.bookFlights.ToListAsync();

            return searchList;
        }
    }
}
