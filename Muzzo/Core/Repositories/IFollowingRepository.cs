﻿using Muzzo.Core.Models;
using System.Collections.Generic;

namespace Muzzo.Core.Repositories
{
    public interface IFollowingRepository
    {
        void AddFollowing(Following following);
        void RemoveFollowing(Following following);
        IEnumerable<ApplicationUser> GetFollowersByArtist(string artistId);
        IEnumerable<ApplicationUser> GetFolloweesByUser(string followerId);
        Following GetFollowing(string followeeId, string followerId);
      
    }
}