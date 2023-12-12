using System;
using System.Collections.Generic;

namespace Topic2_WorkingEF.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public int? TimeSlotId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Room Room { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
    }
}
