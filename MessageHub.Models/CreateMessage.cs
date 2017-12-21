using System.ComponentModel.DataAnnotations;
using MessageHub.ViewModels;

namespace MessageHub.Models
{
    public class CreateMessage
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
    }
}
