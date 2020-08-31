using DrivingSchool_Api;
using Models.ViewModels;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Services.Implementations
{
    public class BookingPackageService : IBookingPackageService
    {
        private readonly IBookingPackageRepository _bookingPackageRepository;

        public BookingPackageService(IBookingPackageRepository bookingPackageRepository)
        {
            _bookingPackageRepository = bookingPackageRepository;
        }
        public void Add(BookingPackage bookingPackage)
        {
            _bookingPackageRepository.Add(bookingPackage);
        }

        public void Delete(int? bkpId)
        {
            _bookingPackageRepository.Delete(bkpId);
        }

        public IQueryable<BookingPackage> GatAll()
        {
            return _bookingPackageRepository.GetAll();
        }

        public IQueryable<BookingPackage> GetSingle(int? bkpId)
        {
            return _bookingPackageRepository.GetSingleRecord(bkpId);
        }

        public IQueryable<BookingPackageVm> GetVmDetails(int? bookingTypeId)
        {
            return _bookingPackageRepository.GetVmDetails(bookingTypeId);
        }

        public void Update(BookingPackage bookingPackage)
        {
            _bookingPackageRepository.Update(bookingPackage);
        }
    }
}
