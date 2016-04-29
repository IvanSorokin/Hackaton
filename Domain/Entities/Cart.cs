using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Cart : IEnumerable<Character>
    {
        public HashSet<int> CharactersIds{ get; set; }

        public Cart()
        {
            CharactersIds = new HashSet<int>();
        }

        IEnumerator<Character> IEnumerable<Character>.GetEnumerator()
        {
            return (IEnumerator<Character>) GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable) CharactersIds).GetEnumerator();
        }

        public void AddItem(int characterID)
        {
            CharactersIds.Add(characterID);
        }

        public void RemoveItem(int characterId)
        {
            CharactersIds.Remove(characterId);
        }
    }
}