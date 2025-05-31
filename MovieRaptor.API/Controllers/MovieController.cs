using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieRaptor.Application.Queries.Movie;

namespace MovieRaptor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _mediator.Send(new GetByIdQuery(id));
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

    }
}
