using Cezo.API.Data;
using Cezo.API.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace Cezo.API.Repositories
{
    public class SQLArtistRepository: IArtistRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLArtistRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<String> CreateAsync(Artist artist)
        {
            await dbContext.AddAsync(artist);
            await dbContext.SaveChangesAsync();

            return "Artist created successfully!";
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            return await dbContext.Artists.ToListAsync();
        }

        public async Task<Artist> GetByIdAysnc(Guid id)
        {
            return await dbContext.Artists.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Artist> UpdateByIdAsync(Guid id, Artist artist)
        {
            var artistDomain = await dbContext.Artists.FirstOrDefaultAsync(x => x.Id == id);

            artistDomain.Name = artist.Name;
            artistDomain.Description = artist.Description;

            await dbContext.SaveChangesAsync();

            return artist;
        }
        public async Task<String> DeleteByIdAsync(Guid id)
        {
            var artistDomain = await dbContext.Artists.FirstOrDefaultAsync(x => x.Id == id);

            dbContext.Remove(artistDomain);
            await dbContext.SaveChangesAsync();

            return "Artist Deleted sucessfuly!";
        }
    }
}
