using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class AvaliacaoServicoTDAO
    {
        public void AvaliacaoServicoT(AvaliacaoServicoTDTO avaliacao)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO AvaliacaoServico_T(COMENTARIO) VALUE ( @comentario )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@comentario", avaliacao.Comentario);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
