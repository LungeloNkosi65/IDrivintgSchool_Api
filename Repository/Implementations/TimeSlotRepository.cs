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
        public void Add(TimeSlot timeSlot)
        {
            _db.TimeSlot.Add(timeSlot);
            _db.SaveChanges();
        }

        public IQueryable<TimeSlot> BookingDetails(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? timeId)
        {
            var dbRecord = Find(timeId);
            _db.TimeSlot.Remove(dbRecord);
            _db.SaveChanges();
        }

        public void Delete(object id)
        {
            var dbRecord = Find(id);
            _db.TimeSlot.Remove(dbRecord);
            _db.SaveChanges();
        }

        public TimeSlot Find(int? timeId)
        {
            return _db.TimeSlot.Find(timeId);
        }

        public TimeSlot Find(object id)
        {
            return _db.TimeSlot.Find(id);
        }

        public IQueryable<TimeSlot> GetAll()
        {
            return _db.TimeSlot.AsQueryable();
        }

        public IQueryable<TimeSlot> GetSingleRecord(int? timeId)
        {
            string command = "[GetSingleTime]";
            var parameter = new { timeId };
            return _dapperBaseRepository.QuerySingl<TimeSlot>(command, parameter);
        }

        public IQueryable<TimeSlot> GetSingleRecord(object id)
        {
            string command = "[GetSingleTime]";
            var parameter = new { id };
            return _dapperBaseRepository.QuerySingl<TimeSlot>(command, parameter);
        }

        public void Update(TimeSlot timeSlot)
        {
            _db.Entry(timeSlot).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
