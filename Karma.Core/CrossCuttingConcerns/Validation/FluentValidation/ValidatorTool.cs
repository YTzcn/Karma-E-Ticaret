using FluentValidation;

namespace Karma.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);//Hata Var Kral Bak Buna
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
