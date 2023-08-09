using Clean.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Clean.Tests.Domain
{
    public class CustomerTests
    {
        [Fact]
        public void EntityTest()
        {
            Customer entity = new("Customer Name", "email@mail.com");

            entity.Name.Should().Be("Customer Name");
            entity.Email.Should().Be("email@mail.com");

            entity.Update("New Customer Name", "newemail@mail.com");
            entity.Name.Should().Be("New Customer Name");
            entity.Email.Should().Be("newemail@mail.com");
        }
    }
}
