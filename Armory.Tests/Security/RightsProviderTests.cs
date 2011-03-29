using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Armory.Interfaces;
using Armory.Security.Entities;
using Armory.Security.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Armory.Tests.Security
{
    [TestClass]
    public class RightsProviderTests
    {
        private MockRepository _mockRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new MockRepository();
        }

        [TestMethod]
        public void CallsRoleProviderForRoleList()
        {
            //arrange
            string userName = "Test";
            var mockRoleProvider = _mockRepository.StrictMock<RoleProvider>();
            mockRoleProvider.Expect(x => x.GetRolesForUser("Test")).Return(new string[] {"Test"});

            var mockRightsRepository = _mockRepository.StrictMock<IRepository>();
            mockRightsRepository.Expect(x => x.AsQuearyable<Right>()).Return(new List<Right> {new Right("Test", true)}.AsQueryable());

            var rightsProvider = new RightsProvider(mockRoleProvider,mockRightsRepository);

            //act
            var returnedValue = rightsProvider.DoesUserHaveAccessRights("Test", "Test.Test");

            //assert
            Assert.IsTrue(returnedValue);
            _mockRepository.VerifyAll();
        }
    }
}