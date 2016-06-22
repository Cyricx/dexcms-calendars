using System;
using System.Collections.Generic;
using DexCMS.Calendars.Models;
using DexCMS.Core.Infrastructure.Interfaces;

namespace DexCMS.Calendars.Interfaces
{
    public interface ICalendarEventRepository : IRepository<CalendarEvent>
    {
        List<CalendarEvent> GetDayEvents(int calendarID, DateTime date, int timezoneOffset);
    }
}
