using DrivingSchool_Api;
using Models.ViewModels;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public int Add(Booking booking)
        {
           return _bookingRepository.Add(booking);
        }

        public IQueryable<BookingVm> BookingDetails(string userName=null)
        {
            return _bookingRepository.BookingDetails(userName);
        }

        public int Delete(int? bookingId)
        {
           return _bookingRepository.Delete(bookingId);
        }

        public IQueryable<BookingVm> GetAll()
        {
            return _bookingRepository.GetAll();
        }

        public BookingVm GetSingle(int? bookingId)
        {
            return _bookingRepository.GetSingleRecord(bookingId);
        }

        public int Update(Booking booking)
        {
           return _bookingRepository.Update(booking);
        }
    }
}
