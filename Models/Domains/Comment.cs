using System.ComponentModel.DataAnnotations;

namespace Cezo.API.Models.Domains
{
    public class Comment
    {
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
