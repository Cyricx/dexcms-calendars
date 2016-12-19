using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexCMS.Core.Infrastructure.Attributes;

namespace DexCMS.Calendars.Models
{
    public partial class CalendarEvent
    {
        
        [Key]
        public int CalendarEventID { get; set; }


        [Required]
        [StringLength(250)]
        public string Title { get; set; }


        [Required]
        [IsDateBeforeDate("EndDate")]
        public DateTime StartDate { get; set; }

        
        public DateTime? EndDate { get; set; }


        [StringLength(250)]
        public string Location { get; set; }

        public int? CalendarEventLocationID { get; set; }
        public virtual CalendarEventLocation CalendarEventLocation { get; set; }

        [MaxLength]
        public string Details { get; set; }

        public int? CalendarEventTypeID { get; set; }

        
        [Required]
        public int CalendarEventStatusID { get; set; }

        
        [Required]
        public bool IsRepeating { get; set; }

        
        [Required]
        public bool IsAllDay { get; set; }

        
        [StringLength(50)]
        public string CssClass { get; set; }

        [StringLength(250)]
        [RegularExpression(@"^(ht|f)tp(s?)\:\/\/(([a-zA-Z0-9\-\._]+(\.[a-zA-Z0-9\-\._]+)+)|localhost)(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?([\d\w\.\/\%\+\-\=\&amp;\?\:\\\&quot;\'\,\|\~\;]*)$")]
        public string EventURL { get; set; }
        
        public int? CalendarRepeatTypeID { get; set; }

        public int? RepeatCount { get; set; }

        public int? RepeatCountEnd { get; set; }

        public DateTime? RepeatEndDate { get; set; }

        [Required]
        public int CalendarID { get; set; }

        public bool Disabled { get; set; }


        //! Relationships

        public virtual CalendarEventType CalendarEventType { get; set; }

        public virtual CalendarEventStatus CalendarEventStatus { get; set; }
        
        public virtual ICollection<CalendarRepeatDay> CalendarRepeatDays { get; set; }
        
        public virtual CalendarRepeatType CalendarRepeatType { get; set; }
                
        public virtual Calendar Calendar { get; set; }


        [NotMapped]
        public int[] cbDays { get; set; }
    }
}
