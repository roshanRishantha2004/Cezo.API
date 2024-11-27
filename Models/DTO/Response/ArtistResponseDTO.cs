using System.Runtime.CompilerServices;

namespace Cezo.API.Models.DTO.Response
{
    public class ArtistResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string PublicId { get; set; }
        public DateTime JoinedDate { get; set; }

    }
}
