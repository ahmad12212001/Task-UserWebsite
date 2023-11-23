using Application.Users.Command.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.UpdateUser
{
    public record UpdateUserCommand:IRequest<UserDto>
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Number { get; set; } = null!;
    }

    public class UpdateUserCommandHandler :IRequestHandler<UpdateUserCommand , UserDto> 
    {
        private IApplicationDbContext _context;

        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<UserDto> Handle(UpdateUserCommand command,CancellationToken cancellationToken) 
        {
            var user = (await _context.Users.FindAsync(command.Id));
            if (user == null)
            {

                return null;
            }
            user.UserName = command.UserName;
            user.UserEmail = command.UserEmail;
            user.Address = command.Address;
            user.Number = command.Number;

             _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.ToUserDto();
        
        
        
        
        
        
        }
         

       

    }
}
