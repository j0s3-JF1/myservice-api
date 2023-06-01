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

            var query = @"INSERT INTO AvaliacaoProduto_T(COMENTARIO, ID_PRODUTO_T ) VALUES ( @comentario, @id_produto ) ";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@comentario", avaliacao.Comentario);
            comando.Parameters.AddWithValue("@id_produto", avaliacao.ID_PRODUTO_T);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public List<AvaliacaoProdutoTDTO> ListaDeComentario( int id )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT AvaliacaoProduto_T.ID, AvaliacaoProduto_T.COMENTARIO, 
                        Produto_T.NOME, Produto_T.DESCRICAO,Produto_T.CATEGORIA, Produto_T.PRECO 
                        FROM AvaliacaoProduto_T INNER JOIN Produto_T ON AvaliacaoProduto_T.ID_PRODUTO_T = Produto_T.ID = @id";
            var comando = new MySqlCommand( query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Lista = new List<AvaliacaoProdutoTDTO>();

            while ( reader.Read() )
            {
                var comentario = new AvaliacaoProdutoTDTO();
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
    }
}
