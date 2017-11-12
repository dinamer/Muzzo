using Muzzo.Models;
using System.Collections.Generic;

namespace Muzzo.ViewModels
{
    public class AddGigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}