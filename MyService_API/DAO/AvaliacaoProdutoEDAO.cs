using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class AvaliacaoProdutoEDAO
    {
        public void AvaliacaoProdutoE(AvaliacaoProdutoEDTO avaliacao)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"insert into AvaliacaoProduto_E( COMENTARIO, ID_PRODUTO_E) VALUE (@comentario, @id);";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@comentario", avaliacao.Comentario);
            comando.Parameters.AddWithValue("@id", avaliacao.ID_PRODUTO_E);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public List<AvaliacaoProdutoEDTO> ListaDeComentario(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT AvaliacaoProduto_E.ID, AvaliacaoProduto_E.COMENTARIO, Produto_E.NOME, 
                        Produto_E.DESCRICAO, Produto_E.CATEGORIA, Produto_E.PRECO 
                        FROM AvaliacaoProduto_E INNER JOIN Produto_E ON AvaliacaoProduto_E.ID_PRODUTO_E = Produto_E.ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Lista = new List<AvaliacaoProdutoEDTO>();

            while (reader.Read())
            {
                var comentario = new AvaliacaoProdutoEDTO();
                comentario.ID = int.Parse(reader["ID"].ToString());
                comentario.Comentario = reader["COMENTARIO"].ToString();
                comentario.Produto_Nome = reader["NOME"].ToString();
                comentario.Produto_Descricao = reader["DESCRICAO"].ToString();
                comentario.Produto_Categoria = reader["CATEGORIA"].ToString();
                comentario.Produto_Preco = double.Parse(reader["PRECO"].ToString());
                Lista.Add(comentario);
            }
            Conexao.Close();
            return Lista;
        }

        public AvaliacaoProdutoEDTO Listar( int id )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM AvaliacaoProduto_E WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            var reader = comando.ExecuteReader();
            var avaliacao = new AvaliacaoProdutoEDTO();

            while(reader.Read())
            {
                avaliacao.ID = int.Parse(reader["ID"].ToString());
                avaliacao.Comentario = reader["COMENTARIO"].ToString();
            }

            Conexao.Close();

            return avaliacao;
        }
    }
}
