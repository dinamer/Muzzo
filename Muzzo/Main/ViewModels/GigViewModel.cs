﻿using Muzzo.Main.Models;
using System.Collections.Generic;
using System.Linq;

namespace Muzzo.Main.ViewModels
{
    public class GigViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances{ get; set; }
    }
}