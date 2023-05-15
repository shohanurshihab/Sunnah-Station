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
    public class WishlistService
    {
        public static List<WishlistDTO> Get()
        {
            var data = DataAccessFactory.WishlistData().Read(); var cfg = new MapperConfiguration(c => {
                c.CreateMap<Wishlist, WishlistDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<WishlistDTO>>(data);
            return mapped;
        }


    }

}

