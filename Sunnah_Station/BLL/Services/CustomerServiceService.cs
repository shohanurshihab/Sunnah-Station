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


    

    public static CustomerServiceDTO Get(int id)
    {
        var data = DataAccessFactory.CustomerServiceData().Read(id);
        var cfg = new MapperConfiguration(c => {
            c.CreateMap<CustomerService, CustomerServiceDTO>();
        });
        var mapper = new Mapper(cfg);
        var mapped = mapper.Map<CustomerServiceDTO>(data);
        return mapped;

    }

    public static CustomerServiceDTO CreateCustomerService(CustomerServiceDTO CustomerServiceDTO)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CustomerServiceDTO, CustomerService>()));
        var CustomerService = mapper.Map<CustomerService>(CustomerServiceDTO);

        var createdCustomerService = DataAccessFactory.CustomerServiceData().Create(CustomerService);

        mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CustomerService, CustomerServiceDTO>()));
        var createdCustomerServiceDTO = mapper.Map<CustomerServiceDTO>(createdCustomerService);

        return createdCustomerServiceDTO;
    }

    public static bool UpdateCustomerService(CustomerServiceDTO dto)
    {
        var cfg = new MapperConfiguration(c => {
            c.CreateMap<CustomerServiceDTO, CustomerService>();
        });
        var mapper = new Mapper(cfg);
        var data = mapper.Map<CustomerService>(dto);
        var res = DataAccessFactory.CustomerServiceData().Update(data);
        return res != null;
    }

    public static bool DeleteCustomerService(int id)
    {
        var res = DataAccessFactory.CustomerServiceData().Delete(id);
        return res;
    }

}

}


