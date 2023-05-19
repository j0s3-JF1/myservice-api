namespace MyService_API.DTO
{
    public class ProdutoEmpresaDTO
    {
        public int ID { get; set; }
        public string Produto_Nome { get; set; }
        public string Produto_Descricao { get; set; }
        public string Produto_Categoria { get; set; }
        public double Produto_Preco { get; set; }
        public string Empresa_Nome { get; set; }
        public string Empresa_Empresa { get; set; }
        public string Empresa_Telefone { get; set; }
        public string Empresa_Insta { get; set; }
    }
}
