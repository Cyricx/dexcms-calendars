using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexCMS.Calendars.Models
{
    public class CalendarEventLocation
    {
        [Key]
        public int CalendarEventLocationID { get; set; }


        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public string AdditionalDetails { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string MapIconImage { get; set; }

        public int? MapXCoordinate { get; set; }

        public int? MapYCoordinate { get; set; }

        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }

        [NotMapped]
        public string ReplacementFileName { get; set; }
        [NotMapped]
        public string TemporaryFileName { get; set; }
    }
}
