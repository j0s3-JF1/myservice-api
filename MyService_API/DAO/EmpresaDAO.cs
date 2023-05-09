using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class EmpresaDAO
    {
        /*
            Listar usuarios
         */
        public List<EmpresaDTO> ListarEmpresa()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Empresa";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<EmpresaDTO>();

            while (reader.Read())
            {
                var empresa = new EmpresaDTO();
                empresa.ID = int.Parse(reader["ID"].ToString());
                empresa.Nome = reader["NOME"].ToString();
                empresa.Empresa = reader["EMPRESA"].ToString();
                empresa.CNPJ = reader["CNPJ"].ToString();
                empresa.Email = reader["EMAIL"].ToString();
                empresa.Senha = reader["SENHA"].ToString();
                lista.Add(empresa);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Login do usuario
         */
        public List<EmpresaDTO> LoginEmpresa(EmpresaDTO Empresa_Login)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT EMAIL, SENHA FROM Empresa WHERE EMAIL = @email AND SENHA = @senha";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@email", Empresa_Login.Email);
            comando.Parameters.AddWithValue("@senha", Empresa_Login.Senha);

            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var lista = new List<EmpresaDTO>();

            while (reader.Read())
            {
                var empresa = new EmpresaDTO();
                empresa.Email = reader["EMAIL"].ToString();
                empresa.Senha = reader["SENHA"].ToString();
                lista.Add(empresa);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Cadastro do usuario
         */
        public void CadastroEmpresa(EmpresaDTO Empresa_Cadastro)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Empresa ( NOME, EMPRESA, CNPJ, EMAIL, SENHA ) VALUES ( @nome, @empresa, @cnpj, @email, @senha )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Empresa_Cadastro.Nome);
            comando.Parameters.AddWithValue("@empresa", Empresa_Cadastro.Empresa);
            comando.Parameters.AddWithValue("@cnpj", Empresa_Cadastro.CNPJ);
            comando.Parameters.AddWithValue("@email", Empresa_Cadastro.Email);
            comando.Parameters.AddWithValue("@senha", Empresa_Cadastro.Senha);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Alterar o usuario
         */
        public void AlterarEmpresa( EmpresaDTO Empresa_Alterar)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Empresa SET NOME = @nome, EMPRESA = @empresa, CNPJ = @cnpj
                EMAIL = @email, SENHA = @senha WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Empresa_Alterar.Nome);
            comando.Parameters.AddWithValue("@empresa", Empresa_Alterar.Empresa);
            comando.Parameters.AddWithValue("@cnpj", Empresa_Alterar.CNPJ);
            comando.Parameters.AddWithValue("@email", Empresa_Alterar.Email);
            comando.Parameters.AddWithValue("@senha", Empresa_Alterar.Senha);
            comando.Parameters.AddWithValue("@id", Empresa_Alterar.ID);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Deletar usuario
         */
        public void DeletarEmpresa( int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM Empresa WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            Conexao.Close();
        }
    }
}
