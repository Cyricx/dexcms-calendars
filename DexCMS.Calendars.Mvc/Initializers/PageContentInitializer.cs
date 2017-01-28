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
using DexCMS.Base.Initializers.Helpers;

namespace DexCMS.Calendars.Mvc.Initializers
{
    class PageContentInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        private AreasReference Areas;
        private CategoriesReference Categories;
        private PageTypesReference PageTypes;
        private LayoutTypesReference LayoutTypes;

        public PageContentInitializer(IDexCMSBaseContext context) : base(context)
        {
            Areas = new AreasReference(context);
            PageTypes = new PageTypesReference(context);
            LayoutTypes = new LayoutTypesReference(context);
        }

        public override void Run(bool addDemoContent = true)
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
                    ContentAreaID = Areas.Public,
                    ContentCategoryID = null,
                    UrlSegment = "calendar",
                    PageTypeID = PageTypes.SiteContent,
                    LayoutTypeID = LayoutTypes.OneColumn,
                    IsDisabled = false,
                    RequiresLogin = false
                }
            );
            Context.SaveChanges();
        }
    }
}
