using Org.BouncyCastle.Asn1;

namespace MyService_API.DTO
{
    public class ServicoE_DTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public float Preco { get; set; }
        public string Imagem { get; set; }
        public int ID_WORK { get; set; }
    }
}
