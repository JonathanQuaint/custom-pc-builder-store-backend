﻿using System.ComponentModel.DataAnnotations;

namespace PcBackEndAspNetAPI.Dto.Category
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }

    }
}
