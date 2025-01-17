﻿namespace BookStore_ADO_DatabaseFirst.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using BusinessLayer.Interfaces.CartInterfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ModelLayer.Models.CartModels;

    [Authorize(Roles = Role.Users)]
    [Route("[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartBL cartBL;

        public CartController(ICartBL cartBL)
        {
           this.cartBL = cartBL;
        }

        [HttpPost("AddBookTOCart")]
        public IActionResult AddBookTOCart(CartPostModel postModel)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
                int UserId = Convert.ToInt32(userId);
                var result = this.cartBL.AddBookTOCart(UserId,postModel);
                if (result == false)
                {
                    return this.BadRequest(new { success = false, Message = $"Check if Book is availbale OR it is already in Cart!!  BookId : {postModel.BookId} to the cart!!" });
                }

                return this.Ok(new { success = true, Message = $"BookId : {postModel.BookId} Added to cart Sucessfull..."});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllBooksInCart")]
        public IActionResult GetAllBooksInCart()
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
                int UserId = Convert.ToInt32(userId);
                List<CartResponseModel> result = this.cartBL.GetAllBooksInCart(UserId);
                if (result.Count == 0)
                {
                    return this.BadRequest(new { success = false, Message = $"No Book available in cart!!" });
                }

                return this.Ok(new { success = true, Message = $"Books in Cart fetched Sucessfully...", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetCartItem/{CartId}")]
        public IActionResult GetCartItemByCartId(int CartId)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
                int UserId = Convert.ToInt32(userId);
                var result = this.cartBL.GetCartItemByCartId(CartId, UserId);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = $"No Book available in cart with this CartId :{CartId}!!" });
                }

                return this.Ok(new { success = true, Message = $"CartId: {CartId} details fetched Sucessfully...", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateCartItem")]
        public IActionResult UpdateCartItem(CartUpdateModel cartUpdateModel)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
                int UserId = Convert.ToInt32(userId);
                var result = this.cartBL.UpdateCartItem(UserId, cartUpdateModel);
                if (result == false)
                {
                    return this.BadRequest(new { success = false, Message = $"Update cart Failed!! Check if CartItem is availbale in Cart or not..." });
                }

                return this.Ok(new { success = true, Message = $"CartId : {cartUpdateModel.CartId} Updated In cart Sucessfully..." });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("DeleteCart/{CartId}")]
        public IActionResult DeleteCartItembyBookId(int CartId)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
                int UserId = Convert.ToInt32(userId);
                var result = this.cartBL.DeleteCartItembyBookId(UserId, CartId);
                if (result == false)
                {
                    return this.BadRequest(new { success = false, Message = $"Something went wrong while removing CartItemId : {CartId} from the cart!!" });
                }

                return this.Ok(new { success = true, Message = $"CartItemId : {CartId} removed from cart Sucessfully..." });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
