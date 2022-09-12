namespace RepositoryLayer.Interfaces.AdminInterfaces
{
    using ModelLayer.Models.AdminModels;

    public interface IAdminRL
    {
        public string AdminLogin (AdminLoginModel loginModel);
    }
}
