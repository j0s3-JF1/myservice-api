﻿namespace MyService_API.DTO
{
    public class AvaliacaoProdutoTDTO
    {
        public int ID { get; set; }
        public string Comentario { get; set; }
        public int ID_PRODUTO_T { get; set; }
        public string Produto_Nome { get; set; }
        public string Produto_Descricao { get; set; }
        public string Produto_Categoria { get; set; }
        public double Produto_Preco { get; set; }
    }
}
