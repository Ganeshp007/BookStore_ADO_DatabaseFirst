namespace ModelLayer.Models.OrderModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class OrderPostModel
    {
        [Required]
        [DefaultValue("0")]
        public int CartId { get; set; }

        [Required]
        [DefaultValue("0")]
        public int AddressId { get; set; }
    }
}
