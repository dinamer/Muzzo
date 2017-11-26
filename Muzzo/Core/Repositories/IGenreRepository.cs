using Muzzo.Core.Models;
using System.Collections.Generic;

namespace Muzzo.Core.Repositories
{
    public interface IGenreRepository
    {
       IEnumerable<Genre> GetGenres();
    }
}