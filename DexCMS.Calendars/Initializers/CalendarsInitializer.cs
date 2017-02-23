using System;
using System.Collections.Generic;
using DexCMS.Calendars.Contexts;
using DexCMS.Core.Globals;

namespace DexCMS.Calendars.Initializers
{
    public class CalendarsInitializer : DexCMSLibraryInitializer<IDexCMSCalendarsContext>
    {
        public CalendarsInitializer(IDexCMSCalendarsContext context) : base(context)
        {
        }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>
                {
                    typeof(CalendarInitializer),
                    typeof(CalendarEventStatusInitializer),
                    typeof(CalendarEventLocationInitializer),
                    typeof(CalendarRepeatDayInitializer),
                    typeof(CalendarRepeatTypeInitializer),
                    typeof(CalendarEventInitializer)
                };
            }
        }
    }
}
