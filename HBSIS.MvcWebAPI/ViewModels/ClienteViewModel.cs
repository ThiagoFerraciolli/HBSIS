using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HBSIS.MvcWebAPI.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        [DisplayName("Código")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF/CNPJ")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [MinLength(11, ErrorMessage = "Mínimo 11 caracteres")]
        [DisplayName("CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo 8 caracteres")]
        public string Telefone { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}