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

        [HttpGet("search/{query}/{page?}")]
        public async Task<IActionResult> Search(string query, int page = 0)
        {
            var movies = await _mediator.Send(new GenericSearchQuery(query, page));

            return Ok(movies);
        }
    }
}
