using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class ProdutoT_DAO
    {
        /*
            Listagem de Produto
         */
        public List<ProdutoT_DTO> ListarProdutoT()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Produto_T";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<ProdutoT_DTO>();

            while (reader.Read())
            {
                var produto = new ProdutoT_DTO();
                produto.ID = int.Parse(reader["ID"].ToString());
                produto.Nome = reader["NOME"].ToString();
                produto.Descricao = reader["DESCRICAO"].ToString();
                produto.Categoria = reader["CATEGORIA"].ToString();
                produto.Preco = float.Parse(reader["PRECO"].ToString());
                produto.Imagem = reader["IMAGEM"].ToString();
                produto.ID_WORK = int.Parse(reader["ID_WORK"].ToString());
                lista.Add(produto);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Cadastro do Produto
         */
        public void CadastrarProdutoT( ProdutoT_DTO Cadastro_Produto)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Produto_T ( NOME, DESCRICAO, CATEGORIA, PRECO, IMAGEM, ID_WORK ) 
                        VALUES ( @nome, @descricao, @categoria, @preco, @imagem, @id_work )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Cadastro_Produto.Nome);
            comando.Parameters.AddWithValue("@descricao", Cadastro_Produto.Descricao);
            comando.Parameters.AddWithValue("@categoria", Cadastro_Produto.Categoria);
            comando.Parameters.AddWithValue("@preco", Cadastro_Produto.Preco);
            comando.Parameters.AddWithValue("@imagem", Cadastro_Produto.Imagem);
            comando.Parameters.AddWithValue("@id_work", Cadastro_Produto.ID_WORK);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
        /*
            Alterar produto
         */
        public void AlterarProduto( ProdutoT_DTO Alterar_Produto)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Produto_T SET NOME = @nome, DESCRICAO = @descricao, 
                        CATEGORIA = @categoria, PRECO = @preco, IMAGEM = @imagem WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Alterar_Produto.Nome);
            comando.Parameters.AddWithValue("@descricao", Alterar_Produto.Descricao);
            comando.Parameters.AddWithValue("@categoria", Alterar_Produto.Categoria);
            comando.Parameters.AddWithValue("@preco", Alterar_Produto.Preco);
            comando.Parameters.AddWithValue("@imagem", Alterar_Produto.Imagem);
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

            var query = @"DELETE FROM Produto_T WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
