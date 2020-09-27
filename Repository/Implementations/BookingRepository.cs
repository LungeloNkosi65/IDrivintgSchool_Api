using DrivingSchool_Api;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Repository.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DrivingSchoolDbContext _db;
        private readonly IDapperBaseRepository _dapperBaseRepository;

        public BookingRepository(DrivingSchoolDbContext db, IDapperBaseRepository dapperBaseRepository)
        {
            _db = db;
            _dapperBaseRepository = dapperBaseRepository;
        }
        public int Add(Booking booking)
        {
            var parameters = new
            {
                booking.BkpId,
                booking.TimeId,
                booking.CustomerEmail,
                booking.DateBooked,
                booking.DateBookingFor,
                booking.Status,
                booking.Price
            };
            return _dapperBaseRepository.ExecuteWithDynamicParameter("AdddBooking", parameters);
        }

        public IQueryable<BookingVm> BookingDetails(string userName=null)
        {
            var parameter = new { userName };
            string qeury = "BookingView";
            return _dapperBaseRepository.QueryWithParameter<BookingVm>(qeury, parameter);
        }

        public int Delete(int? bookingId)
        {
            var parameters = new { bookingId };
            return _dapperBaseRepository.ExecuteWithDynamicParameter("DeleteBooking",bookingId);
        }


        public BookingVm GetSingleRecord(int? bookingId)
        {
            var parameter = new { bookingId };
            string qeury = "BookingDetails";
            return _dapperBaseRepository.QuerySingl<BookingVm>(qeury, parameter);
        }

        public IQueryable<BookingVm> GetAll()
        {
            return _dapperBaseRepository.Query<BookingVm>("BookingView");
        }

        public int Update(Booking booking)
        {
            var parameters = new
            {
                booking.BookingId,
                booking.BkpId,
                booking.TimeId,
                booking.CustomerEmail,
                booking.DateBookingFor,
                booking.DateBooked,
                booking.Price,
                booking.Status
            };
            return _dapperBaseRepository.Execute("UpdateBooking", parameters);
        }

    
    }
}
