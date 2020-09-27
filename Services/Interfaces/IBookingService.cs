using DrivingSchool_Api;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
    public interface IBookingService
    {
        int Add(Booking booking);
        int Delete(int? bookingId);
        int Update(Booking booking);
        IQueryable<BookingVm> GetAll();
        BookingVm GetSingle(int? bookingId);
        IQueryable<BookingVm> BookingDetails(string userName = null);
    }
}
