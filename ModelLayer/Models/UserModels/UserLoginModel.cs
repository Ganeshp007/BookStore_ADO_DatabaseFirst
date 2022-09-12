namespace ModelLayer.Models.UserModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UserLoginModel
    {
        [Required]
        [DefaultValue("")]
        public string EmailId { get; set; }

        [Required]
        [DefaultValue("")]
        public string Password { get; set; }
    }
}
