namespace RepositoryLayer.Interfaces.OrderInterfaces
{
    using System.Collections.Generic;
    using ModelLayer.Models.OrderModels;

    public interface IOrderRL
    {
        public bool AddOrder(OrderPostModel postModel);

        public List<OrderResponseModel> GetAllOrders(int UserId);
    }
}
