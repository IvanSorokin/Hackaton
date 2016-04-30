using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class VoteRepository : IVoteRepository
    {
        private readonly EFDBContext context = new EFDBContext();

        public IQueryable<Vote> Votes => context.Votes;

        public void Add(Vote vote, HashSet<int> charactersIds)
        {
            context.Votes.Add(vote);

            var position = 0;
            foreach (var id in charactersIds)
            {
                var character = context.Characters.FirstOrDefault(i => i.Id == id);
                var voteItem = new VoteItem()
                {
                    Character = character,
                    Position = position,
                    Vote = vote
                };
                context.Entry(character).State = EntityState.Unchanged;
                context.VoteItems.Add(voteItem);
                position++;
            }

            context.SaveChangesAsync();
        }

        public List<Character> CharactersPerWeek(int weekId, Guid userId)
        {
            var characters = context.VoteItems
                 .Where(x => x.Vote.UserID == userId && x.Vote.WeekId == weekId)
                 .Select(x => x.Character);
            return characters.ToList();
        }

        public bool Contains(int weekId, Guid userId)
        {
            return context.Votes.Any(v => v.UserID == userId && v.WeekId == weekId);
        }
    }
}