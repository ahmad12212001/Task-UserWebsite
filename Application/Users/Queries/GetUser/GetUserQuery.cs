using Application.Users.Command.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUser
{

    public record GetUserQuery:IRequest<UserDto>
    {
        public int Id { get; set; }
    }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto> 
    {
        private IApplicationDbContext _context;

        public GetUserQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        
        }

        public async Task<UserDto> Handle(GetUserQuery request,CancellationToken cancellationToken) 
        {
            var user = await _context.Users.Select(i => new UserDto
            {
                Id = i.Id,
                Name=i.UserName,
                Email=i.UserEmail,
                Add=i.Address,
                Number=i.Number,
                
            }).AsNoTracking().FirstOrDefaultAsync(t => t.Id == request.Id);
            return user;







        }







    }
}
