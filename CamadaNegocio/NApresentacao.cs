using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
     public class NApresentacao
    {
        //metodo Inserir
        public static string Inserir(string nome, string descricao)
        {
            DApresentacao Obj = new CamadaDados.DApresentacao();
            Obj.Nome = nome;
            Obj.Descricao = descricao;

            return Obj.Inserir(Obj);
        }

        //metodo Editar
        public static string Editar(int idapresentacao, string nome, string descricao)
        {
            DApresentacao Obj = new CamadaDados.DApresentacao();
            Obj.Idapresentacao = idapresentacao;
            Obj.Nome = nome;
            Obj.Descricao = descricao;

            return Obj.Editar(Obj);
        }

        //metodo Excluir
        public static string Excluir(int idapresentacao)
        {
            DApresentacao Obj = new CamadaDados.DApresentacao();
            Obj.Idapresentacao = idapresentacao;

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
            DApresentacao Obj = new DApresentacao();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}
