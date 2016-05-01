using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFCharacterRepository : ICharacterRepository
    {
        private EFDBContext context = new EFDBContext();
        public IQueryable<Character> Characters => context.Characters;

        public async Task<Character> FindAsync(int id)
        {
            return await context.Characters.FindAsync(id);
        }
    }
}
