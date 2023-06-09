﻿using MyService_API.DTO;
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
                servico.Imagem = reader["IMAGEM"].ToString();
                servico.ID_WORK = int.Parse(reader["ID_WORK"].ToString());
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

            var query = @"INSERT INTO Servico_E ( NOME, DESCRICAO, CATEGORIA ,PRECO, IMAGEM, ID_WORK ) 
                        VALUES ( @nome, @descricao, @categoria, @preco, @imagem, @id_work )";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Cadastro_Produto.Nome);
            comando.Parameters.AddWithValue("@descricao", Cadastro_Produto.Descricao);
            comando.Parameters.AddWithValue("@categoria", Cadastro_Produto.Categoria);
            comando.Parameters.AddWithValue("@preco", Cadastro_Produto.Preco);
            comando.Parameters.AddWithValue("@imagem", Cadastro_Produto.Imagem);
            comando.Parameters.AddWithValue("@id_work", Cadastro_Produto.ID_WORK);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Alterar serviço
         */
        public void AlterarServico(ServicoE_DTO Servico_Alterar)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE Servico_E SET NOME = @nome, DESCRICAO = @descricao, 
                        CATEGORIA = @categoria, PRECO = @preco, IMAGEM = @imagem WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", Servico_Alterar.Nome);
            comando.Parameters.AddWithValue("@descricao", Servico_Alterar.Descricao);
            comando.Parameters.AddWithValue("@categoria", Servico_Alterar.Categoria);
            comando.Parameters.AddWithValue("@preco", Servico_Alterar.Preco);
            comando.Parameters.AddWithValue("@imagem", Servico_Alterar.Imagem);
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
