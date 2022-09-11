namespace RepositoryLayer.Interfaces.OrderInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ModelLayer.Models.OrderModels;
    using ModelLayer.Models.WishListModels;

    public interface IOrderRL
    {
        public bool AddOrder(OrderPostModel postModel);

        public List<OrderResponseModel> GetAllOrders(int UserId);
    }
}
