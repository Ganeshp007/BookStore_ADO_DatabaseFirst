namespace RepositoryLayer.Services.UserServices
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.Extensions.Configuration;
    using ModelLayer.Models.UserModels;
    using RepositoryLayer.Interfaces.UserInterfaces;

    public class UserRL : IUserRL
    {
        private readonly string connetionString;

        public UserRL(IConfiguration configuration)
        {
            this.connetionString = configuration.GetConnectionString("BookStoreDB");
        }

        //Method to register User 
        public UserRegistrationModel UserRegistration(UserRegistrationModel registrationModel)
        {
            SqlConnection sqlconnection = new SqlConnection(this.connetionString);
            string Password = EncryptPassword(registrationModel.Password);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("UserRegistrationSP", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", registrationModel.FullName);
                    cmd.Parameters.AddWithValue("@EmailId", registrationModel.EmailId);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@MobileNo", registrationModel.MobileNo);
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return registrationModel;
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

        //Method to Get Records of All Users
        public List<GetAllUsersModel> GetAllUsers()
        {
            List<GetAllUsersModel> listOfUsers = new List<GetAllUsersModel>();
            SqlConnection sqlConnection = new SqlConnection(this.connetionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllUsersSP", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GetAllUsersModel User = new GetAllUsersModel();
                        User.UserId = reader["UserId"] == DBNull.Value ? default : reader.GetInt32("UserId");
                        User.FullName = Convert.ToString(reader["FullName"]);
                        User.EmailId = Convert.ToString(reader["EmailId"]);
                        string Password=Convert.ToString(reader["Password"]);
                        User.Password = DecryptPassword(Password);
                        User.MobileNo = Convert.ToInt64(reader["MobileNo"]);
                        listOfUsers.Add(User);
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

        // method to Encrypt Password
        public static string EncryptPassword(string Password)
        {
            try
            {
                if (Password == null)
                {
                    return null;
                }
                else
                {
                    byte[] x = Encoding.ASCII.GetBytes(Password);
                    string encryptedpass = Convert.ToBase64String(x);
                    return encryptedpass;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Method to Decrypt Encrypted password
        public static string DecryptPassword(string encryptedPass)
        {
            byte[] x;
            string decrypted;
            try
            {
                if (encryptedPass == null)
                {
                    return null;
                }
                else
                {
                    x = Convert.FromBase64String(encryptedPass);
                    decrypted = Encoding.ASCII.GetString(x);
                    return decrypted;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
