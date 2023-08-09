using Clean.Application.Commands.Customer;
using Clean.Tests.Mocks;
using FluentAssertions;
using Xunit;

namespace Clean.Tests.Application
{
    public class CustomerCommandsTests
    {
        [Fact]
        public async Task CreateCustomerTest()
        {
            //Arrange
            var repository = GenericRepositoryMock.GetCustomerRepositoryMock();

            CreateCustomerRequest command = new CreateCustomerRequest();
            CustomerCommandsHandler handler = new CustomerCommandsHandler(repository.Object);

            //Act
            var response = await handler.Handle(command, new CancellationToken());

            //Assert
            response.Should().NotBeNull();
            response.Should().BeOfType<CreateCustomerResponse>();
        }

        [Fact]
        public async Task UpdateCustomerTest()
        {
            //Arrange
            var repository = GenericRepositoryMock.GetCustomerRepositoryMock();

            UpdateCustomerRequest command = new UpdateCustomerRequest();
            CustomerCommandsHandler handler = new CustomerCommandsHandler(repository.Object);

            //Act
            var response = await handler.Handle(command, new CancellationToken());

            //Assert
            response.Should().NotBeNull();
            response.Should().BeOfType<UpdateCustomerResponse>();
        }

        [Fact]
        public async Task DeleteCustomerTest()
        {
            //Arrange
            var repository = GenericRepositoryMock.GetCustomerRepositoryMock();

            DeleteCustomerRequest command = new DeleteCustomerRequest();
            CustomerCommandsHandler handler = new CustomerCommandsHandler(repository.Object);

            //Act
            var response = await handler.Handle(command, new CancellationToken());

            //Assert
            response.Should().NotBeNull();
            response.Should().BeOfType<DeleteCustomerResponse>();
        }
    }
}
