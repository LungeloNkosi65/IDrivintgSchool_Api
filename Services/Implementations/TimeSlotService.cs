using DrivingSchool_Api;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementations
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly IGenericRepository<TimeSlot> _timeSlotRepository;

        public TimeSlotService(IGenericRepository<TimeSlot> timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository;
        }

        public bool Add(TimeSlot timeSlot)
        {
            return _timeSlotRepository.Add(timeSlot);
        }

        public bool Delete(int? timeId)
        {
            return _timeSlotRepository.Delete(timeId);
        }

        public IQueryable<TimeSlot> GetAll()
        {
            return _timeSlotRepository.GetAll();
        }

        public TimeSlot GetSingleRecord(int? timeId)
        {
            return _timeSlotRepository.GetSingleRecord(timeId);
        }

        public bool Update(TimeSlot timeSlot)
        {
            return _timeSlotRepository.Update(timeSlot);
        }
    }
}
