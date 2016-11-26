using DexCMS.Base.Contexts;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Calendars.Mvc.Initializers
{
    public class CalendarsMvcInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        public CalendarsMvcInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            (new PageContentInitializer(Context)).Run();
        }
    }
}
