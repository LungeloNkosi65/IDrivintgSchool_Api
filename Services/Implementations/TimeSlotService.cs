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
        public void Add(TimeSlot timeSlot)
        {
            _timeSlotRepository.Add(timeSlot);
        }

        public void Delete(int? timeId)
        {
            _timeSlotRepository.Delete(timeId);
        }

        public TimeSlot Find(int? timeId)
        {
           return _timeSlotRepository.Find(timeId);
        }

        public IQueryable<TimeSlot> GetAll()
        {
            return _timeSlotRepository.GetAll();
        }

        public IQueryable<TimeSlot> GetSingleRecord(int? timeId)
        {
            return _timeSlotRepository.GetSingleRecord(timeId);
        }

        public void Update(TimeSlot timeSlot)
        {
            _timeSlotRepository.Update(timeSlot);
        }
    }
}
