using CatalogApi.Contracts;
using CatalogApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            (_moviesService) = (moviesService);
        }

        [HttpGet(Name = nameof(GetAllMovies))]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var result = await this._moviesService.GetAll();
            return Ok(result);
        }

        [HttpGet("os")]
        public IActionResult GetOs()
        {
            return Ok(Environment.OSVersion);
        }

        [HttpGet("{id}", Name = nameof(GetMovieById))]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            try
            {
                var result = await this._moviesService.GetById(id);
                return Ok(result);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("item cannot be found"))
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}", Name = nameof(DeleteMovie))]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            try
            {
                var result = await this._moviesService.DeleteMovie(id);
                return Ok(result);
            }
            catch (Exception ex) when (ex.Message.Contains("item cannot be found"))
            {
                return NotFound();
            }
        }

        [HttpPost(Name = nameof(AddNewMovie))]
        public async Task<ActionResult<Movie>> AddNewMovie(Movie m)
        {
            var result = await this._moviesService.AddMovie(m);
            return Created($"movies/{result.ID}", result);
        }

    }
}
