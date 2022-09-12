namespace ModelLayer.Models.AdminModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class AdminLoginModel
    {
        [Required]
        [DefaultValue("")]
        public string AdminEmailId { get; set; }

        [Required]
        [DefaultValue("")]
        public string AdminPassword { get; set; }
    }
}
