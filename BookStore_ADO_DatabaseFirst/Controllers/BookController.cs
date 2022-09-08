namespace BookStore_ADO_DatabaseFirst.Controllers
{
    using BusinessLayer.Interfaces.BookInterfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ModelLayer.Models.BookModels;
    using System;

    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookBL;

        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [Authorize(Roles =Role.Admin)]
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookPostModel bookPostModel)
        {
            try
            {
                var result = this.bookBL.AddBook(bookPostModel);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = "Book Add Failed!!" });
                }

                return this.Ok(new { success = true, Message = "Book Added Sucessfully...", data = "Book Added :- " + result.BookName});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var result = this.bookBL.GetAllBooks();
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = "No Books Available!!" });
                }

                return this.Ok(new { success = true, Message = "Books records fetched Sucessfully...", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
