using System;
using System.Collections.Generic;

namespace DrivingSchool_Api
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int BkpId { get; set; }
        public int TimeId { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime DateBookingFor { get; set; }
        public DateTime? DateBooked { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }

        public virtual BookingPackage Bkp { get; set; }
        public virtual TimeSlot Time { get; set; }
    }
}
