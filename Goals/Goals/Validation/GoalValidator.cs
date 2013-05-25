using FluentValidation;
using Goals.Models;

namespace Goals.Validation {
    public class GoalValidator : AbstractValidator<Goal> {
        public GoalValidator() {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}