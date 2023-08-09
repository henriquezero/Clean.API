using Clean.Application.Commands.Customer;
using Clean.Infra.Attributes;
using FluentValidation;

namespace Clean.Application.Validators
{
    [Injectable(typeof(IValidator<CreateCustomerRequest>))]
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório")
                .MaximumLength(100)
                .WithMessage("O tamanho máximo do Nome é 100 caracteres");

            RuleFor(a => a.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido")
                .MaximumLength(200)
                .WithMessage("O tamanho máximo do E-mail é 100 caracteres");
        }
    }

    [Injectable(typeof(IValidator<UpdateCustomerRequest>))]
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(a => a.Id).NotEmpty();

            RuleFor(a => a.Name)
                .MaximumLength(100)
                .WithMessage("O tamanho máximo do Nome é 100 caracteres");

            RuleFor(a => a.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido")
                .MaximumLength(200)
                .WithMessage("O tamanho máximo do E-mail é 100 caracteres");
        }
    }

    [Injectable(typeof(IValidator<DeleteCustomerRequest>))]
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
        }
    }
}
