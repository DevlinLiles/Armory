using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Armory.Web;
using System.Web.Mvc;
using Rhino.Mocks;

namespace Armory.Tests
{
    [TestClass]
    public class HtmlHelperExtensionsTests
    {
        [TestMethod]
        public void HtmlHelper_Should_Have_Gravatar_Extensions()
        {
            // Arrange
            var mock = MockRepository.GenerateMock<IViewDataContainer>();
            var html = new System.Web.Mvc.HtmlHelper(new ViewContext(), mock);

            // Act
            var result = html.Gravatar("tim@timrayburn.net");

            // Assert
            Assert.IsInstanceOfType(result, typeof(Gravatar));
        }
    }
}
