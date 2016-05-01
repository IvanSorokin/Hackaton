using System;

namespace Domain.Entities
{
    public class Message
    {
        public int Id{ get; set; }
        public Guid UserId{ get; set; }
        public string Content{ get; set; }
        public int CharacterId{ get; set; }
        public string UserName{ get; set; }
    }
}