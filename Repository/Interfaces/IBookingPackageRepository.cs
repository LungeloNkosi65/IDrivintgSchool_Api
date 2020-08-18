using DrivingSchool_Api;
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
        IQueryable<BookingPackage> GetSingleRecord(int? bkPId);
        BookingPackage Find(int? bookingPackageId);
    }
}
