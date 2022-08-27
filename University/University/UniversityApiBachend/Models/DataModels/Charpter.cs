﻿using System.ComponentModel.DataAnnotations;

namespace UniversityApiBachend.Models.DataModels
{
    public class Charpter : BaseEntity
    {

        public int CurseId { get; set; }
        public Course Course { get; set; } = new Course();

        [Required]
        public string List { get; set; } = string.Empty;

    }

}
