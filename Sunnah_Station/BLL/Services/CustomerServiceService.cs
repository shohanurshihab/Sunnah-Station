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
    public class CustomerServiceService
    {
        public static List<CustomerServiceDTO> Get()
        {
            var data = DataAccessFactory.CustomerServiceData().Read(); var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerService, CustomerServiceDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CustomerServiceDTO>>(data);
            return mapped;
        }


    }

}

