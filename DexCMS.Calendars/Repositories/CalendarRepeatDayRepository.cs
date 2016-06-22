using DexCMS.Core.Infrastructure.Repositories;
using DexCMS.Calendars.Models;
using DexCMS.Calendars.Interfaces;
using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Calendars.Contexts;

namespace DexCMS.Calendars.Repositories
{
    public class CalendarRepeatDayRepository : AbstractRepository<CalendarRepeatDay>, ICalendarRepeatDayRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSCalendarsContext _ctx { get; set; }

        public CalendarRepeatDayRepository(IDexCMSCalendarsContext ctx)
        {
            _ctx = ctx;
        }
    }
}
