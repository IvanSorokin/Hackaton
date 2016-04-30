using System;
using System.Security.Principal;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace WebUI.Infrastructure
{
    public class UserProvider : IUserProvider
    {
        public Guid GetId(Controller controller)
        {
            return Guid.Parse(controller.User.Identity.GetUserId());
        }
    }
}