using System;
using System.Linq;
using System.Web.Security;
using Armory.Interfaces;
using Armory.Security.Entities;
using Armory.Security.Interfaces;

namespace Armory.Security.Providers
{
    public class RightsProvider : IRightsProvider
    {
        private readonly RoleProvider _roleProvider;
        private readonly IRepository _rightsRepository;

        public RightsProvider(RoleProvider roleProvider, IRepository rightsRepository)
        {
            _roleProvider = roleProvider;
            _rightsRepository = rightsRepository;
        }

        public bool DoesUserHaveAccessRights(string name, string actionName)
        {
            var roles = _roleProvider.GetRolesForUser(name);

            var rights = _rightsRepository.AsQuearyable<Right>().Where(x => x.RightName == actionName);

            return rights.Any() && rights.All(x => x.Allow);
        }
    }
}