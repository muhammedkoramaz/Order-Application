using FluentValidation;

namespace OrderApi.Validations
{
    public class CreateOrderValidation: AbstractValidator<Order.Api.Models.Order>
    {
        public CreateOrderValidation()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId cannot be left blank.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity cannot be left blank.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price cannot be left blank.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status cannot be left blank.");
            
            RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Product Name cannot be left blank.");
            RuleFor(x => x.Product.ImageUrl).NotEmpty().WithMessage("Product ImageUrl cannot be left blank.");
           
            RuleFor(x => x.Address.AddressLine).NotEmpty().WithMessage("AddressLine cannot be left blank.");
            RuleFor(x => x.Address.City).NotEmpty().WithMessage("City cannot be left blank.");
            RuleFor(x => x.Address.Country).NotEmpty().WithMessage("Country cannot be left blank.");
            RuleFor(x => x.Address.CityCode).NotEmpty().WithMessage("CityCode cannot be left blank.");
            RuleFor(x => x.Address.CityCode).GreaterThan(0).WithMessage("CityCode must be greater than 0.");
        }

    }
}
