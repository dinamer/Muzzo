using Muzzo.Models;
using System.Collections.Generic;

namespace Muzzo.ViewModels
{
    public class GigViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}