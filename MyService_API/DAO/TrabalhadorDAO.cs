using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class TrabalhadorDAO
    {
        /*
            Listagem de usuarios
         */
        public List<TrabalhadorDTO> ListarTrabalhador()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Trabalhador";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<TrabalhadorDTO>();

            while (reader.Read())
            {
                var trabalhador = new TrabalhadorDTO();
                trabalhador.ID = int.Parse(reader["ID"].ToString());
                trabalhador.Nome = reader["NOME"].ToString();
                trabalhador.SobreNome = reader["SOBRENOME"].ToString();
                trabalhador.CPF = reader["CPF"].ToString();
                trabalhador.Email = reader["EMAIL"].ToString();
                trabalhador.Senha = reader["SENHA"].ToString();
                lista.Add(trabalhador);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Login do usuario
         */
        public List<TrabalhadorDTO> LoginTrabalhador( TrabalhadorDTO Trabalhador_Login)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT EMAIL, SENHA FROM Trabalhador WHERE EMAIL = @email AND SENHA = @senha";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@email", Trabalhador_Login.Email);
            comando.Parameters.AddWithValue("@senha", Trabalhador_Login.Senha);

            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var lista = new List<TrabalhadorDTO>();

            while (reader.Read())
            {
                var trabalhador = new TrabalhadorDTO();
                trabalhador.Email = reader["EMAIL"].ToString();
                trabalhador.Senha = reader["SENHA"].ToString();
                lista.Add(trabalhador);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Cadastro do usuario
         */
        public void CadastroTrabalhador( TrabalhadorDTO Trabalhador_Cadastro)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Trabalhador ( NOME, SOBRENOME, CPF, EMAIL, SENHA ) VALUES ( @nome, @sobrenome, @cpf, @email, @senha )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Trabalhador_Cadastro.Nome);
            comando.Parameters.AddWithValue("@sobrenome", Trabalhador_Cadastro.SobreNome);
            comando.Parameters.AddWithValue("@cpf", Trabalhador_Cadastro.CPF);
            comando.Parameters.AddWithValue("@email", Trabalhador_Cadastro.Email);
            comando.Parameters.AddWithValue("@senha", Trabalhador_Cadastro.Senha);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Alterar usuario
         */
        public void AlerarTrabalho( TrabalhadorDTO Trabalhador_Alterar)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Trabalhador SET NOME = @nome, SOBRENOME = @sobrenome, CPF = @cpf, EMAIL = @email, SENHA = @senha WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Trabalhador_Alterar.Nome);
            comando.Parameters.AddWithValue("@sobrenome", Trabalhador_Alterar.SobreNome);
            comando.Parameters.AddWithValue("@cpf", Trabalhador_Alterar.CPF);
            comando.Parameters.AddWithValue("@email", Trabalhador_Alterar.Email);
            comando.Parameters.AddWithValue("@senha", Trabalhador_Alterar.Senha);
            comando.Parameters.AddWithValue("@id", Trabalhador_Alterar.ID);

            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        /*
           Deletar Usuario
         */
        public void DeletarTrabalhador(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM Trabalhador WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("id", id);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Listagem de produtos do Trabalhador
         */
        public List<ProdutoT_DTO> ProdutosTrabalhador( int id )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT Produto_T.ID, Produto_T.NOME, Produto_T.DESCRICAO, Produto_T.PRECO, 
                            Trabalhador.NOME, Trabalhador.EMAIL 
                            FROM Produto_T 
                            INNER JOIN Trabalhador ON Produto_T.ID_TRABALHADOR = Trabalhador.ID = @id";

            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Lista = new List<ProdutoT_DTO>();

            while (reader.Read())
            {
                var produtos = new ProdutoT_DTO();
                produtos.ID = int.Parse(reader["ID"].ToString());
                produtos.Nome = reader["NOME"].ToString();
                produtos.Descricao = reader["DESCRICAO"].ToString();
                produtos.Preco = float.Parse(reader["PRECO"].ToString());
                produtos.ID_Trabalhador = int.Parse(reader["ID_TRABALHADOR"].ToString());
                Lista.Add(produtos);
            }
            Conexao.Close();
            return Lista;
        }
    }
}
