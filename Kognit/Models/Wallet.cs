namespace Kognit.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal ValorAtual { get; set; }
        public string Banco { get; set; }
        public DateTime UltimaAtualizacao { get; set; }

        public Wallet()
        {
            Id = 0;
            UserId = 0;
            ValorAtual = decimal.Zero;
            Banco = string.Empty;
            UltimaAtualizacao = DateTime.MinValue;
        }
    }
}
