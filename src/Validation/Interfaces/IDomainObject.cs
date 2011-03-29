namespace Armory.Validation.Interfaces
{
    public interface IDomainObject
    {
        bool IsValid { get; }
        IValidationRuleSet Validate();
    }
}