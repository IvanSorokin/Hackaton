using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Models
{
    public class MainModel
    {
        public IEnumerable<Character> Characters{ get; set; }
        public string ReturnUrl{ get; set; }
        public bool UserVoted { get; set; }

        public MainModel(IEnumerable<Character> characters, string returnUrl, bool voted)
        {
            Characters = characters;
            ReturnUrl = returnUrl;
            UserVoted = voted;
        }
    }
}