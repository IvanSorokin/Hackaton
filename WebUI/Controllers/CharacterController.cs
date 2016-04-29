using Domain.Abstract;
using Domain.Entities;
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

        public List<Character> FilterByField(string fieldName, string fieldValue)
        {
            return repository.Characters.ToList()
                .Where(x => x.GetType().GetProperty(fieldName).GetValue(x).ToString() == fieldValue)
                .ToList();

        }

        //[HttpPost]
        //public ViewResult List(string name, bool isAlive, Sex sex )
        //{
        //    return View(repository.Characters);
        //}

        public ViewResult List(string fieldName, string fieldValue)
        {
            if (fieldValue == null && fieldName == null)
                return View(repository.Characters);
            return View(FilterByField(fieldName, fieldValue));
        }
    }
}
