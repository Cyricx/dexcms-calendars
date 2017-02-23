using DexCMS.Calendars.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Calendars.Initializers.Helpers
{
    public class CalendarEventStatusReference
    {
        public int Tentative { get; set; }
        public int Confirmed { get; set; }

        public CalendarEventStatusReference(IDexCMSCalendarsContext Context)
        {
            Tentative = Context.CalendarEventStatuses.Where(x => x.Name == "Tentative").Select(x => x.CalendarEventStatusID).SingleOrDefault();
            Confirmed = Context.CalendarEventStatuses.Where(x => x.Name == "Confirmed").Select(x => x.CalendarEventStatusID).SingleOrDefault();
        }
    }
}
