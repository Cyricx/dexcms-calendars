using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Calendars.Interfaces;
using DexCMS.Calendars.Models;
using DexCMS.Calendars.WebApi.ApiModels;

namespace DexCMS.Calendars.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CalendarEventTypesController : ApiController
    {
		private ICalendarEventTypeRepository repository;

		public CalendarEventTypesController(ICalendarEventTypeRepository repo) 
		{
			repository = repo;
		}

        // GET api/CalendarEventTypes
        public List<CalendarEventTypeApiModel> GetCalendarEventTypes()
        {
			var items = repository.Items.Select(x => new CalendarEventTypeApiModel {
				CalendarEventTypeID = x.CalendarEventTypeID,
				Name = x.Name,
				CssClass = x.CssClass,
				IsActive = x.IsActive,
                CalendarEventCount = x.CalendarEvents.Count
			}).ToList();

			return items;
        }

        // GET api/CalendarEventTypes/5
        [ResponseType(typeof(CalendarEventType))]
        public async Task<IHttpActionResult> GetCalendarEventType(int id)
        {
			CalendarEventType calendarEventType = await repository.RetrieveAsync(id);
            if (calendarEventType == null)
            {
                return NotFound();
            }

			CalendarEventTypeApiModel model = new CalendarEventTypeApiModel()
			{
				CalendarEventTypeID = calendarEventType.CalendarEventTypeID,
				Name = calendarEventType.Name,
				CssClass = calendarEventType.CssClass,
				IsActive = calendarEventType.IsActive,
                CalendarEventCount = calendarEventType.CalendarEvents.Count
			
			};

            return Ok(model);
        }

        // PUT api/CalendarEventTypes/5
        public async Task<IHttpActionResult> PutCalendarEventType(int id, CalendarEventType calendarEventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendarEventType.CalendarEventTypeID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(calendarEventType, calendarEventType.CalendarEventTypeID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/CalendarEventTypes
        [ResponseType(typeof(CalendarEventType))]
        public async Task<IHttpActionResult> PostCalendarEventType(CalendarEventType calendarEventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(calendarEventType);

            return CreatedAtRoute("DefaultApi", new { id = calendarEventType.CalendarEventTypeID }, calendarEventType);
        }

        // DELETE api/CalendarEventTypes/5
        [ResponseType(typeof(CalendarEventType))]
        public async Task<IHttpActionResult> DeleteCalendarEventType(int id)
        {
			CalendarEventType calendarEventType = await repository.RetrieveAsync(id);
            if (calendarEventType == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(calendarEventType);

            return Ok(calendarEventType);
        }

    }


}