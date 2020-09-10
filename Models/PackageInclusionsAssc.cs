using System;
using System.Collections.Generic;

namespace DrivingSchool_Api
{
    public partial class PackageInclusionsAssc
    {
        public int Piid { get; set; }
        public int BkpId { get; set; }
        public int InclusionId { get; set; }

        public virtual BookingPackage Bkp { get; set; }
        public virtual PackageInclusions Inclusion { get; set; }
    }
}
