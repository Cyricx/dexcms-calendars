using DexCMS.Calendars.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Calendars.Initializers.Helpers
{
    public class CalendarReference
    {
        public int Public { get; set; }

        public CalendarReference(IDexCMSCalendarsContext Context)
        {
            Public = Context.Calendars.Where(x => x.Title == "Public").Select(x => x.CalendarID).SingleOrDefault();
        }
    }
}
