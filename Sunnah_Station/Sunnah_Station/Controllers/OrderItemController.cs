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
    public class OrderItemController : ApiController
    {
        [HttpGet]
        [Route("api/orderitems")]
        public HttpResponseMessage OrderItems()
        {
            try
            {
                var data = OrderItemService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/orderitems/{id}")]
        public HttpResponseMessage OrderItem(int id)
        {
            try
            {
                var data = OrderItemService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/orderitems/create")]
        public HttpResponseMessage Create(OrderItemDTO OrderItemDTO)
        {
            try
            {
                var createdOrderItem = OrderItemService.CreateOrderItem(OrderItemDTO);
                return Request.CreateResponse(HttpStatusCode.Created, createdOrderItem);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/orderitems/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = OrderItemService.DeleteOrderItem(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/orderitems/update")]
        public HttpResponseMessage Update(OrderItemDTO OrderItemDTO)
        {
            try
            {
                var OrderItem = new OrderItemDTO
                {
                    Id = OrderItemDTO.Id,
                    OrderId = OrderItemDTO.OrderId,
                    ProductId = OrderItemDTO.ProductId,
                    Price = OrderItemDTO.Price,
                    Quantity = OrderItemDTO.Quantity,

                };
                var updatedOrderItem = OrderItemService.UpdateOrderItem(OrderItem);
                if (updatedOrderItem != false)
                {
                    var updatedOrderItemDTO = new OrderItemDTO
                    {
                        Id = OrderItemDTO.Id,
                        OrderId = OrderItemDTO.OrderId,
                        ProductId = OrderItemDTO.ProductId,
                        Price = OrderItemDTO.Price,
                        Quantity = OrderItemDTO.Quantity,
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, updatedOrderItemDTO);
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

