using MySql.Data.MySqlClient;
using MyService_API.DTO;
namespace MyService_API.DAO
{
    public class AvaliacaoProdutoTDAO
    {
       public void AvaliacaoProdutoT(AvaliacaoProdutoTDTO avaliacao)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO AvaliacaoProduto_T(COMENTARIO) VALUES ( @comentario ) ";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@comentario", avaliacao.Comentario);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
