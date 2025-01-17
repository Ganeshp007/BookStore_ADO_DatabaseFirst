﻿namespace ModelLayer.Models.UserModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UserRegistrationModel
    {
        [Required]
        [DefaultValue("")]
        [RegularExpression("^([A-Z][A-Za-z]{3,20})+ +([A-Z][A-Za-z]{3,20})$", ErrorMessage = "Please Enter Valid Full Name At least 3 Characters,First letter Capital and space between Eg. Jhon Clark")] //First Name Validation
        public string FullName { get; set; }

        [Required]
        [DefaultValue("")]
        [RegularExpression("^([A-Za-z0-9]{3,20})([.][A-Za-z0-9]{1,10})*([@][A-Za-z]{2,5})+[.][A-Za-z]{2,3}([.][A-Za-z]{2,3})?$", ErrorMessage = "Please Enter Valid Email Eg.abc123@gamil.com")] //Email validation
        public string EmailId { get; set; }

        [Required]
        [DefaultValue("")]
        [RegularExpression("(?=.*[A-Z])(?=.*[0-9])(?=.*[@#$_])[a-zA-Z0-9@#$_]{8,}", ErrorMessage = "Please Enter For Password At least 1 numeric,1 Capital char,1 Special char")] //Password Validation
        public string Password { get; set; }

        [Required]
        [DefaultValue("")]
        [RegularExpression("^[1-9]{2}[6-9]{1}[0-9]{9}$", ErrorMessage = "Please Enter Valid Mobile No  Eg. 91+9900995544")] //MobileNo Validation
        public string MobileNo { get; set; }
    }
}
