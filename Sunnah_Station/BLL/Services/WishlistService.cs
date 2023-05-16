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
        public static WishlistDTO Get(int id)
        {
            var data = DataAccessFactory.WishlistData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Wishlist, WishlistDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WishlistDTO>(data);
            return mapped;

        }

        public static WishlistDTO CreateWishlist(WishlistDTO WishlistDTO)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<WishlistDTO, Wishlist>()));
            var Wishlist = mapper.Map<Wishlist>(WishlistDTO);

            var createdWishlist = DataAccessFactory.WishlistData().Create(Wishlist);

            mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Wishlist, WishlistDTO>()));
            var createdWishlistDTO = mapper.Map<WishlistDTO>(createdWishlist);

            return createdWishlistDTO;
        }

        public static bool UpdateWishlist(WishlistDTO dto)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<WishlistDTO, Wishlist>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Wishlist>(dto);
            var res = DataAccessFactory.WishlistData().Update(data);
            return res != null;
        }

        public static bool DeleteWishlist(int id)
        {
            var res = DataAccessFactory.WishlistData().Delete(id);
            return res;
        }

    }

}



