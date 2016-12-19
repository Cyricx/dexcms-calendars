using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Calendars.Interfaces;
using DexCMS.Calendars.Models;
using DexCMS.Calendars.WebApi.ApiModels;

namespace DexCMS.Calendars.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CalendarEventsController : ApiController
    {
		private ICalendarEventRepository repository;

		public CalendarEventsController(ICalendarEventRepository repo) 
		{
			repository = repo;
		}

        // GET api/CalendarEvents
        public List<CalendarEventApiModel> GetCalendarEvents()
        {
            var items = new List<CalendarEventApiModel>();

            foreach (var x in repository.Items.ToList())
            {
                items.Add(new CalendarEventApiModel
                {
                    CalendarEventID = x.CalendarEventID,
                    Title = x.Title,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate, 
                    Location = x.Location,
                    CalendarEventLocationID = x.CalendarEventLocationID,
                    CalendarEventLocationName = (x.CalendarEventLocationID.HasValue ? x.CalendarEventLocation.Name : ""),
                    Details = x.Details,
                    CalendarEventTypeID = x.CalendarEventTypeID,
                    CalendarEventTypeName = x.CalendarEventTypeID.HasValue ? x.CalendarEventType.Name : "",
                    CalendarEventStatusID = x.CalendarEventStatusID,
                    CalendarEventStatusName = x.CalendarEventStatus.Name,
                    IsRepeating = x.IsRepeating,
                    IsAllDay = x.IsAllDay,
                    CssClass = x.CssClass,
                    EventURL = x.EventURL,
                    CalendarRepeatTypeID = x.CalendarRepeatTypeID,
                    RepeatCount = x.RepeatCount,
                    RepeatCountEnd = x.RepeatCountEnd,
                    RepeatEndDate = x.RepeatEndDate,
                    CalendarID = x.CalendarID,
                    IsDisabled = x.IsDisabled
                });
                }

                return items;
        }

        // GET api/CalendarEvents/5
        [ResponseType(typeof(CalendarEvent))]
        public async Task<IHttpActionResult> GetCalendarEvent(int id)
        {
			CalendarEvent calendarEvent = await repository.RetrieveAsync(id);
            if (calendarEvent == null)
            {
                return NotFound();
            }
            int timezoneOffset = int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["ServerTimezoneOffset"]);

            CalendarEventApiModel model = new CalendarEventApiModel()
            {
                CalendarEventID = calendarEvent.CalendarEventID,
                Title = calendarEvent.Title,
                StartDate = calendarEvent.StartDate,
                EndDate = calendarEvent.EndDate,
                Location = calendarEvent.Location,
                CalendarEventLocationID = calendarEvent.CalendarEventLocationID,
                CalendarEventLocationName = (calendarEvent.CalendarEventLocationID.HasValue ? calendarEvent.CalendarEventLocation.Name : ""),
                Details = calendarEvent.Details,
				CalendarEventTypeID = calendarEvent.CalendarEventTypeID,
                CalendarEventTypeName = calendarEvent.CalendarEventType.Name,
				CalendarEventStatusID = calendarEvent.CalendarEventStatusID,
                CalendarEventStatusName = calendarEvent.CalendarEventStatus.Name,
				IsRepeating = calendarEvent.IsRepeating,
				IsAllDay = calendarEvent.IsAllDay,
				CssClass = calendarEvent.CssClass,
				EventURL = calendarEvent.EventURL,
				CalendarRepeatTypeID = calendarEvent.CalendarRepeatTypeID,
				RepeatCount = calendarEvent.RepeatCount,
				RepeatCountEnd = calendarEvent.RepeatCountEnd,
				RepeatEndDate = calendarEvent.RepeatEndDate,
				CalendarID = calendarEvent.CalendarID,
                IsDisabled = calendarEvent.IsDisabled
            };

            return Ok(model);
        }

        // PUT api/CalendarEvents/5
        public async Task<IHttpActionResult> PutCalendarEvent(int id, CalendarEvent calendarEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendarEvent.CalendarEventID)
            {
                return BadRequest();
            }

            await repository.UpdateAsync(calendarEvent, calendarEvent.CalendarEventID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/CalendarEvents
        [ResponseType(typeof(CalendarEvent))]
        public async Task<IHttpActionResult> PostCalendarEvent(CalendarEvent calendarEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(calendarEvent);

            return CreatedAtRoute("DefaultApi", new { id = calendarEvent.CalendarEventID }, calendarEvent);
        }

        // DELETE api/CalendarEvents/5
        [ResponseType(typeof(CalendarEvent))]
        public async Task<IHttpActionResult> DeleteCalendarEvent(int id)
        {
			CalendarEvent calendarEvent = await repository.RetrieveAsync(id);
            if (calendarEvent == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(calendarEvent);

            return Ok(calendarEvent);
        }

    }



}