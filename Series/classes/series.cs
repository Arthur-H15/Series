using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    public class series : Base
    {
        private generos genero { get; set; }
        private string Titulo { get; set; }
        private string Descriçao { get; set; }
        private int Ano { get; set; }
        private bool excluido { get; set; }




        public series(int id, generos genero, string Titulo, string Descriçao, int Ano)
        {
            this.Ano = Ano;
            this.Id = id;
            this.genero = genero;
            this.Descriçao = Descriçao;
            this.Titulo = Titulo;
            this.excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "genero :" + this.genero + Environment.NewLine;
            retorno += "Ano :" + this.Ano + Environment.NewLine;
            retorno += "titulo :" + this.Titulo + Environment.NewLine;
            retorno += "descriçao:" + this.Descriçao + Environment.NewLine;
            retorno += "excluido:" + this.excluido + Environment.NewLine;

            return retorno;

        }
        public string retornatitulo()
        {
            return this.Titulo;
        }
        public int retornaid()
        {
            return this.Id;
        }
        public void exclui() { this.excluido = true; }
        public bool retornaExcluido()
        {
            return this.excluido;
        }
        public  generos retornagenero() 
        {
            
            return this.genero; }
        public int retornaano()
        {
            return this.Ano;
        }
        public string retornadescriçao()
        {
            return this.Descriçao;
        }
    }
        
}
