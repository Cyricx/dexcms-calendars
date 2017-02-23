using DexCMS.Calendars.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Calendars.Initializers.Helpers
{
    public class CalendarEventLocationReference
    {
        public int Place1 { get; set; }
        public int Place2 { get; set; }

        public CalendarEventLocationReference(IDexCMSCalendarsContext Context)
        {
            Place1 = Context.CalendarEventLocations.Where(x => x.Name == "Place1").Select(x => x.CalendarEventLocationID).SingleOrDefault();
            Place2 = Context.CalendarEventLocations.Where(x => x.Name == "Place2").Select(x => x.CalendarEventLocationID).SingleOrDefault();
        }
    }
}
