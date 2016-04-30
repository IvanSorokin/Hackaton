using System;
using System.Security.Principal;
using System.Web.Mvc;

namespace WebUI.Infrastructure
{
    public interface IUserProvider
    {
        Guid GetId(Controller controller);
    }
}