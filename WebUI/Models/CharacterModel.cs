using Domain.Entities;

namespace WebUI.Models
{
    public class CharacterModel
    {
        public Character Character{ get; set; }
        public string ReturnUrl{ get; set; }

        public CharacterModel(Character character, string returnUrl)
        {
            Character = character;
            ReturnUrl = returnUrl;
        }
    }
}