using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using Clean.Infra.Attributes;
using Clean.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infra.Repositories
{
    [Injectable(typeof(IGenericRepository<Customer>))]
    public class CustomerRepository : IGenericRepository<Customer>
    {
        public CustomerRepository(AppDbContext context)
        {
            Db = context;
        }

        private AppDbContext Db { get; }

        public async Task<IEnumerable<Customer>> FindAll() => await Db.Customer.ToListAsync();

        public async Task<Customer> FindById(Guid id) => await Db.Customer.Where(e => e.Id == id).SingleOrDefaultAsync();

        public void Add(Customer entity) => Db.Customer.Add(entity);

        public void Remove(Customer entity) => Db.Customer.Remove(entity);

        public Task SaveChanges() => Db.SaveChangesAsync();
    }
}
