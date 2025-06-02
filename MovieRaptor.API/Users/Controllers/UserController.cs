using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MovieRaptor.Application.Users.User.Commands;
using MovieRaptor.Application.Users.User.Queries;

namespace MovieRaptor.API.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _mediator.Send(new GetByIdQuery(id));
            if (user == null)
                return NotFound();

            return Ok(user);            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUserDTO user)
        {
            var userId = await _mediator.Send(new CreateCommand(user));

            return Ok(userId);
        }        
    }
}
