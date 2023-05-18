using Org.BouncyCastle.Asn1;

namespace MyService_API.DTO
{
    public class ServicoE_DTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Instagram { get; set; }
        public float Preco { get; set; }
        public int ID_EMPRESA { get; set; }
    }
}
