using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class ServicesUnitOfWork : IServicesUnitOfWork
    {

        public IBookingPackageService BookingPackageService { get; set; }
        public IBookingService BookingService { get; set; }
        public IBookingTypeService BookingTypeService { get; set; }
        public ITimeSlotService TimeSlotService { get; set; }
        
        public ServicesUnitOfWork(IBookingPackageService bookingPackageService, IBookingService bookingService,
                                  IBookingTypeService bookingTypeService,ITimeSlotService timeSlotService)
        {
            BookingTypeService = bookingTypeService;
            BookingPackageService = bookingPackageService;
            BookingService = bookingService;
            TimeSlotService = timeSlotService;
        }
    }
}
