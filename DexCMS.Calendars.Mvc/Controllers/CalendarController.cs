using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using DexCMS.Calendars.Interfaces;
using System.Web.Configuration;
using DexCMS.Calendars.Mvc.Models;
using DexCMS.Core.Mvc.Globals;

namespace DexCMS.Calendars.Mvc.Controllers
{
    public class CalendarController : DexCMSController
    {
        private ICalendarRepository repository;
        private ICalendarEventRepository eventRepository;

        public CalendarController(ICalendarRepository repo, ICalendarEventRepository eventrepo)
        {
            repository = repo;
            eventRepository = eventrepo;
        }

        // GET: /Calendar/
        public ActionResult Index()
        {
            return View(repository.Items.ToList());
        }

        public JsonResult GetEvents(string start, string end)
        {
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);

            int timezoneOffset = int.Parse(WebConfigurationManager.AppSettings["ServerTimezoneOffset"]);

            var events = (from x in eventRepository.Items.ToList()
                          where x.CalendarID == 1
                          && (x.EndDate >= startDate
                          || (x.StartDate >= startDate
                          && x.StartDate <= endDate))
                          select new DisplayEvent
                          {
                              id = x.CalendarEventID,
                              title = x.Title,
                              start = x.StartDate.ToString("MM/dd/yyyy hh:mm tt"),
                              end = x.EndDate.HasValue ? x.EndDate.Value.ToString("MM/dd/yyyy hh:mm tt") : "",
                              allDay = x.IsAllDay,
                              location = x.Location,
                              details = x.Details,
                              className = x.CssClass,
                              status = x.CalendarEventStatus.Name,
                              type = x.CalendarEventTypeID.HasValue ? x.CalendarEventType.Name : ""
                          }).ToList();


            return Json(events, JsonRequestBehavior.AllowGet);

        }
    }
}
