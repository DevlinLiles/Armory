namespace Armory.Security.Entities
{
    public class Right
    {
        public Right(string rightName, bool allow)
        {
            RightName = rightName;
            Allow = allow;
        }
        public string RightName { get; private set; }
        public bool Allow { get; private set; }
    }
}