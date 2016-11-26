using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Calendars.Contexts;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Core.Infrastructure.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Calendars.Mvc.Initializers
{
    class PageContentInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        public PageContentInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            DateTime Today = DateTime.Now;
            int Public = Context.ContentAreas.Where(x => x.Name == "Public").Select(x => x.ContentAreaID).Single();
            int SiteContent = Context.PageTypes.Where(x => x.Name == "Site Content").Select(x => x.PageTypeID).Single();

            Context.PageContents.AddIfNotExists(x => x.PageTitle,
                new PageContent
                {
                    Body = "",
                    PageTitle = "Calendar",
                    ChangeFrequency = 0,
                    LastModified = Today,
                    AddToSitemap = false,
                    Heading = "Calendar",
                    ContentAreaID = Public,
                    ContentCategoryID = null,
                    UrlSegment = "calendar",
                    PageTypeID = SiteContent
                }
            );
            Context.SaveChanges();
        }
    }
}
