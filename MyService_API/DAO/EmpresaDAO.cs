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
                empresa.Telefone = reader["TELEFONE"].ToString();
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

            var query = @"INSERT INTO Empresa ( NOME, EMPRESA, CNPJ, TELEFONE, EMAIL, SENHA ) VALUES ( @nome, @empresa, @cnpj, @telefone, @email, @senha )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Empresa_Cadastro.Nome);
            comando.Parameters.AddWithValue("@empresa", Empresa_Cadastro.Empresa);
            comando.Parameters.AddWithValue("@cnpj", Empresa_Cadastro.CNPJ);
            comando.Parameters.AddWithValue("@telefone", Empresa_Cadastro.Telefone);
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

            var query = @"UPDATE Empresa SET NOME = @nome, EMPRESA = @empresa, CNPJ = @cnpj, TELEFONE = @telefone,
                EMAIL = @email, SENHA = @senha WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Empresa_Alterar.Nome);
            comando.Parameters.AddWithValue("@empresa", Empresa_Alterar.Empresa);
            comando.Parameters.AddWithValue("@cnpj", Empresa_Alterar.CNPJ);
            comando.Parameters.AddWithValue("@telefone", Empresa_Alterar.Telefone);
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
        /*
         * Lista de Produtos
         */
        public List<ProdutoEmpresaDTO> Produtos( int id )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT Produto_E.ID, Produto_E.NOME, Produto_E.DESCRICAO,Produto_E.CATEGORIA, Produto_E.PRECO, 
                        Empresa.NOME, Empresa.EMPRESA, Empresa.TELEFONE, Empresa.INSTAGRAM 
                        FROM Produto_E INNER JOIN Empresa ON Produto_E.ID_EMPRESA = Empresa.ID = @id";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Lista = new List<ProdutoEmpresaDTO>();

            while (reader.Read())
            {
                var produto = new ProdutoEmpresaDTO();
                produto.ID = int.Parse(reader["ID"].ToString());
                produto.Produto_Nome = reader["NOME"].ToString();
                produto.Produto_Descricao = reader["DESCRICAO"].ToString();
                produto.Produto_Categoria = reader["CATEGORIA"].ToString();
                produto.Produto_Preco = double.Parse(reader["PRECO"].ToString());
                produto.Empresa_Nome = reader["NOME"].ToString();
                produto.Empresa_Empresa = reader["EMPRESA"].ToString();
                produto.Empresa_Telefone = reader["TELEFONE"].ToString();
                produto.Empresa_Insta = reader["INSTAGRAM"].ToString();
                Lista.Add(produto);
            }
            Conexao.Close();
            return Lista;
        }
        /*
         * Listagem de serviços
         */
        public List<ServicoEmpresaDTO> Servico( int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT Servico_E.ID, Servico_E.NOME, Servico_E.DESCRICAO, Servico_E.CATEGORIA, Servico_E.PRECO, 
                        Empresa.NOME, Empresa.EMPRESA, Empresa.TELEFONE, Empresa.INSTAGRAM 
                        FROM Servico_E INNER JOIN Empresa ON Servico_E.ID_EMPRESA = Empresa.ID = @id";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Lista = new List<ServicoEmpresaDTO>();

            while (reader.Read())
            {
                var servico = new ServicoEmpresaDTO();
                servico.ID = int.Parse(reader["ID"].ToString());
                servico.Servico_Nome = reader["NOME"].ToString();
                servico.Servico_Descricao = reader["DESCRICAO"].ToString();
                servico.Servico_Categoria = reader["CATEGORIA"].ToString();
                servico.Servico_Preco = double.Parse(reader["PRECO"].ToString());
                servico.Empresa_Nome = reader["NOME"].ToString();
                servico.Empresa_Empresa = reader["EMPRESA"].ToString();
                servico.Empresa_Telefone = reader["TELEFONE"].ToString();
                servico.Empresa_Insta = reader["INSTAGRAM"].ToString();
                Lista.Add(servico);
            }
            Conexao.Close();
            return Lista;
        }
        /*
            Inserção de link do instagram
         */
        public void Instagram( EmpresaDTO insta )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Empresa SET INSTAGRAM = @insta WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@insta", insta.Instagram);
            comando.Parameters.AddWithValue("@id", insta.ID);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
