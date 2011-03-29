namespace Armory.Validation.Interfaces
{
    public interface IValidationRule<T> : IRule
    {
        bool IsSatisfiedBy(T item);
    }
}