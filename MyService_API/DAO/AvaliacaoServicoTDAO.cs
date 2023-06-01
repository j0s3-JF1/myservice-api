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

            var query = @"INSERT INTO AvaliacaoServico_T(COMENTARIO, ID_SERVICO_T) VALUE ( @comentario, @id_servico )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@comentario", avaliacao.Comentario);
            comando.Parameters.AddWithValue("@id_servico", avaliacao.ID_SERVICO_T);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public List<AvaliacaoServicoTDTO> ListaDeComentario(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT AvaliacaoServico_T.ID, AvaliacaoServico_T.COMENTARIO, Servico_T.NOME, 
                        Servico_T.DESCRICAO, Servico_T.CATEGORIA, Servico_T.PRECO 
                        FROM AvaliacaoServico_T INNER JOIN Servico_T ON AvaliacaoServico_T.ID_SERVICO_T = Servico_T.ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Lista = new List<AvaliacaoServicoTDTO>();

            while (reader.Read())
            {
                var comentario = new AvaliacaoServicoTDTO();
                comentario.ID = int.Parse(reader["ID"].ToString());
                comentario.Comentario = reader["COMENTARIO"].ToString();
                comentario.Servico_Nome = reader["NOME"].ToString();
                comentario.Servico_Descricao = reader["DESCRICAO"].ToString();
                comentario.Servico_Categoria = reader["CATEGORIA"].ToString();
                comentario.Servico_Preco = double.Parse(reader["PRECO"].ToString());
                Lista.Add(comentario);
            }
            Conexao.Close();
            return Lista;
        }
    }
}
