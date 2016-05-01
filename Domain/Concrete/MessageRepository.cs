using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        private readonly EFDBContext context = new EFDBContext();
        public IQueryable<Message> Messages => context.Messages;

        public void Add(Message message)
        {
            var character = context.Characters.FirstOrDefault(i => i.Id == message.CharacterId);
            context.Entry(character).State = EntityState.Unchanged;
            context.Messages.AddOrUpdate(message);
        }

        public void Remove(Message message)
        {
            context.Messages.Remove(message);
            context.SaveChangesAsync();
        }

        public List<Message> GetMessagesForCharacter(int characterId)
        {
            return Messages.Where(m => m.CharacterId == characterId).ToList();
        }
    }
}