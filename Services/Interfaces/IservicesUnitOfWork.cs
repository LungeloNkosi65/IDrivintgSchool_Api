﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
   public interface IServicesUnitOfWork
    {
        IBookingPackageService BookingPackageService { get; set; }
        IBookingService BookingService { get; set; }
        IBookingTypeService BookingTypeService { get; set; }
        ITimeSlotService TimeSlotService { get; set; }
    }
}
