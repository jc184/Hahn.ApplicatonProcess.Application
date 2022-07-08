using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Web.DTOs.Users;

namespace Hahn.ApplicatonProcess.July2021.Web.Validators
{

    public class UserValidator : AbstractValidator<AddUserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.FirstName).MinimumLength(3);
            RuleFor(x => x.FirstName).MaximumLength(20);
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Last Name is required.");
            RuleFor(x => x.LastName).MinimumLength(3);
            RuleFor(x => x.LastName).MaximumLength(20);
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required").EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.Age).InclusiveBetween(18, 90);
        }
    }
}
