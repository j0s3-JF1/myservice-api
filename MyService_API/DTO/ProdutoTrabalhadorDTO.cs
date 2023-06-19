namespace MyService_API.DTO
{
    public class ProdutoTrabalhadorDTO
    {
        public int ID_Produto { get; set; }
        public string Produto_Nome { get; set; }
        public string Produto_Descricao { get; set; }
        public string Produto_Categoria { get; set; }
        public double Produto_Preco { get; set; }
        public string Produto_Imagem { get; set; }
        public string Trabalhador_Nome { get; set; }
        public string Trabalhador_Instagram { get; set; }
        public string Trabalhador_Telefone { get; set; }
    }
}
