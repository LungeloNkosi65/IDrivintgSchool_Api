﻿using Services.Interfaces;
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

        public IPackageInclusionService PackageInclusion { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public ItokenService TokenService { get; set; }

        public ServicesUnitOfWork(IBookingPackageService bookingPackageService, IBookingService bookingService,
                                  IBookingTypeService bookingTypeService,ITimeSlotService timeSlotService,
                                  IPackageInclusionService packageInclusionService, IAuthenticationService authenticationService,
                                  ItokenService tokenService)
        {
            BookingTypeService = bookingTypeService;
            BookingPackageService = bookingPackageService;
            BookingService = bookingService;
            TimeSlotService = timeSlotService;
            PackageInclusion = packageInclusionService;
            AuthenticationService = authenticationService;
            TokenService = tokenService;
        }
    }
}
