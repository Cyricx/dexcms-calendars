using DexCMS.Calendars.Contexts;
using DexCMS.Calendars.Models;
using DexCMS.Core.Globals;
using System.Data.Entity.Migrations;

namespace DexCMS.Calendars.Initializers
{
    class CalendarEventStatusInitializer : DexCMSInitializer<IDexCMSCalendarsContext>
    {
        public CalendarEventStatusInitializer(IDexCMSCalendarsContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            Context.CalendarEventStatuses.AddOrUpdate(x => x.Name,
                new CalendarEventStatus { Name = "Tentative", CssClass = "tentative", IsActive = true },
                new CalendarEventStatus { Name = "Confirmed", CssClass = "confirmed", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
