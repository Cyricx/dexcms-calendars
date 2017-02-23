using DexCMS.Calendars.Contexts;
using DexCMS.Calendars.Models;
using DexCMS.Core.Globals;
using System.Data.Entity.Migrations;

namespace DexCMS.Calendars.Initializers
{
    class CalendarEventLocationInitializer : DexCMSInitializer<IDexCMSCalendarsContext>
    {
        public CalendarEventLocationInitializer(IDexCMSCalendarsContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            if (addDemoContent)
            {
                Context.CalendarEventLocations.AddOrUpdate(x => x.Name,
                    new CalendarEventLocation { Name = "Place1", IsActive = true },
                    new CalendarEventLocation { Name = "Place2", IsActive = true }
                );
                Context.SaveChanges();
            }
        }
    }
}
