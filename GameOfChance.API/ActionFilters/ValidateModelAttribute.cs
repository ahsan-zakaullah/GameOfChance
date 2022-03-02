using System.Reflection;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameOfChance.API.ActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public string ValidatedArgumentName { get; private set; }
        private Type ValidatorType { get; set; }
        public ValidateModelAttribute(string validatedArgumentName, Type validatorType)
        {
            ValidatedArgumentName = validatedArgumentName;
            ValidatorType = validatorType;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments[ValidatedArgumentName] == null)
            {
                context.ModelState.AddModelError("Root", "Model is missing.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            else if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            else
            {
                var modelValue = context.ActionArguments[ValidatedArgumentName];
                var validator = ValidatorType.InvokeMember(null!, BindingFlags.CreateInstance, null, null, new object[] { });
                var result = ValidatorType.InvokeMember("Validate", BindingFlags.InvokeMethod, null, validator, new[] { modelValue }) as ValidationResult;
                if (result?.IsValid ?? true)
                {
                    return;
                }
                foreach (var error in result.Errors)
                {
                    context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

    }
}
