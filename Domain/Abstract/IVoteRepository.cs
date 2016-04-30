using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IVoteRepository
    {
        IQueryable<Vote> Votes { get; }
        void Add(Vote vote, HashSet<int> charactersIds);
        bool Contains(int weekId, Guid userId);
    }
}