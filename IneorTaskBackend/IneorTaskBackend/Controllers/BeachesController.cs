using System.Threading.Tasks;
using IneorTaskBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IneorTaskBackend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace IneorTaskBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeachesController : ControllerBase
    {
        private readonly IBeachesService _beachesService;

        public BeachesController(IBeachesService beachesService)
        {
            _beachesService = beachesService;
        }

        /// <summary>
        /// Gets all beaches
        /// </summary>
        /// <param name="page">Pagination - page</param>
        /// <param name="perPage">Pagination - how many elements per page to return</param>
        /// <param name="query">Query to search by</param>
        /// <param name="sortBy">Property to sort by</param>
        /// <returns>List of all beaches</returns>
        [HttpGet]
        public Task<BeachesList> GetAll([Required] int page, [Required] int perPage, string query, string sortBy) => _beachesService.Get(page, perPage, query, sortBy);

        /// <summary>
        /// Gets a singular beach with specified ID
        /// </summary>
        /// <param name="id">ID to search for</param>
        /// <returns>Beach with the specified ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Beach>> Get(string id)
        {
            var beach = await _beachesService.Get(id);
            return beach is null ? NotFound() : beach;
        }

        /// <summary>
        /// Creates a new beach
        /// </summary>
        /// <param name="beach">Data</param>
        /// <returns>Created beach</returns>
        [HttpPost()]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Beach>> Create(Beach beach)
        {
            if (beach == null)
                return BadRequest("No data provided");

            if (!ModelState.IsValid)
                return BadRequest("Invalid data provided");

            var created = await _beachesService.Create(beach);
            return created is null ? BadRequest($"Object with ID '{beach.Id}' already exists") : created;
        }

        /// <summary>
        /// Updates a beach
        /// </summary>
        /// <param name="id">ID of the beach to update</param>
        /// <param name="beach">Data</param>
        /// <returns>Updated beach</returns>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Beach>> Update(string id, Beach beach)
        {
            if (beach == null)
                return BadRequest("No data provided");

            if (!ModelState.IsValid || !beach.Id.Equals(id))
                return BadRequest("Invalid data provided");

            var updated = await _beachesService.Update(id, beach);
            return updated is null ? NotFound() : updated;
        }

        /// <summary>
        /// Deletes a beach
        /// </summary>
        /// <param name="id">ID of the beach to delete</param>
        /// <returns>Deleted beach</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Beach>> Delete(string id)
        {
            var deleted = await _beachesService.Delete(id);
            return deleted is null ? NotFound() : deleted;
        }
    }
}
