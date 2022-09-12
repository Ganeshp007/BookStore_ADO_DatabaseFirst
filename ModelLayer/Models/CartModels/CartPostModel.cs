namespace ModelLayer.Models.CartModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CartPostModel
    {
        [Required]
        [DefaultValue("0")]
        public int BookId { get; set; }

        [Required]
        [DefaultValue("1")]
        [Range(1,1000,ErrorMessage = "Book Quantity Exceeded it limit!!")]
        public int BookQuantity { get; set; }
    }
}
