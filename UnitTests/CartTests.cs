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

namespace UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void ShouldAddItem()
        {
            var cart = new Cart();
            var mock = new Mock<Domain.Abstract.ICharacterRepository>();
            mock.Setup(x => x.Characters).Returns(new List<Character>()
            {
                new Character() {Id = 0, Cost=12, Sex= Sex.Female, Name="sersey" },
                new Character() {Id = 1, Cost = 15, Sex= Sex.Male, Name="tyrion" }
            }.AsQueryable());   
            var cartProviderMock = new Mock<ICartProvider>();
            cartProviderMock.Setup(x => x.GetCart(null)).Returns(cart);
            var controller = new CartController(mock.Object, cartProviderMock.Object);
            controller.AddToCart(0, "/");
            Assert.IsTrue(cart.CharactersIds.Count == 1);
        }
    }
}
