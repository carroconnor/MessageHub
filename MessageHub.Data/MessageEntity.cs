using System;
using System.ComponentModel.DataAnnotations;
using MessageHub.Models;

namespace MessageHub.Data
{
    class MessageEntity
    {

        public int Id { get; set; }

        public bool IsCanceled { get; set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Microsoft.Build.Framework.Required]
        public byte GenreId { get; set; }

    }
}
