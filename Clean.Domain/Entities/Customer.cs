namespace Clean.Domain.Entities
{
    public sealed class Customer
    {
        public Customer(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
