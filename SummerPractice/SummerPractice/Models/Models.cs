﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SummerPractice.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Sname { get; set; }
    }
    public class ChangePassModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public string PhoneNumber { get; set; }
        public bool BrowserRemembered { get; set; }
    }
}