using DrivingSchool_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
  public  interface IBookingTypeService
    {
        void Add(BookingType bookingType);
        void Update(BookingType bookingType);
        void Delete(int? bkTId);
        IQueryable<BookingType> GatAll();
        IQueryable<BookingType> GetSingle(int? bkTId);
    }
}
