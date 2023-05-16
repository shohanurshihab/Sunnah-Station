using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sunnah_Station.Controllers
{
    public class WishlistController : ApiController
    {
        [HttpGet]
        [Route("api/wishlists")]
        public HttpResponseMessage Wishlists()
        {
            try
            {
                var data = WishlistService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
            [HttpGet]
            [Route("api/wishlists/{id}")]
            public HttpResponseMessage Wishlist(int id)
            {
                try
                {
                    var data = WishlistService.Get(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
                }
            }
            [HttpPost]
            [Route("api/wishlists/create")]
            public HttpResponseMessage Create(WishlistDTO WishlistDTO)
            {
                try
                {
                    var createdWishlist = WishlistService.CreateWishlist(WishlistDTO);
                    return Request.CreateResponse(HttpStatusCode.Created, createdWishlist);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
                }
            }


            [HttpPost]
            [Route("api/wishlists/delete/{id}")]
            public HttpResponseMessage Delete(int id)
            {
                try
                {
                    var data = WishlistService.DeleteWishlist(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
                }
            }
            [HttpPut]
            [Route("api/wishlists/update")]
            public HttpResponseMessage Update(WishlistDTO WishlistDTO)
            {
                try
                {
                    var Wishlist = new WishlistDTO
                    {
                        Id = WishlistDTO.Id,
                        CustomerId = WishlistDTO.CustomerId,
                        ProductId = WishlistDTO.ProductId,
                        
                    };
                    var updatedWishlist = WishlistService.UpdateWishlist(Wishlist);
                    if (updatedWishlist != false)
                    {
                        var updatedWishlistDTO = new WishlistDTO
                        {
                            Id = WishlistDTO.Id,
                            CustomerId = WishlistDTO.CustomerId,
                            ProductId = WishlistDTO.ProductId,
                           
                        };
                        return Request.CreateResponse(HttpStatusCode.OK, updatedWishlistDTO);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
                }
            }


        }
    }





