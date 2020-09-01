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
    public class BookingPackageRepository : IBookingPackageRepository
    {
        private readonly DrivingSchoolDbContext _db;
        private readonly IDapperBaseRepository _dapperBaseRepository;


        public BookingPackageRepository(DrivingSchoolDbContext db,IDapperBaseRepository dapperBaseRepository)
        {
            _db = db;
            _dapperBaseRepository = dapperBaseRepository;
        }
        public void Add(BookingPackage bookingPackage)
        {
            _db.BookingPackage.Add(bookingPackage);
            _db.SaveChanges();
        }

        public void Delete(int? bookingPackageId)
        {
            var dbRecord = _db.BookingPackage.Find(bookingPackageId);
            _db.BookingPackage.Remove(dbRecord);
            _db.SaveChanges();
        }

        public BookingPackage Find(int? bookingPackageId)
        {
            return _db.BookingPackage.Find(bookingPackageId);
            ///
        }

        public IQueryable<BookingPackage> GetAll()
        {
            return _db.BookingPackage.AsQueryable();
        }

        public IQueryable<BookingPackage> GetSingleRecord(int? bkPId)
        {
            var parameter = new { bkPId };
            string qeury = "GetSinglePackage";
            return _dapperBaseRepository.QuerySingl<BookingPackage>(qeury, parameter);
        }

        public IQueryable<BookingPackageVm> GetVmDetails(int? bookingTypeId)
        {
            var parameter = new { bookingTypeId };
             string command = "PackagesView";
            return _dapperBaseRepository.QueryWithParameter<BookingPackageVm>(command, parameter);
        }

        public void Update(BookingPackage bookingPackage)
        {
            _db.Entry(bookingPackage).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
