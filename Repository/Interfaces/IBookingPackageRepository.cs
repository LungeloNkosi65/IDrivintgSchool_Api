using DrivingSchool_Api;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IBookingPackageRepository
    {
        void Add(BookingPackage bookingPackage);
        void Delete(int? bookingPackageId);
        void Update(BookingPackage bookingPackage);
        IQueryable<BookingPackage> GetAll();
        BookingPackage GetSingleRecord(int? bkPId);
        BookingPackage Find(int? bookingPackageId);

        IQueryable<BookingPackageVm> GetVmDetails(int? bookingTypeId);
    }
}
