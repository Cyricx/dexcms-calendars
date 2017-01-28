using DexCMS.Calendars.Contexts;
using DexCMS.Calendars.Models;
using DexCMS.Core.Extensions;
using DexCMS.Core.Globals;

namespace DexCMS.Calendars.Initializers
{
    public class CalendarInitializer : DexCMSInitializer<IDexCMSCalendarsContext>
    {
        public CalendarInitializer(IDexCMSCalendarsContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            Context.Calendars.AddIfNotExists(x => x.Title,
                new Calendar { Title = "Public", IsActive = true });
            Context.SaveChanges();
        }
    }
}
