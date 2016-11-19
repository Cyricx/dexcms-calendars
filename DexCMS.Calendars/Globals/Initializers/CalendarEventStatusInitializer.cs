using DexCMS.Calendars.Contexts;
using DexCMS.Calendars.Models;
using DexCMS.Core.Infrastructure.Globals;
using System.Data.Entity.Migrations;

namespace DexCMS.Calendars.Globals.Initializers
{
    class CalendarEventStatusInitializer : DexCMSInitializer<IDexCMSCalendarsContext>
    {
        public CalendarEventStatusInitializer(IDexCMSCalendarsContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.CalendarEventStatuses.AddOrUpdate(x => x.Name,
                new CalendarEventStatus { Name = "Tentative", CssClass = "tentative", IsActive = true },
                new CalendarEventStatus { Name = "Confirmed", CssClass = "confirmed", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
