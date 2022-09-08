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

        public List<BookResponseModel> GetAllBooks()
        {
            List<BookResponseModel> listOfUsers = new List<BookResponseModel>();
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllBooksSP", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BookResponseModel book = new BookResponseModel();
                        book.BookId = reader["BookId"] == DBNull.Value ? default : reader.GetInt32("BookId");
                        book.BookName = reader["BookName"] == DBNull.Value ? default : reader.GetString("BookName");
                        book.Author = reader["Author"] == DBNull.Value ? default : reader.GetString("Author");
                        book.Description = reader["Description"] == DBNull.Value ? default : reader.GetString("Description");
                        book.Quantity = reader["Quantity"] == DBNull.Value ? default : reader.GetInt32("Quantity");
                        book.Price = reader["Price"] == DBNull.Value ? default : reader.GetDecimal("Price");
                        book.DiscountPrice = reader["DiscountPrice"] == DBNull.Value ? default : reader.GetDecimal("DiscountPrice");
                        book.TotalRating = reader["TotalRating"] == DBNull.Value ? default : reader.GetDouble("TotalRating");
                        book.RatingCount = reader["RatingCount"] == DBNull.Value ? default : reader.GetInt32("RatingCount");
                        book.BookImg = reader["BookImg"] == DBNull.Value ? default : reader.GetString("BookImg");
                        listOfUsers.Add(book);
                    }

                    return listOfUsers;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
