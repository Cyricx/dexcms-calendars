using Ninject;
using DexCMS.Calendars.Contexts;
using DexCMS.Calendars.Repositories;
using DexCMS.Calendars.Interfaces;

namespace DexCMS.Calendars.Globals
{
    public static class CalendarsRegister<T> where T : IDexCMSCalendarsContext
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICalendarRepository>().To<CalendarRepository>();
            kernel.Bind<ICalendarEventRepository>().To<CalendarEventRepository>();
            kernel.Bind<ICalendarEventStatusRepository>().To<CalendarEventStatusRepository>();
            kernel.Bind<ICalendarEventTypeRepository>().To<CalendarEventTypeRepository>();
            kernel.Bind<ICalendarRepeatDayRepository>().To<CalendarRepeatDayRepository>();
            kernel.Bind<ICalendarRepeatTypeRepository>().To<CalendarRepeatTypeRepository>();
            kernel.Bind<ICalendarEventLocationRepository>().To<CalendarEventLocationRepository>();
            kernel.Bind<IDexCMSCalendarsContext>().To<T>();
        }
    }
}
