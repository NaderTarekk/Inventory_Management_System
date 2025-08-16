using InventoryManagementSystem.Application.Features.Products.Commands.ChangeIsActive;
using InventoryManagementSystem.Application.Features.Users.Commands.AddUser;
using InventoryManagementSystem.Application.Features.Users.Commands.ChangeUserIsActive;
using InventoryManagementSystem.Application.Features.Users.Commands.DTOs;
using InventoryManagementSystem.Application.Features.Users.Commands.UpdateUser;
using InventoryManagementSystem.Application.Features.Users.Queries.CheckExistEmail;
using InventoryManagementSystem.Application.Features.Users.Queries.GetAllUsers;
using InventoryManagementSystem.Application.Features.Users.Queries.GetUserById;
using InventoryManagementSystem.Application.Features.Users.Queries.LoginUser;
using InventoryManagementSystem.Domain.DTOs;
using InventoryManagementSystem.Infrastructure.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly InventoryDbContext _ctx;
        IMediator _mediator;
        public UsersController(IMediator mediator, InventoryDbContext ctx)
        {
            _mediator = mediator;
            _ctx = ctx;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] UserDto? cmd)
        {
            var result = await _mediator.Send(new CreateUserCommand(cmd));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update(UserDto data)
        {
            var result = await _mediator.Send(new UpdateUserCommand(data));
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> ChangeIsActive(ChaneUserIsActive data)
        {
            var result = await _mediator.Send(new ChangeUserIsActiveCommand(data.id, data.activity));
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> CheckExistEmail(string email)
        {
            var result = await _mediator.Send(new CheckExistEmailQuery(email));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserDto user)
        {
            var result = await _mediator.Send(new LoginUserQuery(user));
            return Ok(new { role = result });
        }
    }
}
