﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Kanini_Toursim.Model
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public IFormFile IDproof { get; set; }
        public string Phone { get; set; }
    }
}
