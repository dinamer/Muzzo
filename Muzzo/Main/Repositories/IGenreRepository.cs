using Muzzo.Main.Models;
using System.Collections.Generic;

namespace Muzzo.Main.Repositories
{
    public interface IGenreRepository
    {
       IEnumerable<Genre> GetGenres();
    }
}