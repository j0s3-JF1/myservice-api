using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class ServicoT_DAO
    {
        /*
            Listar Serviço
         */
        public List<ServicoT_DTO> ListarServicoT()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Servico_T";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<ServicoT_DTO>();

            while (reader.Read())
            {
                var servico = new ServicoT_DTO();
                servico.ID = int.Parse(reader["ID"].ToString());
                servico.Nome = reader["NOME"].ToString();
                servico.Descricao = reader["DESCRICAO"].ToString();
                servico.Categoria = reader["CATEGORIA"].ToString();
                servico.Preco = float.Parse(reader["PRECO"].ToString());
                servico.ID_TRABALHADOR = int.Parse(reader["ID_TRABALHADOR"].ToString());
                lista.Add(servico);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Cadastro do serviço
         */
        public void CadastrarServicoT(ServicoT_DTO Cadastro_Produto)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Servico_T ( NOME, DESCRICAO, CATEGORIA, PRECO, ID_TRABALHADOR ) 
                        VALUES ( @nome, @descricao, @categoria, @preco, @id_Trabalhador )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Cadastro_Produto.Nome);
            comando.Parameters.AddWithValue("@descricao", Cadastro_Produto.Descricao);
            comando.Parameters.AddWithValue("@categoria", Cadastro_Produto.Categoria);
            comando.Parameters.AddWithValue("@preco", Cadastro_Produto.Preco);
            comando.Parameters.AddWithValue("@id_Trabalhador", Cadastro_Produto.ID_TRABALHADOR);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Alterar serviço
         */
        public void AlterarSevico( ServicoT_DTO Servico_Alterar)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Servico_T SET NOME = @nome, DESCRICAO = @descricao, CATEGORIA = @categoria,
                        PRECO = @preco WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Servico_Alterar.Nome);
            comando.Parameters.AddWithValue("@descricao", Servico_Alterar.Descricao);
            comando.Parameters.AddWithValue("@categoria", Servico_Alterar.Categoria);
            comando.Parameters.AddWithValue("@preco", Servico_Alterar.Preco);
            comando.Parameters.AddWithValue("@id", Servico_Alterar.ID);

            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        /*
            Deletar Serviço
         */
        public void DeletarServico( int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM Servico_T WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
