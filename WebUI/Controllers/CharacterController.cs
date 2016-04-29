using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterRepository repository;
        public CharacterController(ICharacterRepository productRepository)
        {
            this.repository = productRepository;
        }
        public ViewResult List()
        {
            return View(repository.Characters);
        }
    }
}
