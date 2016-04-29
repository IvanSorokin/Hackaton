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
            //var mock = new Mock<ICharacterRepository>();
            //mock.Setup(repo => repo.Characters).Returns(new List<Character>()
            //{
            //    new Character() {Name="1", Cost=322 },
            //    new Character() {Name="2", Cost=228 },
            //    new Character() {Name="3", Cost=1488 }
            //}.AsQueryable()
            //);
            //ninjectKernel.Bind<ICharacterRepository>().ToConstant(mock.Object);
            ninjectKernel.Bind<ICharacterRepository>().To<EFCharacterRepository>();
            // конфигурирование контейнера }
        }
    }
}