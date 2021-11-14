using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Web.DTOs.Assets;

namespace Hahn.ApplicatonProcess.July2021.Web.Validators
{

    public class AssetUpdateValidator : AbstractValidator<UpdateAssetRequest>
    {
        public AssetUpdateValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Name).MinimumLength(3);
            RuleFor(x => x.Name).MaximumLength(20);
            RuleFor(x => x.Symbol).NotNull().NotEmpty().WithMessage("Symbol is required.");
            RuleFor(x => x.Symbol).MinimumLength(3);
            RuleFor(x => x.Symbol).MaximumLength(3);

        }
    }
}
