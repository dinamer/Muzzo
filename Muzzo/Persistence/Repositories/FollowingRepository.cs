using Muzzo.Core.Models;
using Muzzo.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Muzzo.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void AddFollowing(Following following)
        {
            _dbContext.Followings.Add(following);
        }

        public void RemoveFollowing(Following following)
        {
            _dbContext.Followings.Remove(following);
        }

        public IEnumerable<ApplicationUser> GetFollowersByArtist(string artistId)
        {
            return _dbContext.Followings.Where(f => f.FolloweeId == artistId).Select(f => f.Follower).ToList();
        }

        public Following GetFollowing(string followeeId, string followerId)
        {
            return _dbContext.Followings.SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == followerId);


        }

        public IEnumerable<ApplicationUser> GetFolloweesByUser(string followerId)
        {
            return _dbContext.Followings
                              .Where(f => f.FollowerId == followerId)
                              .Select(f => f.Followee)
                              .ToList();
        }

    }
}