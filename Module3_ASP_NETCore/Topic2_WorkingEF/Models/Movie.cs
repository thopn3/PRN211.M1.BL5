﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Topic2_WorkingEF.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieStars = new HashSet<MovieStar>();
            Schedules = new HashSet<Schedule>();
            Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="Title is required.")]
        public string Title { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }
        public virtual ICollection<MovieStar> MovieStars { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}
