using System.Collections.Generic;

namespace Armory.Validation.Interfaces
{
    public interface IValidationRuleSet
    {
        IValidationRuleSet BrokenBy(IDomainObject item);
        bool Contains(IRule rule);
        int Count { get; }
        IList<string> Messages { get; }
        bool IsEmpty { get; }
    }
}