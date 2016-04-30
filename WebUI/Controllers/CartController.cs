using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private readonly ICharacterRepository repository;
        private readonly ICartProvider cartProvider;

        public CartController(ICharacterRepository rep, ICartProvider cartProvider)
        {
            repository = rep;
            this.cartProvider = cartProvider;
        }

        public PartialViewResult Cart()
        {
            var result = new List<Character>();
            foreach (var i in GetCart().CharactersIds)
            {
                var a = repository.Characters.FirstOrDefault(x => x.Id == i);
                if (a != null)
                    result.Add(a);
            }
            return PartialView("Cart",result);
        }
          
        [HttpPost]
        public RedirectResult AddToCart(int id, string returnUrl)
         {
            Character character = repository.Characters.FirstOrDefault(ch => ch.Id == id);
            if (character != null)
            {
                GetCart().AddItem(character.Id);
            }
            return new RedirectResult(returnUrl);

        }

        
        public RedirectResult RemoveFromCart(int id, string returnUrl)
        {
            Character character = repository.Characters.FirstOrDefault(ch => ch.Id == id);
            if (character != null)
            {
                GetCart().RemoveItem(character.Id);
            }
            return new RedirectResult(returnUrl);

        }

        private Cart GetCart()
        {
            Cart cart = cartProvider.GetCart(this);
            if (cart == null)
            {
                cart = new Cart();
                cartProvider.SetCart(this, cart);
            }
            return cart;
        }
    }
}