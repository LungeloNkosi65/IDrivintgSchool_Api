using System;
using System.Collections.Generic;

namespace DrivingSchool_Api
{
    public partial class BookingPackage
    {
        public BookingPackage()
        {
            Booking = new HashSet<Booking>();
            PackageInclusionsAssc = new HashSet<PackageInclusionsAssc>();
        }

        public int BkpId { get; set; }
        public int BookingTypeId { get; set; }
        public string BkpName { get; set; }
        public string PackageDescription { get; set; }
        public decimal PackagePrice { get; set; }

        public virtual BookingType BookingType { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<PackageInclusionsAssc> PackageInclusionsAssc { get; set; }
    }
}
