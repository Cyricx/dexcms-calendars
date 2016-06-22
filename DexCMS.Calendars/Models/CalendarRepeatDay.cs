using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Calendars.Models
{
    public partial class CalendarRepeatDay
    {
        [Key]
        public int CalendarRepeatDayID { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        
        [Required]
        public bool IsActive { get; set; }

        //! Relationships
        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }
    }
}
