using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels
{
    public class PackageInclusionVm
    {
        [Key]
        public int PiId { get; set; }
        public int InclusionId { get; set; }
        public string Description { get; set; }

    }
}
