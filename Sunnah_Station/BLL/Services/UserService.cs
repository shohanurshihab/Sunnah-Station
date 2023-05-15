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
    public class UserService
    {
        public static UserDTO Create(UserDTO user)
        {
            var data = Convert(user);

            return Convert(DataAccessFactory.UserData().Create(data));
        }
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();

            return Convert(data);
        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);

            return Convert(data);
        }

        public static UserDTO Get(string email)
        {
            var data = DataAccessFactory.UserData().ReadAuthUser(email);

            return Convert(data);
        }

        public static UserDTO GetByEmail(string email)
        {
            var data = DataAccessFactory.UserData().GetByEmail(email);

            return Convert(data);
        }

        static List<UserDTO> Convert(List<User> users)
        {
            var data = new List<UserDTO>();
            foreach (User user in users)
            {
                data.Add(Convert(user));
            }
            return data;
        }
        static UserDTO Convert(User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Dob = user.Dob,
                Password = user.Password,
                Type = (DTOs.Type)user.Type,
                Image = user.Image
            };
        }
        static User Convert(UserDTO user)
        {
            return new User()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Dob = user.Dob,
                Password = user.Password,
                Type = (DAL.Models.Type)user.Type,
                Image = user.Image
            };
        }
    }
}