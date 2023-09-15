using Entities.Enums;

namespace Entities.Entities
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Descricao { get; set; }

        public DateTime DataLancemanto { get; set; }

        public EnumsTipoLancamento EnumsTipoLancamento { get; set; }

        public decimal Valor { get; set; }

        public int UsuarioId { get; set; }

        public decimal Saldo { get; set; }
    
    }
}