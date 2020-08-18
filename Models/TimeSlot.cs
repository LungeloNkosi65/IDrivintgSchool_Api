using System;
using System.Collections.Generic;

namespace DrivingSchool_Api
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            Booking = new HashSet<Booking>();
        }

        public int TimeId { get; set; }
        public TimeSpan TimeSlot1 { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
