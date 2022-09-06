namespace BookStore_ADO_DatabaseFirst.Controllers
{
    using System;
    using BusinessLayer.Interfaces.UserInterfaces;
    using Microsoft.AspNetCore.Mvc;
    using ModelLayer.Models.UserModels;

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost]
        public IActionResult UserRegistration(UserRegistrationModel registrationModel)
        {
            try
            {
                var result=this.userBL.UserRegistration(registrationModel);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = "User Registration Failed!!" });
                }

                return this.Ok(new { success = true, Message = "User Registration Sucessfull", data=result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
