namespace ModelLayer.Models.UserModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ResetPassModel
    {
        [Required]
        [DefaultValue("")]
        [RegularExpression("(?=.*[A-Z])(?=.*[0-9])(?=.*[@#$_])[a-zA-Z0-9@#$_]{8,}", ErrorMessage = "Please Enter For Password At least 1 numeric,1 Capital char,1 Special char")] //Password Validation
        public string NewPassword { get; set; }

        [Required]
        [DefaultValue("")]
        public string ConfirmPassword { get; set; }
    }
}
