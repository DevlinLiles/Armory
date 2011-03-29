using System.Collections.Generic;
using System.Linq;
using Armory.Validation.Interfaces;

namespace Armory.Validation.Objects
{
    public class ValidationRuleSet<T> : IValidationRuleSet where T : IDomainObject
    {
        private readonly IList<IValidationRule<T>> _rules;

        public ValidationRuleSet(params IValidationRule<T>[] rules)
            : this(new List<IValidationRule<T>>(rules))
        {
        }

        public ValidationRuleSet(IList<IValidationRule<T>> rules)
        {
            _rules = rules;
        }

        public IValidationRuleSet BrokenBy(IDomainObject item)
        {
            IList<IValidationRule<T>> brokenRules = _rules.Where(rule => !rule.IsSatisfiedBy((T) item)).ToList();

            return new ValidationRuleSet<T>(brokenRules);
        }

        public IList<string> Messages
        {
            get
            {
                return new List<IValidationRule<T>>(_rules).ConvertAll(rule => rule.Description);
            }
        }
        
        public int Count
        {
            get { return _rules.Count; }
        }

        public bool Contains(IRule rule)
        {
            return _rules.Any(businessRule => rule.Name.Equals(businessRule.Name));
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }
    }

}