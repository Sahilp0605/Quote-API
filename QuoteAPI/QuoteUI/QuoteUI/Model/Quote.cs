using System.ComponentModel.DataAnnotations;

namespace QuoteUI.Model
{
    public class Quote
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Author field is required.")]
        public string Author { get; set; }
        public List<string>? Tags { get; set; } = new List<string>();
        [Required(ErrorMessage = "The Quote field is required.")]
        public string QuoteName { get; set; }
    }
}
