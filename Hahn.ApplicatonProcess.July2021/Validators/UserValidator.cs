using FluentValidation;
using FluentValidation.Validators;
using Hahn.ApplicatonProcess.July2021.Domain.Entities;

namespace Hahn.ApplicatonProcess.July2021.Web.Validators
{

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Last Name is required.");
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Must be a valid Email Address");
            RuleFor(x => x.Age).InclusiveBetween(18, 90);
        }
    }
}
