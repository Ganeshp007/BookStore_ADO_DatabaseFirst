namespace BusinessLayer.Interfaces.BookInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ModelLayer.Models.BookModels;

    public interface IBookBL
    {
        public BookPostModel AddBook(BookPostModel bookPostModel);
    }
}
