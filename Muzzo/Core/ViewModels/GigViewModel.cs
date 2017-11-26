﻿using Muzzo.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Muzzo.Core.ViewModels
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