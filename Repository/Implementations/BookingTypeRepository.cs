using DrivingSchool_Api;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Implementations
{
    public class BookingTypeRepository : IBookingTypeRepository
    {
        private readonly DrivingSchoolDbContext _db;
        private readonly IDapperBaseRepository _dapperBaseRepository;

        public BookingTypeRepository(DrivingSchoolDbContext db, IDapperBaseRepository dapperBaseRepository)
        {
            _db = db;
            _dapperBaseRepository = dapperBaseRepository;
        }
        public void Add(BookingType bookingType)
        {
            _db.BookingType.Add(bookingType);
            _db.SaveChanges();
        }

        public void Delete(int? bookingTypeId)
        {
            var dbRecord = Find(bookingTypeId);
            _db.BookingType.Remove(dbRecord);
            _db.SaveChanges();
        }

        public BookingType Find(int? bookingTypeId)
        {
            return _db.BookingType.Find(bookingTypeId);
        }

        public IQueryable<BookingType> GetAll()
        {
            return _db.BookingType.AsQueryable();
        }

        public BookingType GetSingleRecord(int? bookingTypeId)
        {
            string qeury = "GetSinglerBookingType";
            var parameters = new { bookingTypeId };
            return _dapperBaseRepository.QuerySingl<BookingType>(qeury, parameters);
        }

        public void Update(BookingType bookingType)
        {
            _db.Entry(bookingType).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
