using System;
using System.Collections.Generic;

namespace Topic2_WorkingEF.Models
{
    public partial class MovieStar
    {
        public int MovieId { get; set; }
        public int StarId { get; set; }
        public string Position { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Star Star { get; set; }
    }
}
