namespace MyService_API.DTO
{
    public class ServicoTrabalhadorDTO
    {
        public int ID { get; set; }
        public string Servico_Nome { get; set; }
        public string Servico_Descricao { get; set; }
        public string Servico_Categoria { get; set; }
        public double Servico_Preco { get; set; }
        public string Servico_Imagem { get; set; }
        public string Trabalhador_Nome { get; set; }
        public string Trabalhador_Telefone { get; set; }
        public string Trabalhador_Insta { get; set; }
    }
}
