using DIO_Series.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_Series.Classes
{
    class Series : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Series(int id, Genero genero, string titulo, string descricao, int ano) 
        {
            this.ID = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Título: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Ano de ínicio: " + Ano+Environment.NewLine;
            retorno += "Excluído: " + Excluido;
            return retorno;
        }

        public string ReturnTitulo() 
        {
            return this.Titulo;
        }
        public int ReturnID() 
        {
            return this.ID;
        }
        public void Exclui() 
        {
            this.Excluido = true;
        }
        public bool ReturnExcluido() 
        {
            return this.Excluido;
        }
    }
}
