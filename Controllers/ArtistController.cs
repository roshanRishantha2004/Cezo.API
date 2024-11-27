using Cezo.API.Models.Domains;
using Cezo.API.Models.DTO.Request;
using Cezo.API.Models.DTO.Response;
using Cezo.API.Repositories;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cezo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository artistRepository;
        private readonly IPhotoRepository photoRepository;

        public ArtistController(IArtistRepository artistRepository, IPhotoRepository photoRepository)
        {
            this.artistRepository = artistRepository;
            this.photoRepository = photoRepository;
        }

        // POST: api/artist - Create an artist
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArtistRequestAddDTO artistDTO)
        {
            if (artistDTO == null)
            {
                return BadRequest("Artist data is required");
            }

            var artistDomains = new Artist()
            {
                Id = Guid.NewGuid(),
                Name = artistDTO.Name,
                Description = artistDTO.Description,
            };

            var response = await artistRepository.CreateAsync(artistDomains);

            return Ok(response);
        }

        // POST: api/artist/upload-image/{id} - Upload image for a specific artist
        [HttpPost("upload-image/{id:guid}")]
        public async Task<IActionResult> UploadImageAsync([FromRoute] Guid id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var response = await photoRepository.UploadImageAsync(file);

            var user = await artistRepository.GetByIdAysnc(id);
            if (user == null)
            {
                return NotFound("Artist not found.");
            }

            user.ImgUrl = response.SecureUrl.AbsoluteUri;
            user.PublicId = response.PublicId;

           var responseDto =  await artistRepository.UpdateByIdAsync(id, user);

            var artistDto = new ArtistResponseDTO()
            {
                Id = responseDto.Id,
                Name = responseDto.Name,
                Description = responseDto.Description,
                ImgUrl = responseDto.ImgUrl,
                PublicId = responseDto.PublicId,
                JoinedDate = responseDto.JoinedDate
            };// Ensure the updated user is saved

            return Ok(artistDto);
        }

        // GET: api/artist - Get all artists
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var artistDomains = await artistRepository.GetAllAsync();

            if (artistDomains == null || artistDomains.Count == 0)
            {
                return NotFound("No artists found.");
            }

            var artistDto = new List<ArtistResponseDTO>();

            foreach (var item in artistDomains)
            {
                artistDto.Add(new ArtistResponseDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    ImgUrl = item.ImgUrl
                });
            }

            return Ok(artistDto);
        }

        // GET: api/artist/{id} - Get a specific artist by ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var artistDomains = await artistRepository.GetByIdAysnc(id);

            if (artistDomains == null)
            {
                return NotFound("Artist not found.");
            }

            var artistDto = new ArtistResponseDTO()
            {
                Id = artistDomains.Id,
                Name = artistDomains.Name,
                ImgUrl = artistDomains.ImgUrl,
                JoinedDate = artistDomains.JoinedDate
            };

            return Ok(artistDto);
        }

        // PUT: api/artist/{id} - Update an artist by ID
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] ArtistUpdateDTO artistUpdateDTO)
        {
            if (artistUpdateDTO == null)
            {
                return BadRequest("Artist data is required.");
            }

            var artistDomain = new Artist()
            {
                Name = artistUpdateDTO.Name,
                Description = artistUpdateDTO.Description,
            };

            var responseDto = await artistRepository.UpdateByIdAsync(id, artistDomain);

            var artistDto = new ArtistResponseDTO()
            {
                Id = responseDto.Id,
                Name = responseDto.Name,
                Description = responseDto.Description,
                ImgUrl = responseDto.ImgUrl,
                PublicId = responseDto.PublicId,
                JoinedDate = responseDto.JoinedDate
            };

            return Ok(artistDto);
        }

        // DELETE: api/artist/{id} - Delete an artist by ID
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] Guid id)
        {
            var response = await artistRepository.DeleteByIdAsync(id);

            if (string.IsNullOrEmpty(response))
            {
                return NotFound("Artist not found.");
            }

            return Ok("Artist deleted successfully!");
        }
    }
}
