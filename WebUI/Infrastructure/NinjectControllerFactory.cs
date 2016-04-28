using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using Domain.Abstract;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

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
            var mock = new Mock<IProductRepository>();
            mock.Setup(repo => repo.Products).Returns(new List<Product>()
            {
                new Product() {Name="1", Price=322 },
                new Product() {Name="2", Price=228 },
                new Product() {Name="3", Price=1488 }
            }.AsQueryable()
            );
            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);

            // конфигурирование контейнера }
        }
    }
}