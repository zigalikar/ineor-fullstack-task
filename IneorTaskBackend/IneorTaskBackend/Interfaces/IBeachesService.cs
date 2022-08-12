using System.Threading.Tasks;
using IneorTaskBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace IneorTaskBackend.Interfaces
{
    public interface IBeachesService
    {
        /// <summary>
        /// Gets a list of all beaches stored in the database
        /// </summary>
        /// <returns>List of beaches</returns>
        Task<BeachesList> Get(int page, int perPage, string query, string sortBy);

        /// <summary>
        /// Gets a particular beach from the database
        /// </summary>
        /// <param name="id">ID of the beach to search for</param>
        /// <returns>Beach with the specified ID or null if not found</returns>
        Task<Beach> Get(string id);

        /// <summary>
        /// Adds a new beach to the database
        /// </summary>
        /// <param name="beach">Beach to add</param>
        /// <returns>The created beach or null if a beach with the same ID already exists</returns>
        Task<Beach> Create(Beach beach);

        /// <summary>
        /// Updates a beach in the database
        /// </summary>
        /// <param name="id">ID of the beach to update</param>
        /// <param name="beach">Data to update with</param>
        /// <returns>The updated beach or null if a beach with the specified ID doesn't exist</returns>
        Task<ActionResult<Beach>> Update(string id, Beach beach);

        /// <summary>
        /// Deletes a beach
        /// </summary>
        /// <param name="id">ID of the beach to delete</param>
        /// <returns>The deleted beach or null if a beach with the specified ID doesn't exist</returns>
        Task<Beach> Delete(string id);
    }
}
