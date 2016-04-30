using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebUI.Controllers;
using WebUI.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public class VoteTests
    {
        [TestMethod]
        public void ShouldCallRepositoryAdd()
        {
            var mock = new Mock<ICharacterRepository>();
            mock.Setup(x => x.Characters).Returns(new List<Character>()
            {
                new Character() {Sex= Sex.Female, Name="sersey", Id=0, Cost=12 },
                new Character() {Sex= Sex.Male, Name="tyrion", Id=1, Cost=15 }
            }.AsQueryable());
            var repositoryMock = new Mock<IVoteRepository>();
            var votes = new List<Vote>()
            {

            }.AsQueryable();

            repositoryMock.Setup(x => x.Votes).Returns(votes);
            repositoryMock
                .Setup(x => x.Add(It.IsAny<Vote>(), It.IsAny<HashSet<int>>()));
            var cart = new Cart();
            var cartProviderMock = new Mock<ICartProvider>();
            cartProviderMock.Setup(x => x.GetCart(It.IsAny<Controller>())).Returns(cart);
            var mockWeekProvider = new Mock<IWeekProvider>();
            mockWeekProvider.Setup(x => x.GetWeek()).Returns(42);
            var mockUserProvider = new Mock<IUserProvider>();
            mockUserProvider.Setup(x => x.GetId(It.IsAny<Controller>())).Returns(Guid.Empty);
            var cartController = new CartController(mock.Object, cartProviderMock.Object, mockWeekProvider.Object,
                repositoryMock.Object, mockUserProvider.Object);
            cartController.AddToCart(0, "/");
            cartController.SubmitVotes("/");

            repositoryMock.Verify(rep => rep.Add(new Vote()
            {
                UserID = Guid.Empty, VoteID = 0, WeekId = 42
            }, 
                new HashSet<int>() {0} ));

        }

    }
}
