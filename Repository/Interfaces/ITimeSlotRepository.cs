using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrivingSchool_Api;
using Models;
namespace Repository.Interfaces
{
    public interface ITimeSlotRepository
    {
        void Add(TimeSlot timeSlot);
        void Delete(int? timeId);
        void Update(TimeSlot timeSlot);
        IQueryable<TimeSlot> GetAll();
        IQueryable<TimeSlot> GetSingleRecord(int? timeId);

        TimeSlot Find(int? timeId);
    }
}
