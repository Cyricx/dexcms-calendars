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
    public class CalendarsController : ApiController
    {
		private ICalendarRepository repository;

		public CalendarsController(ICalendarRepository repo) 
		{
			repository = repo;
		}

        // GET api/Calendars
        public List<CalendarApiModel> GetCalendars()
        {
			var items = repository.Items.Select(x => new CalendarApiModel {
				CalendarID = x.CalendarID,
				Title = x.Title,
				IsActive = x.IsActive,
                CalendarEventCount = x.CalendarEvents.Count
			}).ToList();

			return items;
        }

        // GET api/Calendars/5
        [ResponseType(typeof(Calendar))]
        public async Task<IHttpActionResult> GetCalendar(int id)
        {
			Calendar calendar = await repository.RetrieveAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }

			CalendarApiModel model = new CalendarApiModel()
			{
				CalendarID = calendar.CalendarID,
				Title = calendar.Title,
				IsActive = calendar.IsActive,
			    CalendarEventCount = calendar.CalendarEvents.Count
			};

            return Ok(model);
        }

        // PUT api/Calendars/5
        public async Task<IHttpActionResult> PutCalendar(int id, Calendar calendar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendar.CalendarID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(calendar, calendar.CalendarID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Calendars
        [ResponseType(typeof(Calendar))]
        public async Task<IHttpActionResult> PostCalendar(Calendar calendar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(calendar);

            return CreatedAtRoute("DefaultApi", new { id = calendar.CalendarID }, calendar);
        }

        // DELETE api/Calendars/5
        [ResponseType(typeof(Calendar))]
        public async Task<IHttpActionResult> DeleteCalendar(int id)
        {
			Calendar calendar = await repository.RetrieveAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(calendar);

            return Ok(calendar);
        }

    }



}