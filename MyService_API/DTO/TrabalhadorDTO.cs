using Org.BouncyCastle.Bcpg.OpenPgp;

namespace MyService_API.DTO
{
    public class TrabalhadorDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
