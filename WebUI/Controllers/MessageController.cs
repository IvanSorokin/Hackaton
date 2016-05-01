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
    public class MessageController : Controller
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserProvider userProvider;

        public MessageController(IMessageRepository messageRepository, IUserProvider userProvider)
        {
            this.messageRepository = messageRepository;
            this.userProvider = userProvider;
        }

        [HttpGet]
        public ViewResult Messages(int? id)
        {
            return View(messageRepository.GetMessagesForCharacter((int)id));
        }

        [HttpPost]
        public ViewResult Add(MessageRequest request)
        {
             var message = new Message()
            {
                CharacterId = request.id,
                Content = request.content,
                UserId = userProvider.GetId(this),
                UserName = userProvider.GetId(this).ToString()
            };
            messageRepository.Add(message);
            return View("Message", message);
        }

        public class MessageRequest
        {
            public int id{ get; set; }
            public string content{ get; set; }
            
        }
    }
}