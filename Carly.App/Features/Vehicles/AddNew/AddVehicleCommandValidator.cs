using FluentValidation;

namespace Carly.App.Features.Vehicles.AddNew
{
    public class AddVehicleCommandValidator : AbstractValidator<AddVehicleCommand>
    {
        public AddVehicleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
