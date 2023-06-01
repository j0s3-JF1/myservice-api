using MySql.Data.MySqlClient;
using MyService_API.DTO;

namespace MyService_API.DAO
{
    public class UserDAO
    {
        /*
            Listagem dos Usuarios
         */
        public List<UserDTO> ListarUsuario()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Usuario";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<UserDTO>();

            while (reader.Read())
            {
                var usuario = new UserDTO();
                usuario.ID = int.Parse(reader["ID"].ToString());
                usuario.Nome = reader["NOME"].ToString();
                usuario.SobreNome = reader["SOBRENOME"].ToString();
                usuario.Email = reader["EMAIL"].ToString();
                usuario.Senha = reader["SENHA"].ToString();
                lista.Add(usuario);
            }
            Conexao.Close();
            return lista;
        }

        public UserDTO ListarPorID( int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Usuario WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            var reader = comando.ExecuteReader();
            var usuario = new UserDTO();

            while(reader.Read())
            {
                usuario.ID = int.Parse(reader["ID"].ToString());
                usuario.Nome = reader["NOME"].ToString();
                usuario.SobreNome = reader["SOBRENOME"].ToString();
                usuario.Email = reader["EMAIL"].ToString();
                usuario.Senha = reader["SENHA"].ToString();
            }
            Conexao.Close();
            return usuario;
        }

        /*
            Login do usuario no sistema
         */
        public UserDTO LoginUsuario( UserDTO dadosLogin )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Usuario WHERE EMAIL = @email AND SENHA = @senha";
            var comando = new MySqlCommand( query, Conexao);

            comando.Parameters.AddWithValue("@email", dadosLogin.Email);
            comando.Parameters.AddWithValue("@senha", dadosLogin.Senha);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var login = new UserDTO();
            
            while (reader.Read())
            {
                login.ID = int.Parse(reader["ID"].ToString());
                login.Nome = reader["NOME"].ToString();
                login.SobreNome = reader["SOBRENOME"].ToString();
                login.Email = reader["EMAIL"].ToString();
                login.Senha = reader["SENHA"].ToString();
            }
            Conexao.Close();

            return login;
        }

        /*
            Cadastro dos usuarios no sistema
         */
        public void CadastroUsuario ( UserDTO Usuario_Cadastro)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Usuario ( NOME, SOBRENOME, EMAIL, SENHA ) 
                        VALUES ( @nome, @sobrenome, @email, @senha )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Usuario_Cadastro.Nome);
            comando.Parameters.AddWithValue("@sobrenome", Usuario_Cadastro.SobreNome);
            comando.Parameters.AddWithValue("@email", Usuario_Cadastro.Email);
            comando.Parameters.AddWithValue("@senha", Usuario_Cadastro.Senha);

            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        /*
            Alteração de dados do usuario
         */
        public void AlterarUsuario( UserDTO Usuario_Alterar)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Usuario SET NOME = @nome, SOBRENOME = @sobrenome, EMAIL = @email, SENHA = @senha WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Usuario_Alterar.Nome);
            comando.Parameters.AddWithValue("@sobrenome", Usuario_Alterar.SobreNome);
            comando.Parameters.AddWithValue("@email", Usuario_Alterar.Email);
            comando.Parameters.AddWithValue("@senha", Usuario_Alterar.Senha);
            comando.Parameters.AddWithValue("@id", Usuario_Alterar.ID);

            comando.ExecuteNonQuery();
            Conexao.Close();
        }

        /*
            Deletar Usuario do sistema
         */
        public void DeletarUsuario( int id )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM Usuario WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            Conexao.Close();
        }
    }
}
