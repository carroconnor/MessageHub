//using System;
//using System.ComponentModel.DataAnnotations;
//using Microsoft.Build.Framework;
//
//namespace MessageHub.Models
//{
//    public class Message
//    {
//        public int Id { get; set; }
//
//        public bool IsCanceled { get; set; }
//
//        public ApplicationUser Artist { get; set; }
//
//        [Required]
//        public string ArtistId { get; set; }
//
//        public DateTime DateTime { get; set; }
//
//        [Required]
//        public string Venue { get; set; }
//
//        public Genre Genre { get; set; }
//
//        [Required]
//        public byte GenreId { get; set; }
//    }
//}