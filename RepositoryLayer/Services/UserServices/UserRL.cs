namespace RepositoryLayer.Services.UserServices
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using ModelLayer.Models.UserModels;
    using RepositoryLayer.Interfaces.UserInterfaces;

    public class UserRL : IUserRL
    {
        private readonly string connectionString;

        public UserRL(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("BookStoreDB");
        }

        //Method to register User 
        public UserRegistrationModel UserRegistration(UserRegistrationModel registrationModel)
        {
            SqlConnection sqlconnection = new SqlConnection(this.connectionString);
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
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
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

        //Creating Method for UserLogin
        public string UserLogin(UserLoginModel loginModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string Password = EncryptPassword(loginModel.Password);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("UserLoginSP", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailId", loginModel.EmailId);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();
                    GetAllUsersModel response = new GetAllUsersModel();
                    if (reader.Read())
                    {
                        response.UserId = reader["UserId"] == DBNull.Value ? default : reader.GetInt32("UserId");
                        response.EmailId = reader["EmailId"] == DBNull.Value ? default : reader.GetString("EmailId");
                        response.Password = reader["Password"] == DBNull.Value ? default : reader.GetString("Password");
                    }

                    return GenerateJWTToken(response.EmailId, response.UserId);
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

        //Method to Generate JWT Token for Authentication and Athorization when User Login Sucessful
        private string GenerateJWTToken(string email, int userId)
        {
            try
            {
                // generate token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("EmailId", email),
                    new Claim("UserId",userId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
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
