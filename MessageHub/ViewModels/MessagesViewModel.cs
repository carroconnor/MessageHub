using System.Collections.Generic;
using MessageHub.Models;

namespace MessageHub.ViewModels
{
    public class MessagesViewModel
    {
        public IEnumerable<Message> UpcomingMessages { get; set; }
        public bool ShowActions { get; set; }
    }
}