using Domain.Entities;

namespace WebUI.Models
{
    public class CharacterModel
    {
        public Character Character{ get; set; }
        public string ReturnUrl{ get; set; }
        public bool Voted { get; set; }

        public CharacterModel(Character character, string returnUrl, bool voted)
        {
            Character = character;
            ReturnUrl = returnUrl;
            Voted = voted;
        }
    }
}