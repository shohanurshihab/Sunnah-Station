using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService
    {
        public static List<CategoryDTO> Get()
        {
            var data = DataAccessFactory.CategoryData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CategoryDTO>>(data);
            return mapped;
        }

        public static CategoryDTO Get(int id)
        {
            var data = DataAccessFactory.CategoryData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CategoryDTO>(data);
            return mapped;
        }

        public static CategoryDTO CreateCategory(CategoryDTO categoryDTO)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>()));
            var category = mapper.Map<Category>(categoryDTO);

            var createdCategory = DataAccessFactory.CategoryData().Create(category);

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()));
            var createdCategoryDTO = mapper.Map<CategoryDTO>(createdCategory);

            return createdCategoryDTO;
        }

        public static bool UpdateCategory(CategoryDTO dto)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Category>(dto);
            var res = DataAccessFactory.CategoryData().Update(data);
            return res != null;
        }

        public static bool DeleteCategory(int id)
        {
            var res = DataAccessFactory.CategoryData().Delete(id);
            return res;
        }
    }

}
