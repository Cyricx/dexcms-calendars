using DexCMS.Core.Repositories;
using DexCMS.Calendars.Models;
using DexCMS.Calendars.Interfaces;
using DexCMS.Core.Contexts;
using DexCMS.Calendars.Contexts;

namespace DexCMS.Calendars.Repositories
{
    public class CalendarRepeatTypeRepository : AbstractRepository<CalendarRepeatType>, ICalendarRepeatTypeRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSCalendarsContext _ctx { get; set; }

        public CalendarRepeatTypeRepository(IDexCMSCalendarsContext ctx)
        {
            _ctx = ctx;
        }
    }
}
