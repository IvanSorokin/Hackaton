using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private readonly ICharacterRepository repository;
        private readonly ICartProvider cartProvider;
        private readonly IWeekProvider weekProvider;
        private readonly IVoteRepository voteRepository;

        public CartController(ICharacterRepository rep, ICartProvider cartProvider, 
            IWeekProvider weekProvider, IVoteRepository voteRepository)
        {
            repository = rep;
            this.cartProvider = cartProvider;
            this.weekProvider = weekProvider;
            this.voteRepository = voteRepository;
        }

        public PartialViewResult Cart()
        {
            var result = new List<Character>();
            var cart = GetCart();
            foreach (var i in cart.CharactersIds)
            {
                var a = repository.Characters.FirstOrDefault(x => x.Id == i);
                if (a != null)
                    result.Add(a);
            }
            return PartialView("Cart",new CartViewModel(result, cart));
        }
          
        [HttpPost]
        public RedirectResult AddToCart(int id, string returnUrl)
         {
            Character character = repository.Characters.FirstOrDefault(ch => ch.Id == id);
            if (character != null)
            {
                var cart = GetCart();
                if (cart.Cash > (double) character.Cost && !cart.Contains(character.Id))
                {
                    cart.Cash -= (double) character.Cost;
                    cart.AddItem(character.Id);
                }
            }
            return new RedirectResult(returnUrl);

        }

        [HttpPost]
        public RedirectResult SubmitVotes(string returnUrl)
        {
            var weekId = weekProvider.GetWeek();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var vote = new Vote() {UserID = userId, WeekId = weekId};
            if (voteRepository.Contains(weekId, userId))
                return new RedirectResult(returnUrl);

            var cart = GetCart();
            voteRepository.Add(vote, cart.CharactersIds);
            cartProvider.SetCart(this, new Cart());
            return new RedirectResult(returnUrl);
        }
        
        public RedirectResult RemoveFromCart(int id, string returnUrl)
        {
            var cart = GetCart();
            if (cart.CharactersIds.Contains(id))
            {
                Character character = repository.Characters.FirstOrDefault(ch => ch.Id == id);
                if (character != null)
                {
                    cart.Cash += (double)character.Cost;
                    cart.RemoveItem(character.Id);
                }
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


/*
{SELECT 
    [Extent1].[VoteID] AS [VoteID], 
    [Extent1].[UserID] AS [UserID], 
    [Extent1].[WeekId] AS [WeekId]
    FROM [dbo].[Votes] AS [Extent1]}
*/
