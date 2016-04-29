using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SearchParameters
    {
        public Sex Sex{ get; set; }
        public string Name{ get; set; }
        public bool IsAlive{ get; set; }
    }
}