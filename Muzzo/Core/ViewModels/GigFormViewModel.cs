using Muzzo.Controllers;
using Muzzo.Main.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Muzzo.Main.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [ValidDate(ErrorMessage = "The Date field must be future date.")]
        public string Date { get; set; }

        [Required]
        [ValidTime(ErrorMessage = "The Time field must be in the 'hh:mm' format.")]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }

        public string ActionName {

            get {

                Expression<Func<GigController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<GigController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0}, {1}", Date, Time));
        }
    }
}