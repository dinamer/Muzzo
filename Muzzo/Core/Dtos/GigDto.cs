using System;

namespace Muzzo.Core.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }

        public DateTime GigDateTime { get; set; }

        public string Venue { get; set; }

        public bool IsCanceled { get;  set; }

        public GenreDto Genre { get; set; }

        public UserDto Artist { get; set; }

    }
}