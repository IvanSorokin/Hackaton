using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VoteItem
    {
        public int VoteItemId { get; set; }
        public int VoteId { get; set; }
        public int Position { get; set; }
        public int HeroId { get; set; }
    }
}
