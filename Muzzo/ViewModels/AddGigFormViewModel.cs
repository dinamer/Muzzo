using Muzzo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Muzzo.ViewModels
{
    public class AddGigFormViewModel
    {
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

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0}, {1}", Date, Time));
        }
    }
}