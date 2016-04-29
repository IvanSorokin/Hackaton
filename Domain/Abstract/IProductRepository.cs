using System.Linq;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface ICharacterRepository
    {
        IQueryable<Character> Characters { get; }
    }
}
