using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.User;
using API.Models;

namespace API.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                UserId = userModel.UserId,
                UserName = userModel.UserName,
                Email = userModel.Email,
                PhoneNumber = userModel.PhoneNumber
            };
        }

    }
}