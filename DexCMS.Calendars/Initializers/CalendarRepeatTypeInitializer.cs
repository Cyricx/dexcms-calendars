using DexCMS.Calendars.Contexts;
using DexCMS.Calendars.Models;
using DexCMS.Core.Globals;
using System.Data.Entity.Migrations;

namespace DexCMS.Calendars.Initializers
{
    class CalendarRepeatTypeInitializer : DexCMSInitializer<IDexCMSCalendarsContext>
    {
        public CalendarRepeatTypeInitializer(IDexCMSCalendarsContext context) : base(context)
        {
        }
        public override void Run(bool addDemoContent = true)
        {
            Context.CalendarRepeatTypes.AddOrUpdate(x => x.Name,
                new CalendarRepeatType { Name = "Daily", IsActive = true },
                new CalendarRepeatType { Name = "Weekly", IsActive = true },
                new CalendarRepeatType { Name = "Monthly", IsActive = true },
                new CalendarRepeatType { Name = "Yearly", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
