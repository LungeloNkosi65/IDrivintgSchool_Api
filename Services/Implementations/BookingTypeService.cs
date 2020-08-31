using DrivingSchool_Api;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementations
{
    public class BookingTypeService : IBookingTypeService
    {
        private readonly IBookingTypeRepository _bookingTypeRepository;

        public BookingTypeService(IBookingTypeRepository bookingTypeRepository)
        {
            _bookingTypeRepository = bookingTypeRepository;
        }
        public void Add(BookingType bookingType)
        {
            _bookingTypeRepository.Add(bookingType);
        }

        public void Delete(int? bkTId)
        {
            _bookingTypeRepository.Delete(bkTId);
        }

        public IQueryable<BookingType> GatAll()
        {
            return _bookingTypeRepository.GetAll();
        }

        public IQueryable<BookingType> GetSingle(int? bkTId)
        {
            return _bookingTypeRepository.GetSingleRecord(bkTId);
        }

        public void Update(BookingType bookingType)
        {
            _bookingTypeRepository.Update(bookingType);
        }
    }
}
