using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlineservice.Models
{
    public class BookFlight
    {
        [Key]
        public int BookingId { get; set; }


        public long PNR { get; set; }
        public string FlightNumber { get; set; }

        public string UserName { get; set; }

        public int  FlightID { get; set; }

        public string FromPlaceName { get; set; }

        public string ToPlaceName { get; set; }

        public DateTime FlightStartDateTime { get; set; }
        public DateTime FlightToDateTime { get; set; }

        public int No_of_Seats { get; set; }        

        public decimal TicketCost { get; set; }

        public int? DiscountCouponID { get; set; }

        public int FinalPrice { get; set; }

        public int FlightSeatNo { get; set; }

        public string  Meal { get; set; }

        public DateTime CreateDate { get; set; }
        public string status { get; set; }
    }
}
