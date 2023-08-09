using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using Moq;

namespace Clean.Tests.Mocks
{
    internal class GenericRepositoryMock
    {
        public static Mock<IGenericRepository<Customer>> GetCustomerRepositoryMock()
        {
            var repository = new Mock<IGenericRepository<Customer>>();
            repository.Setup(r => r.Add(It.IsAny<Customer>()));
            repository.Setup(m => m.Remove(It.IsAny<Customer>()));
            repository.Setup(m => m.SaveChanges()).Callback(() => { });
            repository.Setup(m => m.FindById(It.IsAny<Guid>())).ReturnsAsync(new Customer("Test Customer", "test@mail.com"));
            repository.Setup(m => m.FindAll()).ReturnsAsync(new List<Customer>() { new Customer("Test 1", "test@mail.com"), new Customer("Test 2", "test2@mail.com") });

            return repository;
        }
    }
}
