﻿using System.ComponentModel.DataAnnotations;

namespace StarWars.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="Логин" )]
        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        [Display(Name="Пароль")]
        public string Password { get; set; }

        [Display(Name="Запомнить меня?")]
        public bool RememberMe { get; set;}
    }
}
