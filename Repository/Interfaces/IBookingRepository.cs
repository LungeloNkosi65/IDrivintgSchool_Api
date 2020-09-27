using DrivingSchool_Api;
using Microsoft.EntityFrameworkCore.Internal;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
   public interface IBookingRepository
    {
        int Add(Booking booking);
        int Delete(int? bookingId);
        int Update(Booking booking);
        IQueryable<BookingVm> GetAll();
        BookingVm GetSingleRecord(int? bookingId);
        IQueryable<BookingVm> BookingDetails(string userName=null);
    }
}
