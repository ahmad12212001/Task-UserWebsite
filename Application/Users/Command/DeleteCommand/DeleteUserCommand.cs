using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Command.DeleteCommand
{
    public class DeleteUserCommand:IRequest<int>

    {
        public int Id { get; set; }
    }
    
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int> 
    {
        private IApplicationDbContext _context;
        public DeleteUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }  

        public async Task<int> Handle(DeleteUserCommand command,CancellationToken cancellationToken) 
        {
            var user=await _context.Users .FindAsync(command.Id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;






        }

    }


}
