using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private readonly ICharacterRepository repository;

        public CartController(ICharacterRepository rep)
        {
            repository = rep;
        }

        [HttpPost]
        public RedirectResult AddToCart(int id)
        {
            Character character = repository.Characters.FirstOrDefault(ch => ch.Id == id);
            if (character != null)
            {
                GetCart().AddItem(character.Id);
            }
            return new RedirectResult(Request.RawUrl);

        }

        [HttpDelete]
        public RedirectResult RemoveFromCart(int id)
        {
            Character character = repository.Characters.FirstOrDefault(ch => ch.Id == id);
            if (character != null)
            {
                GetCart().RemoveItem(character.Id);
            }
            return new RedirectResult(Request.RawUrl);

        }

        private Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}