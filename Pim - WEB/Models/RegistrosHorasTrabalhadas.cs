using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pim___WEB.Models
{
	[Table("tbRegistrosHorasTrabalhadas")]
	public class RegistrosHorasTrabalhadas
	{
		[Key]
		public int RegistroId { get; set; }
		public string CPF { get; set; }
		public DateTime Data { get; set; }
        public string HorasTrabalhadas { get; set; }
		public string ValorHora { get; set; }
        public Funcionarios funcionarios { get; set; }
    }
}
