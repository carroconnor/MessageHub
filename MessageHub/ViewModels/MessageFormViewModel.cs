using System.Collections.Generic;
using MessageHub.Models;

namespace MessageHub.ViewModels
{
    public class MessageFormViewModel
    {
        public string Message { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}