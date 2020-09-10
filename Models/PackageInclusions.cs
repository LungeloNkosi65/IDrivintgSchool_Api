using System;
using System.Collections.Generic;

namespace DrivingSchool_Api
{
    public partial class PackageInclusions
    {
        public PackageInclusions()
        {
            PackageInclusionsAssc = new HashSet<PackageInclusionsAssc>();
        }
        [System.ComponentModel.DataAnnotations.Key]
        public int InclusionId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PackageInclusionsAssc> PackageInclusionsAssc { get; set; }
    }
}
