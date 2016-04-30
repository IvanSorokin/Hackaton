using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Cart : IEnumerable<int>
    {
        public HashSet<int> CharactersIds{ get; set; }
        public double Cash{ get; set; }

        public Cart()
        {
            CharactersIds = new HashSet<int>();
            Cash = 30;
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return (IEnumerator<int>) GetEnumerator();
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