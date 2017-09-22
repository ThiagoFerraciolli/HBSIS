using HBSIS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HBSIS.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ID);

            Property(c => c.Nome).IsRequired().HasMaxLength(150);

            Property(c => c.CpfCnpj).IsRequired().HasMaxLength(20);

            Property(c => c.Telefone).IsRequired().HasMaxLength(20);
        }
    }
}
