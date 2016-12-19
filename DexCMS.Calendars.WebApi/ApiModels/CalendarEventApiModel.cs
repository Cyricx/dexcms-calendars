using System;

namespace DexCMS.Calendars.WebApi.ApiModels
{
    public class CalendarEventApiModel
    {
        public int CalendarEventID { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Location { get; set; }
        public int? CalendarEventLocationID { get; set; }
        public string CalendarEventLocationName { get; set; }

        public string Details { get; set; }

        public int? CalendarEventTypeID { get; set; }
        public string CalendarEventTypeName { get; set; }

        public int CalendarEventStatusID { get; set; }
        public string CalendarEventStatusName { get; set; }

        public bool IsRepeating { get; set; }

        public bool IsAllDay { get; set; }

        public string CssClass { get; set; }

        public string EventURL { get; set; }

        public int? CalendarRepeatTypeID { get; set; }

        public int? RepeatCount { get; set; }

        public int? RepeatCountEnd { get; set; }

        public DateTime? RepeatEndDate { get; set; }

        public int CalendarID { get; set; }

        public bool Disabled { get; set; }

    }
}
