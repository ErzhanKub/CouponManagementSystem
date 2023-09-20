using Application.Users.Commands;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> Create(CreateUserCommand request)
        {
            var user = await _mediator.Send(request);
            return Ok(user);
        }
        [HttpPost("GetByUsername")]
        public async Task<IActionResult> GetByUsername(GetByUsernameQuery query)
        {
            var user = await _mediator.Send(query);
            return Ok(user);
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand query)
        {
            await _mediator.Send(query);
            return Ok();
        }
    }
}
