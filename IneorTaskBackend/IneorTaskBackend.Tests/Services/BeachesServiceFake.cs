using IneorTaskBackend.Interfaces;
using IneorTaskBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace IneorTaskBackend.Tests.Services
{
    public class BeachesServiceFake : IBeachesService
    {
        public readonly List<Beach> Beaches = new ()
        {
            new Beach
            {
                Id = "2deae838-ed46-46d9-9634-f3bc35f44565",
                Name = "name 1",
                Description = "description 1",
                ImageUrl = "https://www.google.com",
                Country = "SI"
            },
            new Beach
            {
                Id = "08c1bcc8-5352-4cea-a065-0aef3a172c6a",
                Name = "name 2",
                Description = "description 2",
                ImageUrl = "https://www.google.com",
                Country = "SI"
            },
            new Beach
            {
                Id = "67819c88-fffb-4bd8-af0b-12ef808a0b70",
                Name = "name 3",
                Description = "description 3",
                ImageUrl = "https://www.google.com",
                Country = "SI"
            },
        };

        public Task<BeachesList> Get(int page, int perPage, string query, string sortBy)
        {
            var queriedItems = Beaches.Where((beach) =>
                string.IsNullOrWhiteSpace(query) ||
                beach.Name.ToLower().Contains(query.ToLower()) ||
                beach.Country.ToLower().Contains(query.ToLower())
            );

            var items = queriedItems.Skip(page * perPage).Take(perPage).ToList();
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                var sortProperty = typeof(Beach).GetProperty(sortBy);
                items = items.OrderBy((beach) => sortProperty.GetValue(beach)).ToList();
            }

            return Task.FromResult(new BeachesList
            {
                Items = items,
                TotalCount = queriedItems.Count(),
            });
        }

        public Task<Beach> Get(string id)
        {
            return Task.FromResult(Beaches.Find((beach) => beach.Id.Equals(id)));
        }

        public async Task<Beach> Create(Beach beach)
        {
            var exists = await Get(beach.Id);
            if (exists != null)
                return null;

            if (string.IsNullOrWhiteSpace(beach.Id))
                beach.Id = Guid.NewGuid().ToString();
            Beaches.Add(beach);
            return beach;
        }

        public async Task<ActionResult<Beach>> Update(string id, Beach beach)
        {
            var existing = await Get(id);
            if (existing == null)
                return null;

            existing.Name = beach.Name;
            existing.Description = beach.Description;
            existing.ImageUrl = beach.ImageUrl;
            existing.Country = beach.Country;
            return existing;
        }

        public async Task<Beach> Delete(string id)
        {
            var delete = await Get(id);
            if (delete != null)
                Beaches.Remove(delete);
            return delete;
        }
    }
}

