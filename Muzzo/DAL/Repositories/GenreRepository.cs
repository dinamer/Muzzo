using Muzzo.Main.Models;
using Muzzo.Main.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Muzzo.DAL.Repositories
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