namespace ModelLayer.Models.UserModels
{
    public class GetAllUsersModel
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public long MobileNo { get; set; }
    }
}
