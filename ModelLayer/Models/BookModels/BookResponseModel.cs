﻿namespace ModelLayer.Models.BookModels
{
    public class BookResponseModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPrice { get; set; }

        public double TotalRating { get; set; }

        public int RatingCount { get; set; }

        public string BookImg { get; set; }
    }
}
