using DrivingSchool_Api;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Add(Booking booking)
        {
            _db.Booking.Add(booking);
            _db.SaveChanges();
        }

        public IQueryable<BookingVm> BookingDetails(int? bookingId)
        {
            var parameter = new { bookingId };
            string qeury = "BookingDetails";
            return _dapperBaseRepository.QueryWithParameter<BookingVm>(qeury, parameter);
        }

        public void Delete(int? bookingId)
        {
            var dbRecord = Find(bookingId);
            _db.Remove(dbRecord);
            _db.SaveChanges();
        }

        public Booking Find(int? bookindId)
        {
            return _db.Booking.Find(bookindId);
        }

        public IQueryable<Booking> GetSingleRecord(int? bookingId)
        {
            var parameter = new { bookingId };
            string qeury = "[dbo].[GetSinglerBookingType]";
            return _dapperBaseRepository.QuerySingl<Booking>(qeury, parameter);
        }

        public IQueryable<Booking> GetAll()
        {
            return _db.Booking.AsQueryable();

        }

        public void Update(Booking booking)
        {
            _db.Entry(booking).State = EntityState.Modified;
        }
    }
}
