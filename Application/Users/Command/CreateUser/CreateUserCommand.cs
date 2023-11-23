using Domain.Entities;
using MediatR;

namespace Application.Users.Command.CreateUser
{
    public record CreateUserCommand : IRequest<int>
    {

        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public string Address { get; set; } = null!;
        public string Number { get; set; } = null!;
    }


    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private IApplicationDbContext _context;
        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {


            var user = new User
            {

                Number = command.Number,
                UserName = command.UserName,
                Address = command.Address,
                UserEmail = command.UserEmail,


            };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync(cancellationToken);


            return user.Id;
        }

    }
}

