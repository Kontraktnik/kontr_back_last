using Application.Helpers;
using Application.Resource;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Features.ArmyTypeCQRS.Command.DeleteArmyType;

public class DeleteArmyTypeCommandValidator : AbstractValidator<DeleteArmyTypeCommand>
{
    public DeleteArmyTypeCommandValidator(IStringLocalizer<Localize> localizer)
    {
        RuleFor(p => p.Id)
            .NotNull().WithMessage(x => localizer["Required"])
            .GreaterThan(ValidationHelpers.ArmyTypeMax).WithMessage(x => localizer["SystemDataError"])
            .OverridePropertyName("Id");
    }
}