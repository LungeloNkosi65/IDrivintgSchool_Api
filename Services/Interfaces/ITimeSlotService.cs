using DrivingSchool_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
   public interface ITimeSlotService
    {
        bool Add(TimeSlot timeSlot);
        bool Delete(int? timeId);
        bool Update(TimeSlot timeSlot);
        IQueryable<TimeSlot> GetAll();
        TimeSlot GetSingleRecord(int? timeId);
    
    }
}
