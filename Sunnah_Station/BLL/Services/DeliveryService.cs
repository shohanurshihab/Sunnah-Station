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
    public class DeliveryService
    {
        public static List<DeliveryDTO> Get()
        {
            var data = DataAccessFactory.DeliveryData().Read(); var cfg = new MapperConfiguration(c => {
                c.CreateMap<Delivery, DeliveryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DeliveryDTO>>(data);
            return mapped;
        }

        public static DeliveryDTO Get(int id)
        {
            var data = DataAccessFactory.DeliveryData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Delivery, DeliveryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DeliveryDTO>(data);
            return mapped;
        }

        public static DeliveryDTO CreateDelivery(DeliveryDTO deliveryDTO)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<DeliveryDTO, Delivery>()));
            var delivery = mapper.Map<Delivery>(deliveryDTO);   

            var createdDelivery = DataAccessFactory.DeliveryData().Create(delivery);

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Delivery, DeliveryDTO>()));
            var createdDeliveryDTO = mapper.Map<DeliveryDTO>(createdDelivery);

            return createdDeliveryDTO;
        }

        public static bool UpdateDelivery(DeliveryDTO dto)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<DeliveryDTO, Delivery>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Delivery>(dto);
            var res = DataAccessFactory.DeliveryData().Update(data);
            return res != null;
        }

        public static bool DeleteDelivery(int id)
        {
            var res = DataAccessFactory.DeliveryData().Delete(id);
            return res;
        }
    }

}
