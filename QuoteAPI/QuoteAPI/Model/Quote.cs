using System.ComponentModel.DataAnnotations;

namespace QuoteAPI.Model
{
    public class Quote
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Author { get; set; } = null;
        public List<string>? Tags { get; set; } = null;
        public string? QuoteName { get; set; } = null;
    }
}
