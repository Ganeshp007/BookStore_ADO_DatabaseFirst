namespace RepositoryLayer.Interfaces.BookInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ModelLayer.Models.BookModels;

    public interface IBookRL
    {
        public BookPostModel AddBook(BookPostModel bookPostModel);
    }
}
