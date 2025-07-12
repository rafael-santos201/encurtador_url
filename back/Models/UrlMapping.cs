using System.ComponentModel.DataAnnotations;

namespace encurtador_url.back.Models
{
    public class UrlMapping
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Url]
        public string OriginalUrl { get; set; } = string.Empty;

        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string ShortCode { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
