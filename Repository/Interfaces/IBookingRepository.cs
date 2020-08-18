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
        void Add(Booking booking);
        void Delete(int? bookingId);
        void Update(Booking booking);
        IQueryable<Booking> GetAll();
        IQueryable<Booking> GetSingleRecord(int? bookingId);
        Booking Find(int? bookindId);

        IQueryable<BookingVm> BookingDetails(int? bookingId);
    }
}
