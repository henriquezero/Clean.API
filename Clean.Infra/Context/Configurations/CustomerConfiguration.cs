using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infra.Context.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(200).IsRequired();

        builder.HasData(new Customer("Jose Henrique", "jose.henrique@mail.com"), 
                        new Customer("Maria Eduarda", "maria.eduarda@mail.com")
        );
    }
}
}
