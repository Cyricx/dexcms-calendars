using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Calendars.Models
{
    public partial class Calendar
    {
        
        [Key]
        public int CalendarID { get; set; }

        
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

       
        [Required]
        public bool IsActive { get; set; }

        //! Relationships
        
        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }
        

    }
}
