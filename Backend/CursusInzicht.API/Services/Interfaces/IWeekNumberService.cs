using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusInzicht.API.Services.Interfaces
{
    public interface IWeekNumberService
    {
        DateTime FirstDateOfWeekISO8601(int year, int weekOfYear);
        int GetIso8601WeekOfYear(DateTime time);
    }
}
