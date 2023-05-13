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
    public class OrderController : ApiController
    {

        [HttpGet]
        [Route("api/orders")]
        public HttpResponseMessage Orders()
        {
            try
            {
                var data = OrderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/orders/{id}")]
        public HttpResponseMessage Order(int id)
        {
            try
            {
                var data = OrderService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/orders/create")]
        public HttpResponseMessage Create(OrderDTO OrderDTO)
        {
            try
            {
                var createdOrder = OrderService.CreateOrder(OrderDTO);
                return Request.CreateResponse(HttpStatusCode.Created, createdOrder);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/orders/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = OrderService.DeleteOrder(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/orders/update")]
        public HttpResponseMessage Update(OrderDTO OrderDTO)
        {
            try
            {
                var Order = new OrderDTO
                {
                    Id = OrderDTO.Id,
                   CustomerId= OrderDTO.CustomerId,
                   ProductId= OrderDTO.ProductId,
                   Status = OrderDTO.Status,
                };
                var updatedOrder = OrderService.UpdateOrder(Order);
                if (updatedOrder != false)
                {
                    var updatedOrderDTO = new OrderDTO
                    {
                        Id = OrderDTO.Id,
                        CustomerId = OrderDTO.CustomerId,
                        ProductId = OrderDTO.ProductId,
                        Status = OrderDTO.Status,
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, updatedOrderDTO);
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
