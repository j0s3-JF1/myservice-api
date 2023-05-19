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
                trabalhador.Telefone = reader["TELEFONE"].ToString();
                trabalhador.Instagram = reader["INSTAGRAM"].ToString();
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

            var query = @"INSERT INTO Trabalhador ( NOME, SOBRENOME, CPF, TELEFONE, EMAIL, SENHA ) VALUES ( @nome, @sobrenome, @cpf, @telefone, @email, @senha )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Trabalhador_Cadastro.Nome);
            comando.Parameters.AddWithValue("@sobrenome", Trabalhador_Cadastro.SobreNome);
            comando.Parameters.AddWithValue("@cpf", Trabalhador_Cadastro.CPF);
            comando.Parameters.AddWithValue("@telefone", Trabalhador_Cadastro.Telefone);
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

            var query = @"UPDATE Trabalhador SET NOME = @nome, SOBRENOME = @sobrenome, CPF = @cpf, TELEFONE = @telefone, EMAIL = @email, SENHA = @senha WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Trabalhador_Alterar.Nome);
            comando.Parameters.AddWithValue("@sobrenome", Trabalhador_Alterar.SobreNome);
            comando.Parameters.AddWithValue("@cpf", Trabalhador_Alterar.CPF);
            comando.Parameters.AddWithValue("@telefone", Trabalhador_Alterar.Telefone);
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
            Listagem de produtos
         */
        public List<ProdutoTrabalhadorDTO> Produtos( int id )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT Produto_T.ID, Produto_T.NOME, Produto_T.DESCRICAO, Produto_T.CATEGORIA, Produto_T.PRECO,
                        Trabalhador.NOME, Trabalhador.TELEFONE, Trabalhador.INSTAGRAM 
                        FROM Produto_T INNER JOIN Trabalhador ON Produto_T.ID_TRABALHADOR = Trabalhador.ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Lista = new List<ProdutoTrabalhadorDTO>();

            while (reader.Read())
            {
                var produto = new ProdutoTrabalhadorDTO();
                produto.ID_Produto = int.Parse(reader["ID"].ToString());
                produto.Produto_Nome = reader["NOME"].ToString();
                produto.Produto_Descricao = reader["DESCRICAO"].ToString();
                produto.Produto_Categoria = reader["CATEGORIA"].ToString();
                produto.Produto_Preco = double.Parse(reader["PRECO"].ToString());
                produto.Trabalhador_Nome = reader["NOME"].ToString();
                produto.Trabalhador_Telefone = reader["TELEFONE"].ToString();
                produto.Trabalhador_Instagram = reader["INSTAGRAM"].ToString();
                Lista.Add(produto);
            }
            Conexao.Close();
            return Lista;
        }
        /*
            Listagem de serviços
         */
        public List<ServicoTrabalhadorDTO> Servico( int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT Servico_T.ID, Servico_T.NOME, Servico_T.DESCRICAO, Servico_T.CATEGORIA, Servico_T.PRECO, 
                        Trabalhador.NOME, Trabalhador.TELEFONE, Trabalhador.INSTAGRAM 
                        FROM  Servico_T INNER JOIN Trabalhador ON Servico_T.ID_TRABALHADOR = Trabalhador.ID = @id";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Lista = new List<ServicoTrabalhadorDTO>();

            while (reader.Read())
            {
                var servico = new ServicoTrabalhadorDTO();
                servico.ID = int.Parse(reader["ID"].ToString());
                servico.Servico_Nome = reader["NOME"].ToString();
                servico.Servico_Descricao = reader["DESCRICAO"].ToString();
                servico.Servico_Categoria = reader["CATEGORIA"].ToString();
                servico.Servico_Preco = double.Parse(reader["PRECO"].ToString());
                servico.Trabalhador_Nome = reader["NOME"].ToString();
                servico.Trabalhador_Telefone = reader["TELEFONE"].ToString();
                servico.Trabalhador_Insta = reader["INSTAGRAM"].ToString();
                Lista.Add(servico);
            }
            Conexao.Close();
            return Lista;
        }
        /*
            Inserção de link do Instagram
         */
        public void Instagram( TrabalhadorDTO insta )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Trabalhador SET INSTAGRAM = @insta WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@insta", insta.Instagram);
            comando.Parameters.AddWithValue("@id", insta.ID);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
