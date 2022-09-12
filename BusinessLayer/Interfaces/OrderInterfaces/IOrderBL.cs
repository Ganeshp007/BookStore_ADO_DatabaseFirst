namespace BusinessLayer.Interfaces.OrderInterfaces
{
    using System.Collections.Generic;
    using ModelLayer.Models.OrderModels;

    public interface IOrderBL
    {
        public bool AddOrder(OrderPostModel postModel);

        public List<OrderResponseModel> GetAllOrders(int UserId);
    }
}
