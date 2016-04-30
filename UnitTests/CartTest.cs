using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WebUI.Controllers;
using Domain;
using Domain.Entities;
using WebUI.Infrastructure;
using System.Web.Mvc;
using Domain.Abstract;

namespace UnitTests
{
    [TestClass]
    public class CartTest
    {
        private Mock<ICartProvider> cartProviderMock;
        private CartController controller;
        private Mock<ICharacterRepository> mock;
        private Cart cart;

        [TestInitialize]
        public void SetUp()
        {
            mock = new Mock<ICharacterRepository>();
            mock.Setup(x => x.Characters).Returns(new List<Character>()
            {
                new Character() {Sex= Sex.Female, Name="sersey", Id=0, Cost=12 },
                new Character() {Sex= Sex.Male, Name="tyrion", Id=1, Cost=15 }
            }.AsQueryable());
            cart = new Cart();
            cartProviderMock = new Mock<ICartProvider>();
            cartProviderMock.Setup(x => x.GetCart(It.IsAny<Controller>())).Returns(cart);
            controller = new CartController(mock.Object, cartProviderMock.Object,null, null,null);
        }

        [TestMethod]
        public void SimpleAddTest()
        {
            controller.AddToCart(0, "/");
            Assert.IsTrue(cart.CharactersIds.Count == 1);
        }

        [TestMethod]
        public void SimpleRemoveTest()
        {
            controller.AddToCart(0, "/");
            Assert.IsTrue(cart.CharactersIds.Count == 1);
            controller.RemoveFromCart(0, "/");
            Assert.IsTrue(cart.CharactersIds.Count == 0);
        }

        [TestMethod]
        public void NotEnoughMoney()
        {
            cart.Cash = 5;
            controller.AddToCart(0, "/");
            Assert.IsTrue(cart.CharactersIds.Count == 0);
        }

        [TestMethod]
        public void RepeatitiveAdd()
        {
            cart.Cash = 14;
            mock.Setup(x => x.Characters).Returns(new List<Character>()
            {
                new Character() {Sex= Sex.Female, Name="sersey", Id=0, Cost=12 }
            }.AsQueryable());
            controller.AddToCart(0, "/");
            controller.AddToCart(0, "/");
            Assert.IsTrue(cart.CharactersIds.Count == 1);
        }

        [TestMethod]
        public void CashBack()
        {
            cart.Cash = 14;
            controller.AddToCart(0, "/");
            controller.RemoveFromCart(0, "/");
            Assert.IsTrue(cart.Cash == 14);
        }

        [TestMethod]
        public void NoCashBackforUnvoted()
        {
            cart.Cash = 14;
            controller.RemoveFromCart(0, "/");
            Assert.IsTrue(cart.Cash == 14);
        }
    }
}
