using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sunnah_Station.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/products")]
        public HttpResponseMessage Products()
        {
            try
            {
                var data = ProductService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/products/{id}")]
        public HttpResponseMessage Product(int id)
        {
            try
            {
                var data = ProductService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/products/create")]
        public HttpResponseMessage Create(ProductDTO productDTO)
        {
            try
            {
                var createdProduct = ProductService.CreateProduct(productDTO);
                return Request.CreateResponse(HttpStatusCode.Created, createdProduct);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/products/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = ProductService.DeleteProduct(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/products/update")]
        public HttpResponseMessage Update(ProductDTO productDTO)
        {
            try
            {
                var product = new ProductDTO
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    Quantity=productDTO.Quantity,
                    CategoryId=productDTO.CategoryId,
                    Image=productDTO.Image,
                };
                var updatedProduct = ProductService.UpdateProduct(product);
                if (updatedProduct != false)
                {
                    var updatedProductDTO = new ProductDTO
                    {
                        Id = productDTO.Id,
                        Name = productDTO.Name,
                        Price = productDTO.Price,
                        Quantity = productDTO.Quantity,
                        CategoryId = productDTO.CategoryId,
                        Image = productDTO.Image,
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, updatedProductDTO);
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

        [HttpGet]
        [Route("api/products/{id}/orders")]
        public HttpResponseMessage ProductOrders(int id)
        {
            try
            {
                var data = ProductService.GetwithOrders(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

    }
}
