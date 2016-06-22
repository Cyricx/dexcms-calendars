using System.Data.Entity;
using DexCMS.Calendars.Models;
using DexCMS.Core.Infrastructure.Contexts;

namespace DexCMS.Calendars.Contexts
{
    public interface IDexCMSCalendarsContext: IDexCMSContext
    {
        DbSet<Calendar> Calendars { get; set; }
        DbSet<CalendarEvent> CalendarEvents { get; set; }
        DbSet<CalendarEventStatus> CalendarEventStatuses { get; set; }
        DbSet<CalendarEventLocation> CalendarEventLocations { get; set; }
        DbSet<CalendarEventType> CalendarEventTypes { get; set; }
        DbSet<CalendarRepeatDay> CalendarRepeatDays { get; set; }
        DbSet<CalendarRepeatType> CalendarRepeatTypes { get; set; }
    }
}
