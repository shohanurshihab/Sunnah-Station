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
        var data = DataAccessFactory.OrderItemData().Read(); var cfg = new MapperConfiguration(c => {
            c.CreateMap<OrderItem, OrderItemDTO>();
        });
        var mapper = new Mapper(cfg);
        var mapped = mapper.Map<List<OrderItemDTO>>(data);
        return mapped;
    }

    
}

}
