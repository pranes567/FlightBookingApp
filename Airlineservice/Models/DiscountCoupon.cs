using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlineservice.Models
{
    public class DiscountCoupon
    {
        [Key]
        public int DiscountCouponID { get; set; }
        public string CouponCode { get; set; }
        public int couponvalue { get; set; }

        public string Remarks { get; set; }
    }
}
