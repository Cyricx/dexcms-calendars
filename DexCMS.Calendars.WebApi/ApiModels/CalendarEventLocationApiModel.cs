namespace DexCMS.Calendars.WebApi.ApiModels
{
    public class CalendarEventLocationApiModel
    {
        public int CalendarEventLocationID { get; set; }
        public string Name { get; set; }
        public string AdditionalDetails { get; set; }
        public bool IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public string MapIconImage { get; set; }
        public int? MapXCoordinate { get; set; }
        public int? MapYCoordinate { get; set; }
        public int CalendarEventCount { get; set; }
        public string ReplacementFileName { get; set; }
    }
}
