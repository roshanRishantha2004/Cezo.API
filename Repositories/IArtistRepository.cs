using Cezo.API.Models.Domains;

namespace Cezo.API.Repositories
{
    public interface IArtistRepository
    {
        Task<String> CreateAsync(Artist artist);
        Task<List<Artist>> GetAllAsync();
        Task<Artist> GetByIdAysnc(Guid id);
        Task<Artist> UpdateByIdAsync(Guid id, Artist artist);
        Task<String> DeleteByIdAsync(Guid id);
    }
}
