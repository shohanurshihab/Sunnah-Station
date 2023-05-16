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
    public class OrderItemService
    {
        public static List<OrderItemDTO> Get()
        {
            var data = DataAccessFactory.OrderItemData().Read(); var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderItem, OrderItemDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderItemDTO>>(data);
            return mapped;
        }

         public static OrderItemDTO Get(int id)
        {
            var data = DataAccessFactory.OrderItemData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderItem, OrderItemDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderItemDTO>(data);
            return mapped;

        }

        public static OrderItemDTO CreateOrderItem(OrderItemDTO OrderItemDTO)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<OrderItemDTO, OrderItem>()));
            var OrderItem = mapper.Map<OrderItem>(OrderItemDTO);

            var createdOrderItem = DataAccessFactory.OrderItemData().Create(OrderItem);

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<OrderItem, OrderItemDTO>()));
            var createdOrderItemDTO = mapper.Map<OrderItemDTO>(createdOrderItem);

            return createdOrderItemDTO;
        }

        public static bool UpdateOrderItem(OrderItemDTO dto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderItemDTO, OrderItem>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<OrderItem>(dto);
            var res = DataAccessFactory.OrderItemData().Update(data);
            return res != null;
        }

        public static bool DeleteOrderItem(int id)
        {
            var res = DataAccessFactory.OrderItemData().Delete(id);
            return res;
        }

    }
}