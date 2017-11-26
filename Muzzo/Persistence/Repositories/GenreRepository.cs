using Muzzo.Core.Models;
using Muzzo.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Muzzo.Persistence.Repositories
{

    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GenreRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _dbContext.Genres.ToList();
        }
    }
}