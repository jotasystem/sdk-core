using FluentValidation;
using FluentValidation.Results;

namespace JotaSystem.Sdk.Core.Application.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        public virtual Func<object, string, Task<IEnumerable<string>>> ValidateValue =>
            async (model, propertyName) =>
            {
                var context = ValidationContext<T>.CreateWithOptions((T)model, x => x.IncludeProperties(propertyName));

                ValidationResult result = await ValidateAsync(context);
                if (result.IsValid) return [];

                return result.Errors.Select(e => e.ErrorMessage);
            };
    }
}