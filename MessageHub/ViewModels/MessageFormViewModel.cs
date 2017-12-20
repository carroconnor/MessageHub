using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using MessageHub.Controllers;
using MessageHub.Models;

namespace MessageHub.ViewModels
{
    public class MessageFormViewModel : IEnumerable
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

        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<MessagesController, ActionResult>> update =
                    (c => c.Update(this));
                Expression<Func<MessagesController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0 ) ? update : create;
                
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}