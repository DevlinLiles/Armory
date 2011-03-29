using System;
using Armory.Validation.Interfaces;

namespace DigitalCatalogProcessor.Sony.Domain
{
    public class ValidationRule<T> : IValidationRule<T> where T : IDomainObject
    {
        readonly Predicate<T> _matchPredicate;
        private readonly string _name;
        private readonly string _description;

        public ValidationRule(string name, string description, Predicate<T> matchPredicate)
        {
            _name = name;
            _description = description;
            _matchPredicate = matchPredicate;
        }

        public bool IsSatisfiedBy(T item)
        {
            return _matchPredicate(item);
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public override bool Equals(object obj)
        {
            var other = obj as IValidationRule<T>;
            return (other == null ? true : Name.Equals(other.Name));
        }

        public override int GetHashCode()
        {
            return _matchPredicate.GetHashCode() + 29 * _name.GetHashCode();
        }


    }

}