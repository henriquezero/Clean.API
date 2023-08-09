using Clean.Domain.Interfaces;
using Clean.Infra.Attributes;
using Clean.Infra.Exceptions;
using MediatR;

namespace Clean.Application.Queries.Customer
{
    [Injectable(LifeTime.Scoped)]
    public class CustomerQueriesHandler : IRequestHandler<FindCustomerRequest, FindCustomerResponse[]>,
                                          IRequestHandler<FindCustomerByIdRequest, FindCustomerResponse>
    {
        private readonly IGenericRepository<Domain.Entities.Customer> _repository;

        public CustomerQueriesHandler(IGenericRepository<Domain.Entities.Customer> repository)
        {
            _repository = repository;
        }

        public async Task<FindCustomerResponse[]> Handle(FindCustomerRequest command, CancellationToken cancellationToken)
        {
            var items = await _repository.FindAll();
            return items.Select(e => new FindCustomerResponse(e)).ToArray();
        }

        public async Task<FindCustomerResponse> Handle(FindCustomerByIdRequest command, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindById(command.Id);
            if (entity is null) throw new NotFoundException("Customer not found");

            return new FindCustomerResponse(entity);
        }
    }
}
