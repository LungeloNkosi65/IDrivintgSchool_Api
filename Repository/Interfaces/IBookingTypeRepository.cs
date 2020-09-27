using DrivingSchool_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
  public interface IBookingTypeRepository
    {
        void Add(BookingType bookingType);
        void Delete(int? bookingTypeId);
        void Update(BookingType bookingType);
        IQueryable<BookingType> GetAll();
        BookingType GetSingleRecord(int? bookingTypeId);
        BookingType Find(int? bookingTypeId);
    }
}
