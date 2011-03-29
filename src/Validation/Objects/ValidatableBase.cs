using System.Xml.Serialization;
using Armory.Validation.Interfaces;

namespace Armory.Validation.Objects
{
    public class ValidatableBase : IDomainObject
    {
        private readonly IValidationRuleSet _rules;

        public ValidatableBase(IValidationRuleSet rules)
        {
            _rules = rules;
        }

        public IValidationRuleSet Validate()
        {
            return _rules.BrokenBy(this);
        }

        [XmlIgnore]
        public bool IsValid
        {
            get { return Validate().IsEmpty; }
        }
    }
}