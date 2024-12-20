﻿using System.ComponentModel.DataAnnotations;

namespace PcBackEndAspNetAPI.Dto.User
{
    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }
       
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
