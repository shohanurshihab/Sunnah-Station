using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static List<ProductDTO> Get()
        {
            var data = DataAccessFactory.ProductData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;

        }
        public static ProductDTO Get(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;

        }
        public static ProductDTO CreateProduct(ProductDTO productDTO)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()));
            var product = mapper.Map<Product>(productDTO);

            var createdProduct = DataAccessFactory.ProductData().Create(product);

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()));
            var createdProductDTO = mapper.Map<ProductDTO>(createdProduct);

            return createdProductDTO;
        }

        public static bool UpdateProduct(ProductDTO dto)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Product>(dto);
            var res = DataAccessFactory.ProductData().Update(data);
            return res != null;
        }

        public static bool DeleteProduct(int id)
        {
            var res = DataAccessFactory.ProductData().Delete(id);
            return res;
        }
        public static ProductOrdersDTO GetwithOrders(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductOrdersDTO>(); 
                c.CreateMap<Order, OrderDTO >();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductOrdersDTO>(data);
            return mapped;
        }
    }
}

