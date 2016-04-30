
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteItem> VoteItems { get; set; }
    }
}
