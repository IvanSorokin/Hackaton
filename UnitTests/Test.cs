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

namespace UnitTests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Test1()
        {
            var mock = new Mock<Domain.Abstract.ICharacterRepository>();
            mock.Setup(x => x.Characters).Returns(new List<Character>()
            {
                new Character() {Sex= Sex.Female, Name="sersey" },
                new Character() {Sex= Sex.Male, Name="tyrion" }
            }.AsQueryable());

            var controller = new CharacterController(mock.Object);
            Assert.IsTrue(controller.FilterByField("Sex", "Male").Count == 1);
        }
    }
}
