using FluentValidation;

namespace CostumerApi.Validations
{
    public class CreateCustomerValidator: AbstractValidator<Costumer.Api.Models.Costumer>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be left blank.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be left blank");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email format is not correct.");
            RuleFor(x => x.Address.AddressLine).NotEmpty().WithMessage("AddressLine cannot be left blank.");
            RuleFor(x => x.Address.City).NotEmpty().WithMessage("City cannot be left blank.");
            RuleFor(x => x.Address.Country).NotEmpty().WithMessage("Country cannot be left blank.");
            RuleFor(x => x.Address.CityCode).NotEmpty().WithMessage("CityCode cannot be left blank.");
            RuleFor(x => x.Address.CityCode).GreaterThan(0).WithMessage("CityCode must be greater than 0.");
        }
    }
}
