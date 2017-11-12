﻿using Muzzo.Models;
using System;
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

        public DateTime DateTime
        {
            get { return DateTime.Parse(string.Format("{0}, {1}", Date, Time)); }
        }
    }
}