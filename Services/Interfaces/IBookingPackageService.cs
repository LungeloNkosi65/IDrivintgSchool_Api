using DrivingSchool_Api;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
  public  interface IBookingPackageService
    {
        void Add(BookingPackage bookingPackage);
        void Update(BookingPackage bookingPackage);
        void Delete(int? bkpId);
        IQueryable<BookingPackage> GatAll();
        BookingPackage GetSingle(int? bkpId);
        IQueryable<BookingPackageVm> GetVmDetails(int? bookingTypeId);
    }
}
