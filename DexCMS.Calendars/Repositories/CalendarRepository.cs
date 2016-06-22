using DexCMS.Core.Infrastructure.Repositories;
using DexCMS.Calendars.Models;
using DexCMS.Calendars.Interfaces;
using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Calendars.Contexts;

namespace DexCMS.Calendars.Repositories
{
    public class CalendarRepository : AbstractRepository<Calendar>, ICalendarRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSCalendarsContext _ctx { get; set; }

        public CalendarRepository(IDexCMSCalendarsContext ctx)
        {
            _ctx = ctx;
        }
    }
}
