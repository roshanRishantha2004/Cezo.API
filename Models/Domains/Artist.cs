using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cezo.API.Models.Domains
{
    public class Artist
    {
        public Guid Id { get; set; }


        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public String Name { get; set; }


        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Description { get; set; }

        public string? ImgUrl { get; set; }

        public string? PublicId { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
