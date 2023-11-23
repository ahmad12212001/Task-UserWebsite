using Application.Users.Command.CreateUser;
using Application.Users.Command.DeleteCommand;
using Application.Users.Command.Dtos;
using Application.Users.Command.UpdateUser;
using Application.Users.Queries.GetUser;
using Application.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<UserDto>>> Get()
        {

            var UserQuery = new GetUsersQuery();
            return await _mediator.Send(UserQuery);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            return await _mediator.Send(new GetUserQuery() { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, UpdateUserCommand command)
        {
            var course = await _mediator.Send(new GetUserQuery() { Id = id });
            if (course == null)
            {
                return NotFound();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _mediator.Send(new DeleteUserCommand { Id = id });
        }
    }
}
