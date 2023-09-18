namespace GestaoContaBancaria.Models
{
    public class Transferir
    {
        public int UsuarioOrigemId { get; set; }
        public int UsuarioDestinoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
