using Clean.Domain.Interfaces;
using Clean.Infra.Attributes;
using Clean.Infra.Exceptions;
using MediatR;

namespace Clean.Application.Commands.Customer
{
    [Injectable(LifeTime.Scoped)]
    public class CustomerCommandsHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>,
                                   IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>,
                                   IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        private readonly IGenericRepository<Domain.Entities.Customer> _repository;

        public CustomerCommandsHandler(IGenericRepository<Domain.Entities.Customer> repository)
        {
            _repository = repository;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest command, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Customer(command.Name, command.Email);
            _repository.Add(entity);
            await _repository.SaveChanges();

            return new CreateCustomerResponse(entity);
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest command, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindById(command.Id);
            if (entity is null) throw new NotFoundException("Customer not found");

            entity.Update(command.Name, command.Email);
            await _repository.SaveChanges();

            return new UpdateCustomerResponse();
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest command, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindById(command.Id);
            if (entity is null) throw new NotFoundException("Customer not found");

            _repository.Remove(entity);
            await _repository.SaveChanges();

            return new DeleteCustomerResponse();
        }
    }
}
