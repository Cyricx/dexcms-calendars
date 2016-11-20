using DexCMS.Calendars.Contexts;
using DexCMS.Calendars.Models;
using DexCMS.Core.Infrastructure.Globals;
using System.Data.Entity.Migrations;

namespace DexCMS.Calendars.Initializers
{
    class CalendarRepeatDayInitializer : DexCMSInitializer<IDexCMSCalendarsContext>
    {
        public CalendarRepeatDayInitializer(IDexCMSCalendarsContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.CalendarRepeatDays.AddOrUpdate(x => x.Name,
                new CalendarRepeatDay { Name = "Sunday", IsActive = true },
                new CalendarRepeatDay { Name = "Monday", IsActive = true },
                new CalendarRepeatDay { Name = "Tuesday", IsActive = true },
                new CalendarRepeatDay { Name = "Wednesday", IsActive = true },
                new CalendarRepeatDay { Name = "Thursday", IsActive = true },
                new CalendarRepeatDay { Name = "Friday", IsActive = true },
                new CalendarRepeatDay { Name = "Saturday", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
