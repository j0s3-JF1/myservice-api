namespace MyService_API.DTO
{
    public class ProdutoT_DTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public int ID_Trabalhador { get; set; }
        public int Like { get; set; }
    }
}
