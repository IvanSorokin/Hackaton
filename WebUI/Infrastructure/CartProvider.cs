using System;
using Domain.Entities;
using System.Web.Mvc;


namespace WebUI.Infrastructure
{
    public class CartProvider : ICartProvider
    {
        public Cart GetCart(Controller controller) => controller.Session["Cart"] as Cart;

        public void SetCart(Controller controller, Cart cart)
        {
            controller.Session["Cart"] = cart;
        }
    }
}