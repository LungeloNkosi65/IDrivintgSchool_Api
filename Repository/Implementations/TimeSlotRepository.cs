using DrivingSchool_Api;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Repository.Implementations
{
    public class TimeSlotRepository : IGenericRepository<TimeSlot>
    {
        private readonly DrivingSchoolDbContext _db;
        private readonly IDapperBaseRepository _dapperBaseRepository;
        
        public TimeSlotRepository(DrivingSchoolDbContext db, IDapperBaseRepository  dapperBaseRepository)
        {
            _db = db;
            _dapperBaseRepository = dapperBaseRepository;
        }
        public bool Add(TimeSlot timeSlot)
        {
            string sqlcommand = "AddTimeSlot";
            var parameters = new { timeSlot.TimeSlot1 };
            var results = _dapperBaseRepository.Execute(sqlcommand, parameters);
            return results == 0;
        }
        public bool Delete(object id)
        {
            string sqlcommand = "DeleteTimeslot";
            var parameter = new { id };
            var results = _dapperBaseRepository.Execute(sqlcommand, parameter);
            return results == 0;
        }
        public IQueryable<TimeSlot> GetAll()
        {
            string sqlcommand = "GetTimeSlot";
            return _dapperBaseRepository.Query<TimeSlot>(sqlcommand);
        }

   
        public TimeSlot GetSingleRecord(object id)
        {
            string command = "[GetSingleTime]";
            var parameter = new { id };
            return _dapperBaseRepository.QuerySingl<TimeSlot>(command, parameter);
        }

        public bool Update(TimeSlot timeSlot)
        {
            string sqlcommand = "UpdateTimeSlot";
            var parameters = new { timeSlot.TimeId, timeSlot.TimeSlot1 };
            var results = _dapperBaseRepository.Execute(sqlcommand, parameters);
            return results == 0;
        }
    }
}
