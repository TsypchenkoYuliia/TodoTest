using FluentValidation;
using WebApi.ApiModels;

namespace WebApi.Filters
{
    public class TodoCreationValidator : AbstractValidator<CreateTodoDTO>
    {
        public TodoCreationValidator()
        {
            RuleFor(x => x.Title).Length(1, 50);
            RuleFor(x => x.Title).Length(1, 500);
        }
    }
}
