using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Models
{
    public class CartViewModel
    {
        public CartViewModel(List<Character> characters, Cart cart)
        {
            Characters = characters;
            Cart = cart;
        }

        public List<Character> Characters { get; set; }
        public Cart Cart { get; set; } 
    }
}