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
    public class CustomerServiceController : ApiController
    { 
     [HttpGet]
        [Route("api/customerservices")]
        public HttpResponseMessage CustomerServices()
    {
        try
        {
            var data = CustomerServiceService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        catch (Exception ex)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
        }

    }

        [HttpGet]
        [Route("api/customerservices/{id}")]
        public HttpResponseMessage CustomerService(int id)
        {
            try
            {
                var data = CustomerServiceService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/customerservices/create")]
        public HttpResponseMessage Create(CustomerServiceDTO CustomerServiceDTO)
        {
            try
            {
                var createdCustomerService = CustomerServiceService.CreateCustomerService(CustomerServiceDTO);
                return Request.CreateResponse(HttpStatusCode.Created, createdCustomerService);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/customerservices/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = CustomerServiceService.DeleteCustomerService(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/customerservices/update")]
        public HttpResponseMessage Update(CustomerServiceDTO CustomerServiceDTO)
        {
            try
            {
                var CustomerService = new CustomerServiceDTO
                {
                    Id = CustomerServiceDTO.Id,
                    CustomerId = CustomerServiceDTO.CustomerId,
                    RatingDescription = CustomerServiceDTO.RatingDescription,
                    RatingTime = CustomerServiceDTO.RatingTime,
                   
                };
                var updatedCustomerService = CustomerServiceService.UpdateCustomerService(CustomerService);
                if (updatedCustomerService != false)
                {
                    var updatedCustomerServiceDTO = new CustomerServiceDTO
                    {
                        Id = CustomerServiceDTO.Id,
                        CustomerId = CustomerServiceDTO.CustomerId,
                        RatingDescription = CustomerServiceDTO.RatingDescription,
                        RatingTime = CustomerServiceDTO.RatingTime,

                    };
                    return Request.CreateResponse(HttpStatusCode.OK, updatedCustomerServiceDTO);
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



