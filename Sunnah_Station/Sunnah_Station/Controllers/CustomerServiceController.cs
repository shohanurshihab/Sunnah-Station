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

}
}
