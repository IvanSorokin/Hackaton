using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities 
{
    public enum Sex { Female, Male};

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public bool IsAlive { get; set; }
        public Sex Sex { get; set; }
        public string PicturePath { get; set; }
    }
}
