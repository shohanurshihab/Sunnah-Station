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
    public class OrderService
    {
        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDTO>>(data);
            return mapped;

        }
        public static OrderDTO Get(int id)
        {
            var data = DataAccessFactory.OrderData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDTO>(data);
            return mapped;

        }

        public static OrderDTO CreateOrder(OrderDTO OrderDTO)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()));
            var Order = mapper.Map<Order>(OrderDTO);

            var createdOrder = DataAccessFactory.OrderData().Create(Order);

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()));
            var createdOrderDTO = mapper.Map<OrderDTO>(createdOrder);

            return createdOrderDTO;
        }

        public static bool UpdateOrder(OrderDTO dto)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Order>(dto);
            var res = DataAccessFactory.OrderData().Update(data);
            return res != null;
        }

        public static bool DeleteOrder(int id)
        {
            var res = DataAccessFactory.OrderData().Delete(id);
            return res;
        }
    }
}

