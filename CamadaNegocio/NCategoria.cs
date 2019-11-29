using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
    public class NCategoria
    {
        //metodo Inserir
        public static string Inserir(string nome, string descricao)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.Nome = nome;
            Obj.Descricao = descricao;

            return Obj.Inserir(Obj);
        }

        //metodo Editar
        public static string Editar(int idcategoria, string nome, string descricao)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nome = nome;
            Obj.Descricao = descricao;

            return Obj.Editar(Obj);
        }

        //metodo Excluir
        public static string Excluir(int idcategoria)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.Idcategoria = idcategoria;

            return Obj.Excluir(Obj);
        }

        //metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
           
        }


        //metodo Buscar Nomes
        public static DataTable BuscarNome(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}
