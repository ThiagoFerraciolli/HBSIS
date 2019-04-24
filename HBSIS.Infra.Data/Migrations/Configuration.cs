namespace HBSIS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HBSIS.Infra.Data.Contexto.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HBSIS.Infra.Data.Contexto.Context context)
        {
            //This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.E.g.

                context.Clientes.AddOrUpdate(
                  p => p.ID,
                  new Domain.Entities.Cliente { Nome = "Andrew Peters", CpfCnpj = "279150123123", Telefone="12356123"},
                  new Domain.Entities.Cliente { Nome = "Brice Lambson", CpfCnpj = "279150123123", Telefone = "12356123" },
                  new Domain.Entities.Cliente { Nome = "Rowan Miller",  CpfCnpj = "279150123123", Telefone = "12356123" }
                );
        }
    }
}
