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
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/categories")]
        public HttpResponseMessage Categories()
        {
            try
            {
                var data = CategoryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/categories/{id}")]
        public HttpResponseMessage Category(int id)
        {
            try
            {
                var data = CategoryService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/categories/create")]
        public HttpResponseMessage Create(CategoryDTO categoryDTO)
        {
            try
            {
                var createdCategory = CategoryService.CreateCategory(categoryDTO);
                return Request.CreateResponse(HttpStatusCode.Created, createdCategory);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/categories/update")]
        public HttpResponseMessage Update(CategoryDTO categoryDTO)
        {
            try
            {
                var category = new CategoryDTO
                {
                    Id = categoryDTO.Id,
                    Name = categoryDTO.Name,
                };
                var updatedCategory = CategoryService.UpdateCategory(category);
                if (updatedCategory != false)
                {
                    var updatedCategoryDTO = new CategoryDTO
                    {
                        Id = categoryDTO.Id,
                        Name = categoryDTO.Name,
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, updatedCategoryDTO);
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

        [HttpPost]
        [Route("api/categories/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = CategoryService.DeleteCategory(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

    }
}
