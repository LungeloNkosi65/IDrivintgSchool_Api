﻿using DrivingSchool_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
  public  interface IBookingPackageService
    {
        void Add(BookingPackage bookingPackage);
        void Update(BookingPackage bookingPackage);
        void Delete(int? bkpId);
        IQueryable<BookingPackage> GatAll();
        IQueryable<BookingPackage> GetSingle(int? bkpId);
    }
}
