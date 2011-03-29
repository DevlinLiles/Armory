namespace Armory.Security.Interfaces
{
    public interface IRightsProvider
    {
        bool DoesUserHaveAccessRights(string name, string actionName);
    }
}