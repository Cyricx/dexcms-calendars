using DexCMS.Calendars.Contexts;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Calendars.Initializers
{
    public class CalendarsInitializer : DexCMSInitializer<IDexCMSCalendarsContext>
    {
        public CalendarsInitializer(IDexCMSCalendarsContext context) : base(context)
        {
        }

        public override void Run()
        {
            (new CalendarEventStatusInitializer(Context)).Run();
            (new CalendarRepeatDayInitializer(Context)).Run();
            (new CalendarRepeatTypeInitializer(Context)).Run();
        }
    }
}
