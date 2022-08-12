using System.Linq;
using System.Threading.Tasks;
using IneorTaskBackend.Model;
using IneorTaskBackend.Context;
using Microsoft.AspNetCore.Mvc;
using IneorTaskBackend.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace IneorTaskBackend.Services
{
    public class BeachesService : IBeachesService
    {
        private readonly AppDbContext _dbContext;

        public BeachesService(ILogger<BeachesService> logger, AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets a list of all beaches stored in the database
        /// </summary>
        /// <returns>List of beaches</returns>
        public async Task<BeachesList> Get(int page, int perPage, string query, string sortBy)
        {
            var queriedItems = _dbContext.Beaches.Where((beach) =>
                string.IsNullOrWhiteSpace(query) ||
                beach.Name.ToLower().Contains(query.ToLower()) ||
                beach.Country.ToLower().Contains(query.ToLower())
            );

            var items = await queriedItems.Skip(page * perPage).Take(perPage).ToListAsync();
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                var sortProperty = typeof(Beach).GetProperty(sortBy);
                items = items.OrderBy((beach) => sortProperty.GetValue(beach)).ToList();
            }

            return new BeachesList
            {
                Items = items,
                TotalCount = await queriedItems.CountAsync(),
            };
        }

        /// <summary>
        /// Gets a particular beach from the database
        /// </summary>
        /// <param name="id">ID of the beach to search for</param>
        /// <returns>Beach with the specified ID or null if not found</returns>
        public async Task<Beach> Get(string id)
        {
            return await _dbContext.Beaches.FirstOrDefaultAsync((b) => b.Id.Equals(id));
        }

        /// <summary>
        /// Adds a new beach to the database
        /// </summary>
        /// <param name="beach">Beach to add</param>
        /// <returns>The created beach or null if a beach with the same ID already exists</returns>
        public async Task<Beach> Create(Beach beach)
        {
            try
            {
                var exists = await Get(beach.Id);
                if (exists != null)
                    return null;

                var created = await _dbContext.Beaches.AddAsync(beach);
                await _dbContext.SaveChangesAsync();
                _dbContext.ChangeTracker.Clear();
                return created.Entity;
            }
            catch
            {
                _dbContext.ChangeTracker.Clear();
                throw;
            }
        }

        /// <summary>
        /// Updates a beach in the database
        /// </summary>
        /// <param name="id">ID of the beach to update</param>
        /// <param name="beach">Data to update with</param>
        /// <returns>The updated beach or null if a beach with the specified ID doesn't exist</returns>
        public async Task<ActionResult<Beach>> Update(string id, Beach beach)
        {
            try
            {
                var existing = await Get(id);
                if (existing == null)
                    return null;

                existing.Name = beach.Name;
                existing.Description = beach.Description;
                existing.ImageUrl = beach.ImageUrl;
                existing.Country = beach.Country;
                await _dbContext.SaveChangesAsync();
                _dbContext.ChangeTracker.Clear();
                return existing;
            }
            catch
            {
                _dbContext.ChangeTracker.Clear();
                throw;
            }
        }

        /// <summary>
        /// Deletes a beach
        /// </summary>
        /// <param name="id">ID of the beach to delete</param>
        /// <returns>The deleted beach or null if a beach with the specified ID doesn't exist</returns>
        public async Task<Beach> Delete(string id)
        {
            try
            {
                var delete = await Get(id);
                if (delete != null)
                {
                    _dbContext.Remove(delete);
                    await _dbContext.SaveChangesAsync();
                }
                return delete;
            }
            catch
            {
                _dbContext.ChangeTracker.Clear();
                throw;
            }
        }
    }
}
