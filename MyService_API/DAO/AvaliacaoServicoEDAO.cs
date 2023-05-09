using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class AvaliacaoServicoEDAO
    {
        public void AvaliacaoServicoE(AvaliacaoServicoEDTO avaliacao)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO AvaliacaoServico_E(COMENTARIO) VALUE ( @comentario )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@comentario", avaliacao.Comentario);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
