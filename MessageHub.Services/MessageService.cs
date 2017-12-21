using System;
using MessageHub.Data;
using MessageHub.Models;

namespace MessageHub.Services
{
    class MessageService
    {

        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(CreateMessage model)
        {
            var message = new Message
            {
                ArtistId = _userId.ToString(),
                DateTime = getDateTime(model),
                GenreId = model.Genre,
                Venue = model.Message
            };

            var ctx = new ApplicationDbContext();
            ctx.Messages.Add(message);
            return ctx.SaveChanges() == 1;
        }

        private DateTime getDateTime(CreateMessage model)
        {
            return DateTime.Parse(string.Format("{0} {1}",model.Date, model.Time));
        }
    }
}
