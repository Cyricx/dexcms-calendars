using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Calendars.Interfaces;
using DexCMS.Calendars.Models;
using DexCMS.Calendars.WebApi.ApiModels;
using DexCMS.Core.Extensions;

namespace DexCMS.Calendars.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CalendarEventLocationsController : ApiController
    {
		private ICalendarEventLocationRepository repository;

		public CalendarEventLocationsController(ICalendarEventLocationRepository repo) 
		{
			repository = repo;
		}

        // GET api/CalendarEventLocation
        public List<CalendarEventLocationApiModel> GetCalendarEventLocationes()
        {
            var items = repository.Items.Select(x => new CalendarEventLocationApiModel {
                CalendarEventLocationID = x.CalendarEventLocationID,
                Name = x.Name,
                AdditionalDetails = x.AdditionalDetails,
                IsActive = x.IsActive,
                DisplayOrder = x.DisplayOrder,
                MapIconImage = x.MapIconImage,
                MapXCoordinate = x.MapXCoordinate,
                MapYCoordinate = x.MapYCoordinate,
                CalendarEventCount = x.CalendarEvents.Count
			}).ToList();

			return items;
        }

        // GET api/CalendarEventLocation/5
        [ResponseType(typeof(CalendarEventLocation))]
        public async Task<IHttpActionResult> GetCalendarEventLocation(int id)
        {
			CalendarEventLocation calendarEventLocation = await repository.RetrieveAsync(id);
            if (calendarEventLocation == null)
            {
                return NotFound();
            }

			CalendarEventLocationApiModel model = new CalendarEventLocationApiModel()
			{
				CalendarEventLocationID = calendarEventLocation.CalendarEventLocationID,
				Name = calendarEventLocation.Name,
                AdditionalDetails = calendarEventLocation.AdditionalDetails,
                IsActive = calendarEventLocation.IsActive,
                DisplayOrder = calendarEventLocation.DisplayOrder,
                MapIconImage = calendarEventLocation.MapIconImage,
                MapXCoordinate = calendarEventLocation.MapXCoordinate,
                MapYCoordinate = calendarEventLocation.MapYCoordinate,
                CalendarEventCount = calendarEventLocation.CalendarEvents.Count
			};

            return Ok(model);
        }

        // PUT api/CalendarEventLocation/5
        public async Task<IHttpActionResult> PutCalendarEventLocation(int id, CalendarEventLocation calendarEventLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendarEventLocation.CalendarEventLocationID)
            {
                return BadRequest();
            }
            if (!String.IsNullOrEmpty(calendarEventLocation.ReplacementFileName))
            {
                SaveFile(calendarEventLocation);
            }
            await repository.UpdateAsync(calendarEventLocation, calendarEventLocation.CalendarEventLocationID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/CalendarEventLocation
        [ResponseType(typeof(CalendarEventLocation))]
        public async Task<IHttpActionResult> PostCalendarEventLocation(CalendarEventLocation calendarEventLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(calendarEventLocation);

            if (!string.IsNullOrEmpty(calendarEventLocation.ReplacementFileName))
            {
                SaveFile(calendarEventLocation);
            }
            await repository.UpdateAsync(calendarEventLocation, calendarEventLocation.CalendarEventLocationID);

            return CreatedAtRoute("DefaultApi", new { id = calendarEventLocation.CalendarEventLocationID }, calendarEventLocation);
        }

        // DELETE api/CalendarEventLocation/5
        [ResponseType(typeof(CalendarEventLocation))]
        public async Task<IHttpActionResult> DeleteCalendarEventLocation(int id)
        {
			CalendarEventLocation calendarEventLocation = await repository.RetrieveAsync(id);
            if (calendarEventLocation == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(calendarEventLocation);

            return Ok(calendarEventLocation);
        }

        private void SaveFile(CalendarEventLocation item)
        {
            int id = item.CalendarEventLocationID;
            string uploadFolderName = "content/calendarEventLocations/" + id + "/";

            string uploadFolder = HostingEnvironment.MapPath("~/" + uploadFolderName);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string pictureName = item.Name.Clean();
            string extension = item.ReplacementFileName.Substring(item.ReplacementFileName.LastIndexOf('.'));

            if (item.MapIconImage != null)
            {
                DeleteLayoutTypeFiles(item);
            }

            //let's make sure alt is unique
            string newName = item.Name;
            GenerateUniqueName(uploadFolderName, uploadFolder, ref pictureName, extension, ref newName);
            item.Name = newName;

            //Retrieve file
            var file = System.Web.HttpContext.Current.Server.MapPath("~/Tmp/FileUploads/" + item.TemporaryFileName);

            //remove special characters from file name
            string fileName = pictureName + extension;

            string fullfilePath = Path.Combine(uploadFolder, fileName);

            File.Copy(file, fullfilePath);

            File.Delete(file);
            item.MapIconImage = uploadFolderName + fileName;
        }

        private static void GenerateUniqueName(string uploadFolderName, string uploadFolder, ref string pictureName, string extension, ref string newName)
        {
            //layoutType doesn't exist, let's make sure it is unique
            int? appendNumber = null;
            bool foundUnused = false;
            do
            {
                //let's make sure the new layoutType we are about to save doesn't already exist
                string testFile = uploadFolderName + pictureName + appendNumber + extension;

                //save file path
                string testPath = Path.Combine(uploadFolder,
                    Path.GetFileName(testFile));

                //test if file exists, if so, increment the number and repeat the loop
                if (File.Exists(testPath))
                {
                    if (appendNumber != null)
                    {
                        appendNumber++;
                    }
                    else
                    {
                        appendNumber = 1;
                    }
                }
                else
                {
                    //file does not exist, so we have a unique name to use
                    pictureName += appendNumber;
                    foundUnused = true;
                    newName += appendNumber;
                }
            } while (!foundUnused);
        }

        private void DeleteLayoutTypeFiles(CalendarEventLocation item)
        {
            DeleteFile(item.MapIconImage);
        }

        private void DeleteFile(string file)
        {
            if (!String.IsNullOrEmpty(file))
            {
                string oldFile = HostingEnvironment.MapPath("~/" + file);
                if (File.Exists(oldFile))
                {
                    File.Delete(oldFile);
                }
            }
        }


    }
}