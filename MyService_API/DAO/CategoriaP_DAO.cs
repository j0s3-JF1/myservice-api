using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class CategoriaP_DAO
    {
        public List<CategoriaP_DTO> ListarCategoriaP()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM CategoriaProduto";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<CategoriaP_DTO>();

            while (reader.Read())
            {
                var categoria = new CategoriaP_DTO();
                categoria.ID = int.Parse(reader["ID"].ToString());
                categoria.Categoria = reader["CATEGORIA"].ToString();
                lista.Add(categoria);
            }
            Conexao.Close();
            return lista;
        }

        public void CurtidasCategoriaP(CategoriaP_DTO curtida)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO CategoriaProduto ( LIKES ) VALUES ( @curtida )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@curtidas", curtida.Like);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public List<CategoriaP_DTO> LeituraCurtida(CategoriaP_DTO curtida)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT LIKES FROM CategoriaProduto WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", curtida.ID);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var lista = new List<CategoriaP_DTO>();

            while (reader.Read())
            {
                var curtidas = new CategoriaP_DTO();
                curtidas.Like = int.Parse(reader["LIKES"].ToString());
                lista.Add(curtidas);
            }
            Conexao.Close();
            return lista;
        }

        /*
         * Busca de Produtos Apartir de Categorias (Trabalhador)
         */

        public ProdutoT_DTO ListaProdutoTrabalhador( string categoria )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Produto_T WHERE CATEGORIA = @categoria";

            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@categoria", categoria);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var produto = new ProdutoT_DTO();

            while (reader.Read())
            {
                produto.ID = int.Parse(reader["ID"].ToString());
                produto.Nome = reader["NOME"].ToString();
                produto.Descricao = reader["DESCRICAO"].ToString();
                produto.Categoria = reader["CATEGORIA"].ToString();
                produto.Preco = float.Parse(reader["PRECO"].ToString());
                produto.ID_WORK = int.Parse(reader["ID_WORK"].ToString());
            }

            Conexao.Close();

            return produto;
        }

        /*
         * Lista de produtos por categoria (Empresa)
         */

        public ProdutoE_DTO ListaProdutoEmpresa( string categoria )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Produto_E WHERE CATEGORIA = @categoria";
            var comando = new MySqlCommand( query, Conexao);
            comando.Parameters.AddWithValue("@categoria", categoria);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var produto = new ProdutoE_DTO();

            while (reader.Read())
            {
                produto.ID = int.Parse(reader["ID"].ToString());
                produto.Nome = reader["NOME"].ToString();
                produto.Descricao = reader["DESCRICAO"].ToString();
                produto.Categoria = reader["CATEGORIA"].ToString();
                produto.Preco = float.Parse(reader["PRECO"].ToString());
                produto.ID_WORK = int.Parse(reader["ID_WORK"].ToString());
            }
            Conexao.Close();

            return produto;
        }
    }
}
