namespace BusinessLayer.Services.BookServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BusinessLayer.Interfaces.BookInterfaces;
    using ModelLayer.Models.BookModels;
    using RepositoryLayer.Interfaces.BookInterfaces;

    public class BookBL : IBookBL
    {
        private readonly IBookRL bookRL;

        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public BookPostModel AddBook(BookPostModel bookPostModel)
        {
            try
            {
                return this.bookRL.AddBook(bookPostModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
