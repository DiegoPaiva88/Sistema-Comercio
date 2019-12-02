using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
   public class DProduto
    {
        private int _IdProduto;
        private string _Codigo;
        private string _Nome;
        private string _Descricao;
        private byte[] _Imagem;
        private int _IdCategoria;
        private int _IdApresentacao;
        private string _TextoBuscar;

        public int IdProduto { get => _IdProduto; set => _IdProduto = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public byte[] Imagem { get => _Imagem; set => _Imagem = value; }
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public int IdApresentacao { get => _IdApresentacao; set => _IdApresentacao = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
    

        public DProduto()
        {

        }

        public DProduto(int idproduto, string codigo, string nome, string descricao, byte[] imagem, int idcategoria, int idapresentacao ,string textoBuscar)
        {
            this.IdProduto = idproduto;
            this.Codigo = codigo;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Imagem = imagem;
            this.IdCategoria = idcategoria;
            this.IdApresentacao = idapresentacao;
            this.TextoBuscar = textoBuscar;
        }

        //metodo Inserir
        public string Inserir(DProduto Produto)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproduto = new SqlParameter();
                ParIdproduto.ParameterName = "@idproduto";
                ParIdproduto.SqlDbType = SqlDbType.Int;
                ParIdproduto.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdproduto);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Produto.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Produto.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 100;
                ParDescricao.Value = Produto.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                SqlParameter ParImagem = new SqlParameter();
                ParImagem.ParameterName = "@imagem";
                ParImagem.SqlDbType = SqlDbType.Image;                
                ParImagem.Value = Produto.Imagem;
                SqlCmd.Parameters.Add(ParImagem);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Produto.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdApresentacao = new SqlParameter();
                ParIdApresentacao.ParameterName = "@idApresentacao";
                ParIdApresentacao.SqlDbType = SqlDbType.Int;
                ParIdApresentacao.Value = Produto.IdApresentacao;
                SqlCmd.Parameters.Add(ParIdApresentacao);

                //executar o comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi Inserido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

        //metodo Editar
        public string Editar(DProduto Produto)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproduto = new SqlParameter();
                ParIdproduto.ParameterName = "@idproduto";
                ParIdproduto.SqlDbType = SqlDbType.Int;
                ParIdproduto.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdproduto);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Produto.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Produto.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 100;
                ParDescricao.Value = Produto.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                SqlParameter ParImagem = new SqlParameter();
                ParImagem.ParameterName = "@imagem";
                ParImagem.SqlDbType = SqlDbType.Image;
                ParImagem.Value = Produto.Imagem;
                SqlCmd.Parameters.Add(ParImagem);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Produto.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdApresentacao = new SqlParameter();
                ParIdApresentacao.ParameterName = "@idApresentacao";
                ParIdApresentacao.SqlDbType = SqlDbType.Int;
                ParIdApresentacao.Value = Produto.IdApresentacao;
                SqlCmd.Parameters.Add(ParIdApresentacao);

                //executar o comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A edição nao foi realizada";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

        //metodo Excluir
        public string Excluir(DProduto Produto)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproduto = new SqlParameter();
                ParIdproduto.ParameterName = "@idproduto";
                ParIdproduto.SqlDbType = SqlDbType.Int;
                ParIdproduto.Value = Produto.IdProduto;
                SqlCmd.Parameters.Add(ParIdproduto);



                //executar o comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A exclusão nao foi realizada";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resp;
        }

        //metodo Mostar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("produto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        //metodo Buscar
        public DataTable BuscarNome(DProduto Produto)
        {
            DataTable DtResultado = new DataTable("produto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_nome_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Produto.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
