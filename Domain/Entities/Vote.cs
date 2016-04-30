using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vote
    {
        protected bool Equals(Vote other)
        {
            return VoteID == other.VoteID && UserID.Equals(other.UserID) && WeekId == other.WeekId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vote) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = VoteID;
                hashCode = (hashCode*397) ^ UserID.GetHashCode();
                hashCode = (hashCode*397) ^ WeekId;
                return hashCode;
            }
        }

        public int VoteID { get; set; }
        public Guid UserID { get; set; }
        public int WeekId { get; set; }
    }
}
