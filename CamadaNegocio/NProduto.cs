using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
     public class NProduto
    {
        //metodo Inserir
        public static string Inserir( string codigo, string nome, string descricao, byte[] imagem ,int idcategoria, int idapresentacao)
        {
            DProduto Obj = new CamadaDados.DProduto();
            Obj.Codigo = codigo;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            Obj.Imagem = imagem;
            Obj.IdCategoria = idcategoria;
            Obj.IdApresentacao = idapresentacao;

            return Obj.Inserir(Obj);
        }

        //metodo Editar
        public static string Editar(int idproduto, string codigo, string nome, string descricao, byte[] imagem, int idcategoria, int idapresentacao)
        {
            DProduto Obj = new CamadaDados.DProduto();
            Obj.IdProduto = idproduto;
            Obj.Codigo = codigo;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            Obj.Imagem = imagem;
            Obj.IdCategoria = idcategoria;
            Obj.IdApresentacao = idapresentacao;

            return Obj.Editar(Obj);
        }

        //metodo Excluir
        public static string Excluir(int idproduto)
        {
            DProduto Obj = new CamadaDados.DProduto();
            Obj.IdProduto = idproduto;

            return Obj.Excluir(Obj);
        }

        //metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DApresentacao().Mostrar();

        }


        //metodo Buscar Nomes
        public static DataTable BuscarNome(string textobuscar)
        {
            DProduto Obj = new DProduto();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}
