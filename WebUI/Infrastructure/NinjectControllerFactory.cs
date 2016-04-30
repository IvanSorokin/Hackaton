using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using Domain.Abstract;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Concrete;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Infrastructure
{
    // реализация пользовательской фабрики контроллеров,
    // наследуясь от фабрики используемой по умолчанию
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel(); AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<ICharacterRepository>().To<EFCharacterRepository>();
            ninjectKernel.Bind<ICartProvider>().To<CartProvider>();
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}