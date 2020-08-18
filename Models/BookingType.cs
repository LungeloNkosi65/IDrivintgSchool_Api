using System;
using System.Collections.Generic;

namespace DrivingSchool_Api
{
    public partial class BookingType
    {
        public BookingType()
        {
            BookingPackage = new HashSet<BookingPackage>();
        }

        public int BookingTypeId { get; set; }
        public string BktName { get; set; }
        public string ShortDescription { get; set; }

        public virtual ICollection<BookingPackage> BookingPackage { get; set; }
    }


}
