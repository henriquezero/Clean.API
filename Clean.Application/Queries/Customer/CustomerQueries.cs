using MediatR;

namespace Clean.Application.Queries.Customer
{
    public sealed class FindCustomerRequest : IRequest<FindCustomerResponse[]>
    { }
    public sealed class FindCustomerByIdRequest : IRequest<FindCustomerResponse>
    {
        public FindCustomerByIdRequest(Guid id) 
        { 
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public sealed class FindCustomerResponse
    {
        public FindCustomerResponse(Domain.Entities.Customer entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Email = entity.Email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
