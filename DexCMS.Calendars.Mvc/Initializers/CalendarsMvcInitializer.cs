using System;
using System.Collections.Generic;
using DexCMS.Base.Contexts;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Calendars.Mvc.Initializers
{
    public class CalendarsMvcInitializer : DexCMSLibraryInitializer<IDexCMSBaseContext>
    {
        public CalendarsMvcInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>
                {
                    typeof(PageContentInitializer)
                };
            }
        }
    }
}
