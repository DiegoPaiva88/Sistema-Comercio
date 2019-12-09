using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
    public class NFornecedor
    {
        //metodo Inserir
        public static string Inserir(string empresa, string setor_comercial, string tipo_documento, 
                                     string num_documento, string endereco,string telefone ,string email, string url)
        {
            DFornecedor Obj = new CamadaDados.DFornecedor();
            Obj.Empresa = empresa;
            Obj.Setor_comercial = setor_comercial;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Url = url;           

            return Obj.Inserir(Obj);
        }

        public static string Editar(int idfornecedor ,string empresa, string setor_comercial, string tipo_documento,
                                     string num_documento, string endereco, string telefone,  string email, string url)
        {
            DFornecedor Obj = new CamadaDados.DFornecedor();
            Obj.IdFornecedor = idfornecedor;
            Obj.Empresa = empresa;
            Obj.Setor_comercial = setor_comercial;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Url = url;

            return Obj.Editar(Obj);
        }

        //metodo Excluir
        public static string Excluir(int idfornecedor)
        {
            DFornecedor Obj = new CamadaDados.DFornecedor();
            Obj.IdFornecedor = idfornecedor;

            return Obj.Excluir(Obj);
        }

        //metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DFornecedor().Mostrar();

        }

        //metodo Buscar Nomes
        public static DataTable BuscarNome(string textobuscar)
        {
            DFornecedor Obj = new DFornecedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }

        //metodo Buscar por ducumento
        public static DataTable BuscarDocumento(string textobuscar)
        {
            DFornecedor Obj = new DFornecedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarDocumento(Obj);
        }

    }
}
