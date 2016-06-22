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
    public class CalendarEventStatusController : ApiController
    {
		private ICalendarEventStatusRepository repository;

		public CalendarEventStatusController(ICalendarEventStatusRepository repo) 
		{
			repository = repo;
		}

        // GET api/CalendarEventStatus
        public List<CalendarEventStatusApiModel> GetCalendarEventStatuses()
        {
			var items = repository.Items.Select(x => new CalendarEventStatusApiModel {
				CalendarEventStatusID = x.CalendarEventStatusID,
				Name = x.Name,
				CssClass = x.CssClass,
				IsActive = x.IsActive,
                CalendarEventCount = x.CalendarEvents.Count
			}).ToList();

			return items;
        }

        // GET api/CalendarEventStatus/5
        [ResponseType(typeof(CalendarEventStatus))]
        public async Task<IHttpActionResult> GetCalendarEventStatus(int id)
        {
			CalendarEventStatus calendarEventStatus = await repository.RetrieveAsync(id);
            if (calendarEventStatus == null)
            {
                return NotFound();
            }

			CalendarEventStatusApiModel model = new CalendarEventStatusApiModel()
			{
				CalendarEventStatusID = calendarEventStatus.CalendarEventStatusID,
				Name = calendarEventStatus.Name,
				CssClass = calendarEventStatus.CssClass,
				IsActive = calendarEventStatus.IsActive,
			    CalendarEventCount = calendarEventStatus.CalendarEvents.Count
			};

            return Ok(model);
        }

        // PUT api/CalendarEventStatus/5
        public async Task<IHttpActionResult> PutCalendarEventStatus(int id, CalendarEventStatus calendarEventStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendarEventStatus.CalendarEventStatusID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(calendarEventStatus, calendarEventStatus.CalendarEventStatusID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/CalendarEventStatus
        [ResponseType(typeof(CalendarEventStatus))]
        public async Task<IHttpActionResult> PostCalendarEventStatus(CalendarEventStatus calendarEventStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(calendarEventStatus);

            return CreatedAtRoute("DefaultApi", new { id = calendarEventStatus.CalendarEventStatusID }, calendarEventStatus);
        }

        // DELETE api/CalendarEventStatus/5
        [ResponseType(typeof(CalendarEventStatus))]
        public async Task<IHttpActionResult> DeleteCalendarEventStatus(int id)
        {
			CalendarEventStatus calendarEventStatus = await repository.RetrieveAsync(id);
            if (calendarEventStatus == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(calendarEventStatus);

            return Ok(calendarEventStatus);
        }

    }



}