using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pim___WEB.Models
{
    [Table("tbFuncionarios")]
    public class Funcionarios
	{
		[Key]
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
		public string TelefoneCelular { get; set; }
		public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Senha { get; set; }
        public ICollection<InformacoesPagamento> InformacoesPagamentos { get; set; }
        public ICollection<RegistrosHorasTrabalhadas> RegistrosHorasTrabalhadas { get; set; }
        //public ICollection<RelatorioPagamento> RelatorioPagamento { get; set; }
        public List<RelatorioPagamento> RelatorioPagamentos { get; set; }
    }
}
