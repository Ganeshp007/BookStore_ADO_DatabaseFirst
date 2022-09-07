namespace RepositoryLayer.Interfaces.UserInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ModelLayer.Models.UserModels;

    public interface IUserRL
    {
        public UserRegistrationModel UserRegistration(UserRegistrationModel registrationModel);

        public List<GetAllUsersModel> GetAllUsers();

        public string UserLogin(UserLoginModel loginModel);

        public bool ForgotPassword(string EmailId);
    }
}
