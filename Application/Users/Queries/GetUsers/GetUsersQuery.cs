using Application.Users.Command.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsers
{
    public class GetUsersQuery:IRequest<List<UserDto>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>> 
    {
        private readonly IApplicationDbContext _context;
        public GetUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken) 
        {
            return await _context.Users.Select(i => new  UserDto
            {
                Id = i.Id,
                Name = i.UserName,
                Email = i.UserEmail,
                Add = i.Address,
                Number = i.Number,
            }).ToListAsync();





        }
    }

}
