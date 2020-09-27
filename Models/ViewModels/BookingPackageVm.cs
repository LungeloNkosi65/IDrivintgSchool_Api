using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels
{
  public  class BookingPackageVm
    {
        [Key]
        public int BkpId { get; set; }

        public int BookingTypeId { get; set; }
        public string BktName { get; set; }
        public string BkpName { get; set; }
        public string PackageDescription { get; set; }
        public string PackagePrice { get; set; }
    }
}
