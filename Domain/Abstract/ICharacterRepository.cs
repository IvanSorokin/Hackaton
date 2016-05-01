using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface ICharacterRepository
    {
        IQueryable<Character> Characters { get; }
        Task<Character> FindAsync(int id);
    }
}
