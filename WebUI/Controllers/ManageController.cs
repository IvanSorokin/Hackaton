using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebUI.Models;
using WebUI.Infrastructure;
using Domain.Abstract;

namespace WebUI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ICharacterRepository repository;
        private IVoteRepository voteRepository;
        private IUserProvider userProvider;
        private IWeekProvider weekProvider;

        public ManageController(
            ICharacterRepository repository, 
            IVoteRepository voteRepository, 
            IUserProvider userProvider, 
            IWeekProvider weekProvider)
        {
            this.repository = repository;
            this.voteRepository = voteRepository;
            this.userProvider = userProvider;
            this.weekProvider = weekProvider;
        }

        public ActionResult Manage()
        {
            var userId = userProvider.GetId(this);
            var weekId = weekProvider.GetWeek();
            var result = voteRepository.CharactersPerWeek(weekId, userId);
            return View(new ManageModel() { Characters = result});
        }
    }
}