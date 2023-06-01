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

            var query = @"INSERT INTO AvaliacaoServico_E(COMENTARIO, ID_SERVICO_E) VALUE ( @comentario, @id_servico )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@comentario", avaliacao.Comentario);
            comando.Parameters.AddWithValue("@id_servico", avaliacao.ID_SERVICO_E);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public List<AvaliacaoServicoEDTO> ListaDeComentario(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT AvaliacaoServico_E.ID, AvaliacaoServico_E.COMENTARIO, Servico_E.NOME, 
                        Servico_E.DESCRICAO, Servico_E.CATEGORIA, Servico_E.PRECO 
                        FROM AvaliacaoServico_E INNER JOIN Servico_E ON AvaliacaoServico_E.ID_SERVICO_E = Servico_E.ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Lista = new List<AvaliacaoServicoEDTO>();

            while (reader.Read())
            {
                var comentario = new AvaliacaoServicoEDTO();
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
