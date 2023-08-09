using MediatR;

namespace Clean.Application.Commands.Customer
{
    public sealed class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public sealed class UpdateCustomerRequest : IRequest<UpdateCustomerResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public sealed class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
    {
        public Guid Id { get; set; }
    }

    public sealed class CreateCustomerResponse
    { 
        public CreateCustomerResponse(Domain.Entities.Customer entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Email = entity.Email;
            Date = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }

    public sealed class UpdateCustomerResponse
    {
        public UpdateCustomerResponse()
        {
            Message = "Cliente editado com sucesso.";
        }

        public string Message { get; set; }
    }

    public sealed class DeleteCustomerResponse
    {
        public DeleteCustomerResponse()
        {
            Message = "Cliente deletado com sucesso.";
        }

        public string Message { get; set; }
    }
}
