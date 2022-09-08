namespace RepositoryLayer.Services.BookServices
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.Extensions.Configuration;
    using ModelLayer.Models.BookModels;
    using RepositoryLayer.Interfaces.BookInterfaces;

    public class BookRL : IBookRL
    {
        private readonly string connectionString;

        public BookRL(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("BookStoreDB");
        }

        public BookPostModel AddBook(BookPostModel bookPostModel)
        {
            SqlConnection sqlconnection = new SqlConnection(this.connectionString);
            try
            {
                {
                    sqlconnection.Open();

                    SqlCommand cmd = new SqlCommand("AddBookSP", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName ", bookPostModel.BookName);
                    cmd.Parameters.AddWithValue("@Author", bookPostModel.Author);
                    cmd.Parameters.AddWithValue("@Description ", bookPostModel.Description);
                    cmd.Parameters.AddWithValue("@Quantity", bookPostModel.Quantity);
                    cmd.Parameters.AddWithValue("@Price", bookPostModel.Price);
                    cmd.Parameters.AddWithValue("@DiscountPrice ", bookPostModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@TotalRating ", bookPostModel.TotalRating);
                    cmd.Parameters.AddWithValue("@RatingCount", bookPostModel.RatingCount);
                    cmd.Parameters.AddWithValue("@BookImg", bookPostModel.BookImg);

                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return bookPostModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}
