﻿namespace BusinessLayer.Services.BookServices
{
    using System;
    using System.Collections.Generic;
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

        public List<BookResponseModel> GetAllBooks()
        {
            try
            {
                return this.bookRL.GetAllBooks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BookResponseModel GetBookById(int BookId)
        {
            try
            {
                return this.bookRL.GetBookById(BookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BookResponseModel UpdateBooks(int BookId, BookPostModel bookPostModel)
        {
            try
            {
                return this.bookRL.UpdateBooks(BookId, bookPostModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool DeleteBook(int BookId)
        {
            try
            {
                return this.bookRL.DeleteBook(BookId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
