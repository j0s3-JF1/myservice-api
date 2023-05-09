using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class AvaliacaoProdutoEDAO
    {
        public void AvaliacaoProdutoE(AvaliacaoProdutoEDTO avaliacao)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Close();

            var query = @"INSERT INTO AvaliacaoProduto_E(COMENTARIO) VALUE ( @comentario )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@comentario", avaliacao.Comentario);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
