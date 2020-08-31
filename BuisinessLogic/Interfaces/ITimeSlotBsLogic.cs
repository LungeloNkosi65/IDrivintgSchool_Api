using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogic.Interfaces
{
   public interface ITimeSlotBsLogic
    {
        bool CheckTime(TimeSpan selectedTime);
        bool CheckDate(DateTime selectedDate);

    }
}
