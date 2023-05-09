using MyService_API.DTO;
using MySql.Data.MySqlClient;
namespace MyService_API.DAO
{
    public class ServicoE_DAO
    {
        /*
            Listagem de usuarios
         */
        public List<ServicoE_DTO> ListarServicoE()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Servico_E";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<ServicoE_DTO>();

            while (reader.Read())
            {
                var servico = new ServicoE_DTO();
                servico.ID = int.Parse(reader["ID"].ToString());
                servico.Nome = reader["NOME"].ToString();
                servico.Descricao = reader["DESCRICAO"].ToString();
                servico.Preco = float.Parse(reader["PRECO"].ToString());
                servico.ID_EMPRESA = int.Parse(reader["ID_TRABALHADOR"].ToString());
                servico.Like = int.Parse(reader["Likes"].ToString());
                lista.Add(servico);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Cadastro de servico
         */
        public void CadastrarServicoE(ServicoE_DTO Cadastro_Produto)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Servico_E ( NOME, DESCRICAO, PRECO ) VALUES ( @nome, @descricao, @preco )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Cadastro_Produto.Nome);
            comando.Parameters.AddWithValue("@descricao", Cadastro_Produto.Descricao);
            comando.Parameters.AddWithValue("@preco", Cadastro_Produto.Preco);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Curtidas no serviço
         */
        public void CurtidasServicoE(ServicoE_DTO curtida)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Servico_E ( LIKES ) VALUES ( @curtida )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@curtidas", curtida.Like);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Leitura de curtidas
         */
        public List<ServicoE_DTO> LeituraCurtida(ServicoE_DTO curtida)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT LIKES FROM Servico_E WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", curtida.ID);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var lista = new List<ServicoE_DTO>();

            while (reader.Read())
            {
                var curtidas = new ServicoE_DTO();
                curtidas.Like = int.Parse(reader["LIKES"].ToString());
                lista.Add(curtidas);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Alterar serviço
         */
        public void AlterarServico(ServicoE_DTO Servico_Alterar)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Servico_E SET NOME = @nome, DESCRICAO = @descricao, PRECO = @preco WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Servico_Alterar.Nome);
            comando.Parameters.AddWithValue("@descricao", Servico_Alterar.Descricao);
            comando.Parameters.AddWithValue("@preco", Servico_Alterar.Preco);
            comando.Parameters.AddWithValue("id", Servico_Alterar.ID);

            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        /*
            Deletar Servico
         */
        public void DeletarServico( int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM Servico_E WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
