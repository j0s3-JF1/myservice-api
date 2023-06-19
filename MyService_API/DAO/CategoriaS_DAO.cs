using MyService_API.DTO;
using MySql.Data.MySqlClient;

namespace MyService_API.DAO
{
    public class CategoriaS_DAO
    {
        public List<CategoriaS_DTO> ListarCategoriaS()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM CategoriaServico";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<CategoriaS_DTO>();

            while (reader.Read())
            {
                var categoria = new CategoriaS_DTO();
                categoria.ID = int.Parse(reader["ID"].ToString());
                categoria.Categoria = reader["CATEGORIA"].ToString();
                lista.Add(categoria);
            }
            Conexao.Close();
            return lista;
        }

        public void CurtidasCategoriaS(CategoriaS_DTO curtida)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO CategoriaServico ( LIKES ) VALUES ( @curtida )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@curtidas", curtida.Like);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public List<CategoriaS_DTO> LeituraCurtida(CategoriaS_DTO curtida)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT LIKES FROM CategoriaServico WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", curtida.ID);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var lista = new List<CategoriaS_DTO>();

            while (reader.Read())
            {
                var curtidas = new CategoriaS_DTO();
                curtidas.Like = int.Parse(reader["LIKES"].ToString());
                lista.Add(curtidas);
            }
            Conexao.Close();
            return lista;
        }

        /*
         * Listagem de serviços pela categoria (Trabalhador)
         */
        public ServicoT_DTO ListaServicoTrabalhador( string categoria)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Servico_T WHERE CATEGORIA = @categoria";
            var comando = new MySqlCommand( query, Conexao);
            comando.Parameters.AddWithValue("@categoria", categoria);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var servico = new ServicoT_DTO();

            while (reader.Read())
            {
                servico.ID = int.Parse(reader["ID"].ToString());
                servico.Nome = reader["NOME"].ToString();
                servico.Descricao = reader["DESCRICAO"].ToString();
                servico.Categoria = reader["CATEGORIA"].ToString();
                servico.Preco = float.Parse(reader["PRECO"].ToString());
                servico.ID_WORK = int.Parse(reader["ID_WORK"].ToString());
            }
            Conexao.Close();

            return servico;
        }

        /*
         *Listagem de serviços pela categoria (empresa)
         */
        public ServicoE_DTO ListaServicoEmpresa( string categoria )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Servico_E WHERE CATEGORIA = @categoria";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@categoria", categoria);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var servico = new ServicoE_DTO();

            while (reader.Read())
            {
                servico.ID = int.Parse(reader["ID"].ToString());
                servico.Nome = reader["NOME"].ToString();
                servico.Descricao = reader["DESCRICAO"].ToString();
                servico.Categoria = reader["CATEGORIA"].ToString();
                servico.Preco = float.Parse(reader["PRECO"].ToString());
                servico.ID_WORK = int.Parse(reader["ID_WORK"].ToString());
            }
            Conexao.Close();

            return servico;
        }
    }
}
