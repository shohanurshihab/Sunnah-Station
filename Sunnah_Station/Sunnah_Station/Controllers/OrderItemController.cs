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

    }
}
