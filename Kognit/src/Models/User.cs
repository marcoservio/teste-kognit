namespace Kognit.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cpf { get; set; }

        public User()
        {
            Id = 0;
            Nome = string.Empty;
            Nascimento = DateTime.MinValue;
            Cpf = String.Empty;
        }
    }
}
