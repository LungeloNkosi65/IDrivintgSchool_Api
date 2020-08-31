using DrivingSchool_Api;
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
        public void Add(Booking booking)
        {
            _bookingRepository.Add(booking);
        }

        public void Delete(int? bookingId)
        {
            _bookingRepository.Delete(bookingId);
        }

        public IQueryable<Booking> GetAll()
        {
            return _bookingRepository.GetAll();
        }

        public IQueryable<Booking> GetSingle(int? bookingId)
        {
            return _bookingRepository.GetSingleRecord(bookingId);
        }

        public void Update(Booking booking)
        {
            _bookingRepository.Update(booking);
        }
    }
}
