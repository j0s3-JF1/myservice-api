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

            var query = @"SELECT * FROM Worker";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<TrabalhadorDTO>();

            while (reader.Read())
            {
                var trabalhador = new TrabalhadorDTO();
                trabalhador.ID = int.Parse(reader["ID"].ToString());
                trabalhador.Nome = reader["NOME"].ToString();
                trabalhador.Empresa = reader["EMPRESA"].ToString();
                trabalhador.CPF_CNPJ = reader["CPF_CNPJ"].ToString();
                trabalhador.Telefone = reader["TELEFONE"].ToString();
                trabalhador.Instagram = reader["INSTAGRAM"].ToString();
                trabalhador.Email = reader["EMAIL"].ToString();
                trabalhador.Senha = reader["SENHA"].ToString();
                trabalhador.Acesso = reader["ACESSO"].ToString();
                trabalhador.Imagem = reader["IMAGEM"].ToString();
                lista.Add(trabalhador);
            }
            Conexao.Close();
            return lista;
        }

        /*
            Listagem de usuarios por ID
         */
        public TrabalhadorDTO ListarTrabalhadorPorID( int id )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Worker WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            var reader = comando.ExecuteReader();
            var trabalhador = new TrabalhadorDTO();

            while (reader.Read())
            {
                trabalhador.ID = int.Parse(reader["ID"].ToString());
                trabalhador.Nome = reader["NOME"].ToString();
                trabalhador.Empresa = reader["EMPRESA"].ToString();
                trabalhador.CPF_CNPJ = reader["CPF_CNPJ"].ToString();
                trabalhador.Telefone = reader["TELEFONE"].ToString();
                trabalhador.Instagram = reader["INSTAGRAM"].ToString();
                trabalhador.Email = reader["EMAIL"].ToString();
                trabalhador.Senha = reader["SENHA"].ToString();
                trabalhador.Acesso = reader["ACESSO"].ToString();
                trabalhador.Imagem = reader["IMAGEM"].ToString();
            }
            Conexao.Close();
            return trabalhador;
        }

        /*
            Login do usuario
         */
        public TrabalhadorDTO LoginTrabalhador( TrabalhadorDTO dadoslogin)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM Worker WHERE EMAIL = @email AND SENHA = @senha";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@email", dadoslogin.Email);
            comando.Parameters.AddWithValue("@senha", dadoslogin.Senha);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var login = new TrabalhadorDTO();

            while (reader.Read())
            {
                login.ID = int.Parse(reader["ID"].ToString());
                login.Nome = reader["NOME"].ToString();
                login.Empresa = reader["EMPRESA"].ToString();
                login.CPF_CNPJ = reader["CPF_CNPJ"].ToString();
                login.Telefone = reader["TELEFONE"].ToString();
                login.Instagram = reader["INSTAGRAM"].ToString();
                login.Email = reader["EMAIL"].ToString();
                login.Senha = reader["SENHA"].ToString();
                login.Acesso = reader["ACESSO"].ToString();
                login.Imagem = reader["IMAGEM"].ToString();
            }

            Conexao.Close();

            return login;

        }

        /*
            Cadastro do usuario
         */
        public void CadastroTrabalhador( TrabalhadorDTO Trabalhador_Cadastro)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO Worker ( NOME, EMPRESA, CPF_CNPJ, TELEFONE, EMAIL, SENHA, ACESSO, IMAGEM ) 
                        VALUES ( @nome, @empresa, @cpf_cnpj, @telefone, @email, @senha, @acesso, @imagem)";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Trabalhador_Cadastro.Nome);
            comando.Parameters.AddWithValue("@empresa", Trabalhador_Cadastro.Empresa);
            comando.Parameters.AddWithValue("@cpf_cnpj", Trabalhador_Cadastro.CPF_CNPJ);
            comando.Parameters.AddWithValue("@telefone", Trabalhador_Cadastro.Telefone);
            comando.Parameters.AddWithValue("@email", Trabalhador_Cadastro.Email);
            comando.Parameters.AddWithValue("@senha", Trabalhador_Cadastro.Senha);
            comando.Parameters.AddWithValue("@acesso", Trabalhador_Cadastro.Acesso);
            comando.Parameters.AddWithValue("@imagem", Trabalhador_Cadastro.Imagem);

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

            var query = @"UPDATE Worker SET NOME = @nome, EMPRESA = @empresa, 
                        CPF_CNPJ = @cpf_cnpj, TELEFONE = @telefone, INSTAGRAM = @instagram, EMAIL = @email, SENHA = @senha, 
                        ACESSO = @acesso, IMAGEM = @imagem WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Trabalhador_Alterar.Nome);
            comando.Parameters.AddWithValue("@empresa", Trabalhador_Alterar.Empresa);
            comando.Parameters.AddWithValue("@cpf_cnpj", Trabalhador_Alterar.CPF_CNPJ);
            comando.Parameters.AddWithValue("@telefone", Trabalhador_Alterar.Telefone);
            comando.Parameters.AddWithValue("@instagram", Trabalhador_Alterar.Instagram);
            comando.Parameters.AddWithValue("@email", Trabalhador_Alterar.Email);
            comando.Parameters.AddWithValue("@senha", Trabalhador_Alterar.Senha);
            comando.Parameters.AddWithValue("@acesso", Trabalhador_Alterar.Acesso);
            comando.Parameters.AddWithValue("@imagem", Trabalhador_Alterar.Imagem);
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

            var query = @"DELETE FROM Worker WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("id", id);
            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Listagem de produtos Trabalhador
         */
        public List<ProdutoTrabalhadorDTO> ProdutosTrabalhador( int id )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT Produto_T.ID, Produto_T.NOME, Produto_T.DESCRICAO, Produto_T.CATEGORIA, Produto_T.PRECO, Produto_T.IMAGEM,
                        Worker.NOME, Worker.TELEFONE, Worker.INSTAGRAM 
                        FROM Produto_T INNER JOIN Worker ON Produto_T.ID_WORK = Worker.ID = @id";
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
                produto.Produto_Imagem = reader["IMAGEM"].ToString();
                produto.Trabalhador_Nome = reader["NOME"].ToString();
                produto.Trabalhador_Telefone = reader["TELEFONE"].ToString();
                produto.Trabalhador_Instagram = reader["INSTAGRAM"].ToString();
                Lista.Add(produto);
            }
            Conexao.Close();
            return Lista;
        }
        /*
            Listagem de produtos Empresa
         */
        public List<ProdutoEmpresaDTO> ProdutosEmpresa(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT Produto_E.ID, Produto_E.NOME, Produto_E.DESCRICAO, Produto_E.CATEGORIA, Produto_E.PRECO, Produto_E.IMAGEM,
                        Worker.NOME, Worker.EMPRESA, Worker.TELEFONE, Worker.INSTAGRAM 
                        FROM Produto_E INNER JOIN Worker ON Produto_E.ID_WORK = Worker.ID = @id";
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
                produto.Produto_Imagem = reader["IMAGEM"].ToString();
                produto.Worker_Nome = reader["NOME"].ToString();
                produto.Empresa_Empresa = reader["EMPRESA"].ToString();
                produto.Empresa_Telefone = reader["TELEFONE"].ToString();
                produto.Empresa_Insta = reader["INSTAGRAM"].ToString();
                Lista.Add(produto);
            }
            Conexao.Close();
            return Lista;
        }
        /*
            Listagem de serviços Trabalhador
         */
        public List<ServicoTrabalhadorDTO> ServicoTrabalhador( int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT Servico_T.ID, Servico_T.NOME, Servico_T.DESCRICAO, Servico_T.CATEGORIA, Servico_T.PRECO, Servico_T.IMAGEM, 
                        Worker.NOME, Worker.TELEFONE, Worker.INSTAGRAM 
                        FROM  Servico_T INNER JOIN Worker ON Servico_T.ID_WORK = Worker.ID = @id";
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
                servico.Servico_Imagem = reader["IMAGEM"].ToString();
                servico.Trabalhador_Nome = reader["NOME"].ToString();
                servico.Trabalhador_Telefone = reader["TELEFONE"].ToString();
                servico.Trabalhador_Insta = reader["INSTAGRAM"].ToString();
                Lista.Add(servico);
            }
            Conexao.Close();
            return Lista;
        }
        /*
            Listagem de serviços Empresa
         */
        public List<ServicoTrabalhadorDTO> ServicoEmpresa(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT Servico_E.ID, Servico_E.NOME, Servico_E.DESCRICAO, Servico_E.CATEGORIA, Servico_E.PRECO, Servico_E.IMAGEM, 
                        Worker.NOME, Worker.TELEFONE, Worker.INSTAGRAM 
                        FROM  Servico_E INNER JOIN Worker ON Servico_E.ID_WORK = Worker.ID = @id";
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
                servico.Servico_Imagem = reader["PRECO"].ToString();
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

            var query = @"UPDATE Worker SET INSTAGRAM = @insta WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@insta", insta.Instagram);
            comando.Parameters.AddWithValue("@id", insta.ID);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
        /*
            Acesso do usuario
         */
        public TrabalhadorDTO Access( int id )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT ACESSO FROM Worker WHERE ID = @id";
            var comando = new MySqlCommand( query, Conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            var reader = comando.ExecuteReader();
            var Acesso = new TrabalhadorDTO();

            while (reader.Read())
            {
                Acesso.Acesso = reader["ACESSO"].ToString();
            }
            Conexao.Close();

            return Acesso;
            
        }
    }
}
