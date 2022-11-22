using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PesquisaDB
{
    public class Cliente
    {
        string oChave = "Data Source=10.39.45.44;Initial Catalog=TI_Noite;User ID=Turma2022;Password=Turma2022@2022";

        public DataSet Listar_Produto(string p_Nome)
        {
            DataSet DataSetCliente = new DataSet();

            try
            {
                SqlConnection Conexao = new SqlConnection(oChave);
                Conexao.Open();
                string wQuery = $"select * From Produto where Nome_produto like '%{p_Nome}%'";
                SqlDataAdapter Adapter = new SqlDataAdapter(wQuery, Conexao);
                Adapter.Fill(DataSetCliente);
            }
            catch (Exception)
            {
                throw;
            }

            return DataSetCliente;
        }

        public DataSet Listar_Grupo(string p_Nome)
        {
            DataSet DataSetCliente = new DataSet();

            try
            {
                SqlConnection Conexao = new SqlConnection(oChave);
                Conexao.Open();
                string wQuery = $"select p.Nome_produto as Produto, g.Nome_produto as Grupo," +
                                $" p.id_produto,p.id_produto_grupo,p.Codigo_Interno,p.Nome_produto,p.Descricao," +
                                $" g.id_produto,g.id_produto_grupo,g.Codigo_Interno,g.Nome_produto,g.Descricao" +
                                $" from Produto p, Produto g" +
                                $" where p.id_produto_grupo = g.id_produto " +
                                $" and g.Nome_produto like '%{p_Nome}%'";
                SqlDataAdapter Adapter = new SqlDataAdapter(wQuery, Conexao);
                Adapter.Fill(DataSetCliente);

            }
            catch (Exception)
            {
                throw;
            }

            return DataSetCliente;
        }

        public int Cadastrar_Produto(string p_Nome, string p_idGrupo)
        {
            int Cadastrado;

            try
            {
                SqlConnection Conexao = new SqlConnection(oChave);
                Conexao.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Produto (Nome_Produto, id_produto_grupo)" +
                                                $" VALUES('{p_Nome}', '{p_idGrupo}')", Conexao);
                Cadastrado = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            return Cadastrado;
        }


        public int Cadastrar_Grupo(string p_Nome, string p_idGrupo)
        {
            int Cadastrado;

            try
            {
                SqlConnection Conexao = new SqlConnection(oChave);
                Conexao.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Produto (id_produto,Nome_Produto, id_produto_grupo)" +
                                                $" VALUES('{p_idGrupo}','{p_Nome}', '{p_idGrupo}')", Conexao);
                Cadastrado = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            return Cadastrado;
        }


        public int Apagar_ProdutoNome(string p_Nome)
        {
            int LinhasDeletadas;
            try
            {
                SqlConnection Conexao = new SqlConnection(oChave);
                Conexao.Open();
                SqlCommand cmd = new SqlCommand($"delete from Produto WHERE Nome_Produto = '{p_Nome}'", Conexao);
                LinhasDeletadas = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            return LinhasDeletadas;
        }

        public int Apagar_ProdutoId(string p_Id)
        {
            int LinhasDeletadas;
            try
            {
                SqlConnection Conexao = new SqlConnection(oChave);
                Conexao.Open();
                SqlCommand cmd = new SqlCommand($"delete from Produto WHERE id_produto = '{p_Id}'", Conexao);
                LinhasDeletadas = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            return LinhasDeletadas;
        }
        public int Alterar_Produto(string p_Nome, string p_NomeAtualizado)
        {

            int LinhasAlteradas;
            try
            {
                SqlConnection Conexao = new SqlConnection(oChave);
                Conexao.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE Produto SET" +
                                                $" Nome_Produto = '{p_NomeAtualizado}'," +
                                                $" WHERE Nome_Produto = '{p_Nome}'", Conexao);
                LinhasAlteradas = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            return LinhasAlteradas;            
        }

        public string Gerar_IdGrupo()
        {
            string idGrupoGerado = Guid.NewGuid().ToString();
            return idGrupoGerado;
        }
    }
}
