using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class ProdutoE_DAO
    {
        /*
            Listagem de produtos
         */
        public List<ProdutoE_DTO> ListarProdutoE()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Produto_E";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<ProdutoE_DTO>();

            while (reader.Read())
            {
                var produto = new ProdutoE_DTO();
                produto.ID = int.Parse(reader["ID"].ToString());
                produto.Nome = reader["NOME"].ToString();
                produto.Descricao = reader["DESCRICAO"].ToString();
                produto.Preco = float.Parse(reader["PRECO"].ToString());
                produto.ID_EMPRESA = int.Parse(reader["ID_TRABALHADOR"].ToString());
                produto.Like = int.Parse(reader["Likes"].ToString());
                lista.Add(produto);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Cadastro de produto
         */
        public void CadastrarProdutoE(ProdutoE_DTO Cadastro_Produto)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Produto_E ( NOME, DESCRICAO, PRECO ) VALUES ( @nome, @descricao, @preco )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Cadastro_Produto.Nome);
            comando.Parameters.AddWithValue("@descricao", Cadastro_Produto.Descricao);
            comando.Parameters.AddWithValue("@preco", Cadastro_Produto.Preco);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Curtidas do produto
         */
        public void CurtidasProdutoE(ProdutoE_DTO curtida)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Produto_E ( LIKES ) VALUES ( @curtida )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@curtidas", curtida.Like);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Leitura de curtidas
         */
        public List<ProdutoE_DTO> LeituraCurtida(ProdutoE_DTO curtida)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT LIKES FROM Produto_E WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", curtida.ID);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var lista = new List<ProdutoE_DTO>();

            while (reader.Read())
            {
                var curtidas = new ProdutoE_DTO();
                curtidas.Like = int.Parse(reader["LIKES"].ToString());
                lista.Add(curtidas);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Alterar Produto
         */
        public void AlterarProduto( ProdutoE_DTO Alterar_Produto)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Produto_E SET NOME = @nome, DESCRICAO = @descrica, PRECO = @preco WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Alterar_Produto.Nome);
            comando.Parameters.AddWithValue("@descricao", Alterar_Produto.Descricao);
            comando.Parameters.AddWithValue("@preco", Alterar_Produto.Preco);
            comando.Parameters.AddWithValue("@id", Alterar_Produto.ID);

            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        /*
            Deletar Produto
         */
        public void DeletarProduto( int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM Produto_E WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
