﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DFornecedor
    {
        private int _IdFornecedor;
        private string _Empresa;
        private string _Setor_comercial;
        private string _Tipo_documento;
        private string _num_documento;
        private string _Endereco;
        private string _Telefone;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;

        public int IdFornecedor { get => _IdFornecedor; set => _IdFornecedor = value; }
        public string Empresa { get => _Empresa; set => _Empresa = value; }
        public string Setor_comercial { get => _Setor_comercial; set => _Setor_comercial = value; }
        public string Tipo_documento { get => _Tipo_documento; set => _Tipo_documento = value; }
        public string Num_documento { get => _num_documento; set => _num_documento = value; }
        public string Endereco { get => _Endereco; set => _Endereco = value; }
        public string Telefone { get => _Telefone; set => _Telefone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DFornecedor()
        {

        }

        public DFornecedor(int idfornecedor, string empresa, string setor_comercial, string tipo_documento,
            string num_documento, string endereco, string telefone, string email, string url, string textoBuscar)
        {
            this.IdFornecedor = idfornecedor;
            this.Empresa = empresa;
            this.Setor_comercial = setor_comercial;
            this.Tipo_documento = tipo_documento;
            this.Num_documento = num_documento;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textoBuscar;
        }

        //metodo Inserir
        public string Inserir(DFornecedor Fornecedor)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdfornecedor = new SqlParameter();
                ParIdfornecedor.ParameterName = "@idfornecedor";
                ParIdfornecedor.SqlDbType = SqlDbType.Int;
                ParIdfornecedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdfornecedor);

                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@empresa";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = 50;
                ParEmpresa.Value = Fornecedor.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);

                SqlParameter ParSetor_comercial = new SqlParameter();
                ParSetor_comercial.ParameterName = "@setor_comercial";
                ParSetor_comercial.SqlDbType = SqlDbType.VarChar;
                ParSetor_comercial.Size = 50;
                ParSetor_comercial.Value = Fornecedor.Setor_comercial;
                SqlCmd.Parameters.Add(ParSetor_comercial);

                SqlParameter ParTipo_documento= new SqlParameter();
                ParTipo_documento.ParameterName = "@tipo_documento";
                ParTipo_documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_documento.Size = 50;
                ParTipo_documento.Value = Fornecedor.Tipo_documento;
                SqlCmd.Parameters.Add(ParTipo_documento);

                SqlParameter ParNum_documento = new SqlParameter();
                ParNum_documento.ParameterName = "@num_documento";
                ParNum_documento.SqlDbType = SqlDbType.VarChar;
                ParNum_documento.Size = 50;
                ParNum_documento.Value = Fornecedor.Num_documento;
                SqlCmd.Parameters.Add(ParNum_documento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 150;
                ParEndereco.Value = Fornecedor.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 50;
                ParTelefone.Value = Fornecedor.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Fornecedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 50;
                ParUrl.Value = Fornecedor.Url;
                SqlCmd.Parameters.Add(ParUrl);



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
        public string Editar(DFornecedor Fornecedor)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdFornecedor = new SqlParameter();
                ParIdFornecedor.ParameterName = "@idfornecedor";
                ParIdFornecedor.SqlDbType = SqlDbType.Int;
                ParIdFornecedor.Value = Fornecedor.IdFornecedor;
                SqlCmd.Parameters.Add(ParIdFornecedor);

                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@empresa";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = 50;
                ParEmpresa.Value = Fornecedor.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);

                SqlParameter ParSetor_comercial = new SqlParameter();
                ParSetor_comercial.ParameterName = "@setor_comercial";
                ParSetor_comercial.SqlDbType = SqlDbType.VarChar;
                ParSetor_comercial.Size = 50;
                ParSetor_comercial.Value = Fornecedor.Setor_comercial;
                SqlCmd.Parameters.Add(ParSetor_comercial);

                SqlParameter ParTipo_documento = new SqlParameter();
                ParTipo_documento.ParameterName = "@tipo_documento";
                ParTipo_documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_documento.Size = 50;
                ParTipo_documento.Value = Fornecedor.Tipo_documento;
                SqlCmd.Parameters.Add(ParTipo_documento);

                SqlParameter ParNum_documento = new SqlParameter();
                ParNum_documento.ParameterName = "@num_documento";
                ParNum_documento.SqlDbType = SqlDbType.VarChar;
                ParNum_documento.Size = 50;
                ParNum_documento.Value = Fornecedor.Num_documento;
                SqlCmd.Parameters.Add(ParNum_documento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 150;
                ParEndereco.Value = Fornecedor.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 50;
                ParTelefone.Value = Fornecedor.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Fornecedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 50;
                ParUrl.Value = Fornecedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Excluir(DFornecedor Fornecedor)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdfornecedor = new SqlParameter();
                ParIdfornecedor.ParameterName = "@idfornecedor";
                ParIdfornecedor.SqlDbType = SqlDbType.Int;
                ParIdfornecedor.Value = Fornecedor.IdFornecedor;
                SqlCmd.Parameters.Add(ParIdfornecedor);


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
            DataTable DtResultado = new DataTable("fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_fornecedor";
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

        //metodo Buscar Empresa
        public DataTable BuscarNome(DFornecedor Fornecedor)
        {
            DataTable DtResultado = new DataTable("fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_fornecedor_empresa";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.Value = Fornecedor.TextoBuscar;
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

        //metodo buscar por documento 
        public DataTable BuscarDocumento(DFornecedor Fornecedor)
        {
            DataTable DtResultado = new DataTable("fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_fornecedor_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 100;
                ParTextoBuscar.Value = Fornecedor.TextoBuscar;
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
