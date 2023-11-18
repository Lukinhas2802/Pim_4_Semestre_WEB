using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pim___WEB.Models
{
    [Table("tbRelatorioPagamento")]
    public class RelatorioPagamento
    {
        [Key]
        public int HoleriteId { get; set; }
        public DateTime MesReferencia { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal Descontos { get; set; }
        public decimal SalarioLiquido { get; set; }
        public decimal HorasTrabalhadasMensal { get; set; }
        public string CPF { get; set; }
        public Funcionarios funcionarios { get; set; }
    }
}
