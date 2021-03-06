﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Calendars.WebApi.ApiModels
{

    public class CalendarEventTypeApiModel
    {
        public int CalendarEventTypeID { get; set; }

        public string Name { get; set; }

        public string CssClass { get; set; }

        public bool IsActive { get; set; }
        public int CalendarEventCount { get; set; }

    }
}
