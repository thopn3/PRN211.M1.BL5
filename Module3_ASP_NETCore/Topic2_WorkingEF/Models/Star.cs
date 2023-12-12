﻿using System;
using System.Collections.Generic;

namespace Topic2_WorkingEF.Models
{
    public partial class Star
    {
        public Star()
        {
            MovieStars = new HashSet<MovieStar>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Male { get; set; }
        public string Description { get; set; }
        public DateTime? Dob { get; set; }
        public string Nationality { get; set; }

        public virtual ICollection<MovieStar> MovieStars { get; set; }
    }
}
