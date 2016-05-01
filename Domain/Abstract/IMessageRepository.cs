using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        void Add(Message message);
        void Remove(Message message);
        List<Message> GetMessagesForCharacter(int characterId);
    }
}