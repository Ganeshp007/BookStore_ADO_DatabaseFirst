﻿namespace BusinessLayer.Interfaces.UserInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ModelLayer.Models.UserModels;

    public interface IUserBL
    {
        public UserRegistrationModel UserRegistration(UserRegistrationModel registrationModel);
    }
}
