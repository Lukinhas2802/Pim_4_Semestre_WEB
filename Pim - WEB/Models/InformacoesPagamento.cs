using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pim___WEB.Models
{
    [Table("tbInformacoesPagamento")]
    public class InformacoesPagamento
	{
		[Key]
        public int PagamentoId { get; set; }
        public string CPF  { get; set; }
		public string SalarioLiquido { get; set; }
		public DateTime DataPagamento { get; set; }
        public string NumeroConta { get; set; }
        public string NumeroAgencia { get; set; }
        public Funcionarios funcionarios { get; set; }
	}
}
