using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
    class EFDBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
    }
}
