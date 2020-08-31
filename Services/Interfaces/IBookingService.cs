using DrivingSchool_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
    public interface IBookingService
    {
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete(int? bookingId);
        IQueryable<Booking> GetAll();
        IQueryable<Booking> GetSingle(int? bookingId);
    }
}
