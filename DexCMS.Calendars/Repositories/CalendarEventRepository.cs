using System;
using System.Collections.Generic;
using System.Linq;
using DexCMS.Core.Repositories;
using DexCMS.Calendars.Models;
using DexCMS.Calendars.Interfaces;
using DexCMS.Core.Contexts;
using DexCMS.Calendars.Contexts;

namespace DexCMS.Calendars.Repositories
{
    public class CalendarEventRepository : AbstractRepository<CalendarEvent>, ICalendarEventRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSCalendarsContext _ctx { get; set; }

        public CalendarEventRepository(IDexCMSCalendarsContext ctx)
        {
            _ctx = ctx;
        }

        public List<CalendarEvent> GetDayEvents(int calendarID, DateTime date, int timezoneOffset)
        {
           // int timezoneOffset = int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["ServerTimezoneOffset"]);

            var events = from evt in _ctx.CalendarEvents.Where(c => c.CalendarID == calendarID).ToList()
                         where
                            evt.IsDisabled != true
                            &&
                            (
                                //starts on this date
                                evt.StartDate.AddHours(timezoneOffset).Date == date.Date ||
                                //ends on this date
                                (evt.EndDate.HasValue && evt.EndDate.Value.AddHours(timezoneOffset).Date == date.Date
                                //and it is still going after noon
                                //&& evt.EndDate.Value.AddHours(timezoneOffset).Hour  > 12
                                )

                                ||
                                //started before this date and ends after this date
                                (evt.StartDate.AddHours(timezoneOffset).Date < date.Date && evt.EndDate.HasValue && evt.EndDate.Value.AddHours(-5).Date > date.Date)
                            )
                         select evt;
            return events.ToList();
        }

    }
}
