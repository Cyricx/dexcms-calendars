using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Calendars.Models
{
    public partial class CalendarEventStatus
    {
        
        [Key]
        public int CalendarEventStatusID { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        
        [StringLength(25)]
        public string CssClass { get; set; }
        
        [Required]
        public bool IsActive { get; set; }

        //! Relationships
        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }
    }
}
