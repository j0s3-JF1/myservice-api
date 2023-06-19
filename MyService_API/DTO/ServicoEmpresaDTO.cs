namespace MyService_API.DTO
{
    public class ServicoEmpresaDTO
    {
        public int ID { get; set; }
        public string Servico_Nome { get; set; }
        public string Servico_Descricao { get; set; }
        public string Servico_Categoria { get; set; }
        public double Servico_Preco { get; set; }
        public string Servico_Imagem { get; set; }
        public string Empresa_Nome { get; set; }
        public string Empresa_Empresa { get; set; }
        public string Empresa_Telefone { get; set; }
        public string Empresa_Insta { get; set; }
    }
}
