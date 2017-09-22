using System;

namespace HBSIS.Domain.Entities
{
    public class Cliente
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string CpfCnpj { get; set; }

        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
