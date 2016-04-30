using System;
using System.Globalization;

namespace WebUI.Infrastructure
{
    public class WeekProvider : IWeekProvider
    {
        public int GetWeek()
        {
            return Calendar.ReadOnly(new GregorianCalendar())
                .GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
    }
}