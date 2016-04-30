using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Web.Mvc;

namespace WebUI.Infrastructure
{
    public interface ICartProvider
    {
        Cart GetCart(Controller controller);
        void SetCart(Controller controller, Cart cart);
    }
}
