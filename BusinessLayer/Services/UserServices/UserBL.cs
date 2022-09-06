namespace BusinessLayer.Services.UserServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BusinessLayer.Interfaces.UserInterfaces;
    using ModelLayer.Models.UserModels;
    using RepositoryLayer.Interfaces.UserInterfaces;

    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public UserRegistrationModel UserRegistration(UserRegistrationModel registrationModel)
        {
            try
            {
                return this.userRL.UserRegistration(registrationModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
