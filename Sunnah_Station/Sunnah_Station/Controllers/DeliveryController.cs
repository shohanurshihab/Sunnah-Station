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
    public class DeliveryController : ApiController
    {
        [HttpGet]
        [Route("api/deliveries")]
        public HttpResponseMessage Deliveries()
        {
            try
            {
                var data = DeliveryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/deliveries/{id}")]
        public HttpResponseMessage Delivery(int id)
        {
            try
            {
                var data = DeliveryService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/deliveries/create")]
        public HttpResponseMessage Create(DeliveryDTO DeliveryDTO)
        {
            try
            {
                var createdDelivery = DeliveryService.CreateDelivery(DeliveryDTO);
                return Request.CreateResponse(HttpStatusCode.Created, createdDelivery);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/deliveries/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = DeliveryService.DeleteDelivery(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/deliveries/update")]
        public HttpResponseMessage Update(DeliveryDTO DeliveryDTO)
        {
            try
            {
                var Delivery = new DeliveryDTO
                {
                    Id = DeliveryDTO.Id,
                    OrderId = DeliveryDTO.OrderId,
                    TrackingNo = DeliveryDTO.TrackingNo,
                    Carrier = DeliveryDTO.Carrier,
                    DeliveryDate= DeliveryDTO.DeliveryDate,
                };
                var updatedDelivery = DeliveryService.UpdateDelivery(Delivery);
                if (updatedDelivery != false)
                {
                    var updatedDeliveryDTO = new DeliveryDTO
                    {
                        Id = DeliveryDTO.Id,
                        OrderId = DeliveryDTO.OrderId,
                        TrackingNo = DeliveryDTO.TrackingNo,
                        Carrier = DeliveryDTO.Carrier,
                        DeliveryDate = DeliveryDTO.DeliveryDate,
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, updatedDeliveryDTO);
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


