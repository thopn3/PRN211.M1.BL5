using System;
using System.Collections.Generic;

namespace Topic2_WorkingEF.Models
{
    public partial class Room
    {
        public Room()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Capacity { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
