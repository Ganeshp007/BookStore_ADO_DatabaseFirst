namespace RepositoryLayer.Interfaces.WishListInterfaces
{
    using System.Collections.Generic;
    using ModelLayer.Models.WishListModels;

    public interface IWishListRL
    {
        public bool AddTOWishList(int UserId, WishListPostModel listPostModel);

        public List<WishListResponseModel> GetAllWishList(int UserId);

        public bool DeleteWishListItem(int UserId, int WishListId);

        public WishListResponseModel GetByWishListId(int WishListId, int UserId);
    }
}
