using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cezo.API.Models.Domains
{
    public class Song
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImgUrl { get; set; }

        [Required]
        [Url]
        public string SongUrl { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        [Required]
        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}
