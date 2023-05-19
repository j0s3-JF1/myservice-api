namespace MyService_API.DTO
{
    public class AvaliacaoServicoTDTO
    {
        public int ID { get; set; }
        public string Comentario { get; set; }
        public int ID_SERVICO_T { get; set; }
        public string Servico_Nome { get; set; }
        public string Servico_Descricao { get; set; }
        public string Servico_Categoria { get; set; }
        public double Servico_Preco { get; set; }
    }
}
