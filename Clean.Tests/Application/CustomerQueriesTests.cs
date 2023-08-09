using Clean.Application.Queries.Customer;
using Clean.Tests.Mocks;
using FluentAssertions;
using Xunit;

namespace Clean.Tests.Application
{
    public class CustomerQueriesTests
    {
        [Fact]
        public async Task FindCustomerTest()
        {
            //Arrange
            var repository = GenericRepositoryMock.GetCustomerRepositoryMock();

            FindCustomerRequest command = new FindCustomerRequest();
            CustomerQueriesHandler handler = new CustomerQueriesHandler(repository.Object);

            //Act
            var response = await handler.Handle(command, new CancellationToken());

            //Assert
            response.Should().NotBeNull();
            response.Should().BeOfType<FindCustomerResponse[]>();
            response.Should().HaveCount(2);
        }

        [Fact]
        public async Task FindCustomerByIdTest()
        {
            //Arrange
            var repository = GenericRepositoryMock.GetCustomerRepositoryMock();

            FindCustomerByIdRequest command = new FindCustomerByIdRequest(Guid.NewGuid());
            CustomerQueriesHandler handler = new CustomerQueriesHandler(repository.Object);

            //Act
            var response = await handler.Handle(command, new CancellationToken());

            //Assert
            response.Should().NotBeNull();
            response.Should().BeOfType<FindCustomerResponse>();
        }
    }
}
