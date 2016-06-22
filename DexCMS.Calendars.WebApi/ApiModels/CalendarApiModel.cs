using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Calendars.WebApi.ApiModels
{
    public class CalendarApiModel
    {
        public int CalendarID { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public int CalendarEventCount { get; set; }

    }
}
