using DexCMS.Calendars.Contexts;
using DexCMS.Calendars.Initializers.Helpers;
using DexCMS.Calendars.Models;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Core.Infrastructure.Globals;
using System;

namespace DexCMS.Calendars.Initializers
{
    class CalendarEventInitializer : DexCMSInitializer<IDexCMSCalendarsContext>
    {
        private CalendarReference Calendars { get; set; }
        private CalendarEventStatusReference Statuses { get; set; }

        public CalendarEventInitializer(IDexCMSCalendarsContext Context) : base(Context)
        {
            Calendars = new CalendarReference(Context);
            Statuses = new CalendarEventStatusReference(Context);
        }

        public override void Run()
        {
            Context.CalendarEvents.AddIfNotExists(x => x.Title,
                new CalendarEvent
                {
                    Title = "All Day Sample",
                    StartDate = new DateTime().Date,
                    Location = "Some Loc",
                    Details = "<p>Hodor hodor HODOR! Hodor hodor hodor. Hodor. Hodor. Hodor hodor hodor. Hodor. Hodor. Hodor HODOR hodor, hodor hodor hodor HODOR hodor, hodor hodor... Hodor hodor hodor. Hodor. Hodor, hodor. Hodor. Hodor, hodor; hodor hodor?! Hodor, hodor. Hodor. Hodor, hodor hodor HODOR hodor, hodor hodor. Hodor. Hodor hodor HODOR! Hodor hodor; hodor hodor, hodor. Hodor hodor - hodor?! </p>",
                    CalendarEventStatusID = Statuses.Confirmed,
                    IsRepeating = false,
                    IsAllDay = true,
                    EventURL = "http://www.chrisbyram.com",
                    CalendarID = Calendars.Public,
                    Disabled = false
                },
                new CalendarEvent
                {
                    Title = "Single Day Time Range Sample",
                    StartDate = new DateTime().Date.AddHours(18),
                    EndDate = new DateTime().Date.AddHours(20),
                    Location = "Another Loc",
                    Details = "<p>Pasta ipsum dolor sit amet strozzapreti scialatelli cavatelli strozzapreti farfalline capellini lumache trenne paccheri sacchettoni foglie d'ulivo gramigna fiorentine calamaretti gramigna tagliatelle. Trofie casarecce zitoni pizzoccheri mafaldine capunti scialatelli penne. Sorprese cavatappi radiatori sagne 'ncannulate pillus mezzi bombardoni ravioli capellini. Elicoidali sacchettoni rigatoncini mafalde mafaldine rotelle tagliatelle lumaconi penne lisce fusilli pennette lasagnette mezzi bombardoni trofie tortiglioni. Rigatoni fagioloni fusilli bucati scialatelli garganelli spaghetti calamaretti radiatori foglie d'ulivo farfalle rotelle capellini tripoline pasta al ceppo tripoline. Mafaldine calamarata spirali acini di pepe sagne 'ncannulate fusilli bucati mezzelune.</p>",
                    CalendarEventStatusID = Statuses.Confirmed,
                    IsRepeating = false,
                    IsAllDay = false,
                    CalendarID = Calendars.Public,
                    Disabled = false
                },
                new CalendarEvent
                {
                    Title = "Multi Day Time Range Sample",
                    StartDate = new DateTime().Date.AddDays(2).AddHours(18),
                    EndDate = new DateTime().Date.AddDays(4).AddHours(18),
                    Location = "Other Loc",
                    Details = "<p>Zombie ipsum reversus ab viral inferno, nam rick grimes malum cerebro. De carne lumbering animata corpora quaeritis. Summus brains sit​​, morbo vel maleficia? De apocalypsi gorger omero undead survivor dictum mauris. Hi mindless mortuis soulless creaturas, imo evil stalking monstra adventus resi dentevil vultus comedat cerebella viventium. Qui animated corpse, cricket bat max brucks terribilem incessu zomby. The voodoo sacerdos flesh eater, suscitat mortuos comedere carnem virus. Zonbi tattered for solum oculi eorum defunctis go lum cerebro. Nescio brains an Undead zombies. Sicut malus putrid voodoo horror. Nigh tofth eliv ingdead.</p>",
                    CalendarEventStatusID = Statuses.Tentative,
                    IsRepeating = false,
                    IsAllDay = false,
                    CalendarID = Calendars.Public,
                    Disabled = false
                }
                );
            Context.SaveChanges();

        }
    }
}
