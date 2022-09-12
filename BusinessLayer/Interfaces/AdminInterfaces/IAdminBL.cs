namespace BusinessLayer.Interfaces.AdminInterfaces
{
    using ModelLayer.Models.AdminModels;

    public interface IAdminBL
    {
        public string AdminLogin(AdminLoginModel loginModel);

    }
}
