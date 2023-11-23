//using Application.Users.Command.Dtos;
//using AutoMapper;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Users.Queries.GetUsers
//{
//    public record GetUserQueryByPagination : IRequest<PaginatedList<UserDto>>
//    {
//        const int MAX_PAGE_SIZE = 50;
//        public string? Name { get; set; }
        
//        public int PageNumber { get; init; } 
//        public int PageSize
//        {
//            get
//            {
//                return PageSize;
//            }
//            set 
//            {
//                PageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value; 
                    
//              } 
        
//        } 
//        public string direction { get; init; }
            
//    }

//    public class GetUserQueryByPaginationHandler : IRequestHandler<GetUserQueryByPagination, PaginatedList<UserDto>>
//    {
//        private readonly IApplicationDbContext _context;


//        public GetUserQueryByPaginationHandler(IApplicationDbContext context, )
//        {
//            _context = context;

//        }
//        public async Task<PaginatedList<UserDto>> Handle(GetUserQueryByPagination request, CancellationToken cancellationToken)

//        {
//            return await _context.Users
//           .Where(x => !string.IsNullOrEmpty(request.Name) ? x.UserName.Contains(request.Name) : true)
//           .OrderBy(x => x.UserName)
//           .Select(i => new UserDto
//           {
//               Id = i.Id,
//               Name = i.UserName,
//               Email = i.UserEmail,
//               Add = i.Address,
//               Number = i.Number,
//           })
//           .PaginatedListAsync(request.PageNumber, request.PageSize);



//        }

//    }
