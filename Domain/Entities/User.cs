using Application.Users.Command.Dtos;
using Domain.Common;



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

       

        public string Address { get; set; } = null!;
        public string Number { get; set; } = null!;

        public UserDto ToUserDto()
        {
            return new UserDto
            {
                Name=UserName,
                Add= Address,
                Email=UserEmail,
                Number=Number,



            };

        }


    }
}
