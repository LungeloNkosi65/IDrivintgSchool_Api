using BuisinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogic.Implementations
{
    class TimeSlotBsLogic : ITimeSlotBsLogic
    {
        public bool CheckDate(DateTime selectedDate)
        {
            bool results = false;
            if (selectedDate <= DateTime.Now)
            {
                results = true;
            }
            return results;
        }

        public bool CheckTime(TimeSpan selectedTime)
        {
            throw new NotImplementedException();
        }
    }
}
