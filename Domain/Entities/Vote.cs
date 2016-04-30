using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vote
    {
        public int VoteID { get; set; }
        public Guid UserID { get; set; }
        public int WeekId { get; set; }
    }
}
