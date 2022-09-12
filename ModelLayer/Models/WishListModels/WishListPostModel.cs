namespace ModelLayer.Models.WishListModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class WishListPostModel
    {
        [Required]
        [DefaultValue("0")]
        public int BookId { get; set; }
    }
}
