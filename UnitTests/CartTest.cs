//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Moq;
//using WebUI.Controllers;
//using Domain;
//using Domain.Entities;
//using WebUI.Infrastructure;
//using System.Web.Mvc;
//
//namespace UnitTests
//{
//    [TestClass]
//    public class CartTest
//    {
//        [TestMethod]
//        public void SimpleAddTest()
//        {
//            var mock = new Mock<Domain.Abstract.ICharacterRepository>();
//            mock.Setup(x => x.Characters).Returns(new List<Character>()
//            {
//                new Character() {Sex= Sex.Female, Name="sersey", Id=0, Cost=12 },
//                new Character() {Sex= Sex.Male, Name="tyrion", Id=1, Cost=15 }
//            }.AsQueryable());
//            var cart = new Cart();
//            var cartProviderMock = new Mock<ICartProvider>();
//            cartProviderMock.Setup(x => x.GetCart(It.IsAny<Controller>())).Returns(cart);
//            var controller = new CartController(mock.Object, cartProviderMock.Object, );
//            controller.AddToCart(0, "/");
//            Assert.IsTrue(cart.CharactersIds.Count == 1);
//        }
//
//        [TestMethod]
//        public void SimpleRemoveTest()
//        {
//            var cart = new Cart();
//            var mock = new Mock<Domain.Abstract.ICharacterRepository>();
//            mock.Setup(x => x.Characters).Returns(new List<Character>()
//            {
//                new Character() {Sex= Sex.Female, Name="sersey", Id=0, Cost=12 },
//                new Character() {Sex= Sex.Male, Name="tyrion", Id=1, Cost=15 }
//            }.AsQueryable());
//            var cartProviderMock = new Mock<ICartProvider>();
//            cartProviderMock.Setup(x => x.GetCart(It.IsAny<Controller>())).Returns(cart);
//            var controller = new CartController(mock.Object, cartProviderMock.Object);
//            controller.AddToCart(0, "/");
//            Assert.IsTrue(cart.CharactersIds.Count == 1);
//            controller.RemoveFromCart(0, "/");
//            Assert.IsTrue(cart.CharactersIds.Count == 0);
//        }
//
//        [TestMethod]
//        public void NotEnoughMoney()
//        {
//            var cart = new Cart();
//            cart.Cash = 5;
//            var mock = new Mock<Domain.Abstract.ICharacterRepository>();
//            mock.Setup(x => x.Characters).Returns(new List<Character>()
//            {
//                new Character() {Sex= Sex.Female, Name="sersey", Id=0, Cost=12 }
//            }.AsQueryable());
//            var cartProviderMock = new Mock<ICartProvider>();
//            cartProviderMock.Setup(x => x.GetCart(It.IsAny<Controller>())).Returns(cart);
//            var controller = new CartController(mock.Object, cartProviderMock.Object);
//            controller.AddToCart(0, "/");
//            Assert.IsTrue(cart.CharactersIds.Count == 0);
//        }
//
//        [TestMethod]
//        public void RepeatitiveAdd()
//        {
//            var cart = new Cart();
//            cart.Cash = 14;
//            var mock = new Mock<Domain.Abstract.ICharacterRepository>();
//            mock.Setup(x => x.Characters).Returns(new List<Character>()
//            {
//                new Character() {Sex= Sex.Female, Name="sersey", Id=0, Cost=12 }
//            }.AsQueryable());
//            var cartProviderMock = new Mock<ICartProvider>();
//            cartProviderMock.Setup(x => x.GetCart(It.IsAny<Controller>())).Returns(cart);
//            var controller = new CartController(mock.Object, cartProviderMock.Object);
//            controller.AddToCart(0, "/");
//            controller.AddToCart(0, "/");
//            Assert.IsTrue(cart.CharactersIds.Count == 1);
//        }
//
//        [TestMethod]
//        public void CashBack()
//        {
//            var cart = new Cart();
//            cart.Cash = 14;
//            var mock = new Mock<Domain.Abstract.ICharacterRepository>();
//            mock.Setup(x => x.Characters).Returns(new List<Character>()
//            {
//                new Character() {Sex= Sex.Female, Name="sersey", Id=0, Cost=12 }
//            }.AsQueryable());
//            var cartProviderMock = new Mock<ICartProvider>();
//            cartProviderMock.Setup(x => x.GetCart(It.IsAny<Controller>())).Returns(cart);
//            var controller = new CartController(mock.Object, cartProviderMock.Object);
//            controller.AddToCart(0, "/");
//            controller.RemoveFromCart(0, "/");
//            Assert.IsTrue(cart.Cash == 14);
//        }
//
//        [TestMethod]
//        public void NoCashBackforUnvoted()
//        {
//            var cart = new Cart();
//            cart.Cash = 14;
//            var mock = new Mock<Domain.Abstract.ICharacterRepository>();
//            mock.Setup(x => x.Characters).Returns(new List<Character>()
//            {
//                new Character() {Sex= Sex.Female, Name="sersey", Id=0, Cost=12 }
//            }.AsQueryable());
//            var cartProviderMock = new Mock<ICartProvider>();
//            cartProviderMock.Setup(x => x.GetCart(It.IsAny<Controller>())).Returns(cart);
//            var controller = new CartController(mock.Object, cartProviderMock.Object);
//            controller.RemoveFromCart(0, "/");
//            Assert.IsTrue(cart.Cash == 14);
//        }
//    }
//}
