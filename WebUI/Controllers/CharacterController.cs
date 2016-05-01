using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebUI.Models;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterRepository repository;
        private readonly IVoteRepository voteRepository;
        private readonly IUserProvider userProvider;
        private readonly IWeekProvider weekProvider;
        private readonly IMessageRepository messageRepository;


        public CharacterController (
            ICharacterRepository productRepository, 
            IVoteRepository voteRepository, 
            IUserProvider userProvider,
            IWeekProvider weekProvider,
            IMessageRepository messageRepository)
        {
            this.repository = productRepository;
            this.voteRepository = voteRepository;
            this.weekProvider = weekProvider;
            this.messageRepository = messageRepository;
            this.userProvider = userProvider;
        }

        private bool UserVoted()
        {
            var userId = userProvider.GetId(this);
            if (userId == Guid.Empty)
                return false;
            return voteRepository.Contains(weekProvider.GetWeek(),userId);
        }

        public List<Character> FilterByField(string fieldName, string fieldValue)
        {
            return repository.Characters.ToList()
                .Where(x => x.GetType().GetProperty(fieldName).GetValue(x).ToString() == fieldValue)
                .ToList();

        }
        public List<Character> FilterByParameters(string name, LifeStatus status, Sex sex)
        {
            return repository.Characters
                .Where(c => c.Name.Contains(name) && c.LifeStatus == status && c.Sex == sex).ToList();
        }


        [HttpGet]
        public ViewResult AdvancedList(string name, LifeStatus status, Sex sex)
        {
            var view = View("List",new MainModel(FilterByParameters(name, status, sex), Request.RawUrl, UserVoted()));
            view.ViewBag.Name = name;
            view.ViewBag.LifeStatus = status;
            view.ViewBag.Sex = sex;
            return view;
        }

        [HttpPost]
        public ViewResult List(string name, LifeStatus status, Sex sex)
        {

            var backUrl = string.Format("/Character/AdvancedList?name={0}&status={1}&sex={2}", name, status, sex);
            var view = View(new MainModel(FilterByParameters(name, status, sex), backUrl, UserVoted()));
            view.ViewBag.Name = name;
            view.ViewBag.LifeStatus = status;
            view.ViewBag.Sex = sex;
            return view;
        }

        public ViewResult List(string fieldName, string fieldValue)
        {
            if (fieldValue == null && fieldName == null)
                return View(new MainModel(repository.Characters, Request.RawUrl, UserVoted()));
            return View(new MainModel(FilterByField(fieldName, fieldValue), Request.RawUrl, UserVoted()));
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await repository.FindAsync((int)id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(Tuple.Create(character, messageRepository.GetMessagesForCharacter(character.Id)));
        }
    }
}
