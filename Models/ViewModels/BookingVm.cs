using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class BookingVm
    {
        public int BookingId { get; set; }
        public string CustomerEmail { get; set; }
        public int BkpId { get; set; }
        public string PackageDescription { get; set; }
        public int TimeId { get; set; }
        public TimeSpan TimeSlot { get; set; }
        public DateTime DateBookingFor { get; set; }
        public DateTime? DateBooked { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }
    }
}
