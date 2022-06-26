using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIO_Series.Interfaces;

namespace DIO_Series.Classes
{
    class SeriesRepositorio : IRepositorio<Series>
    {
        private List<Series> listaSeries = new List<Series>();

        public void Atualiza(int id, Series objeto)
        {
            listaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Exclui();
        }

        public void Insere(Series entidade)
        {
            listaSeries.Add(entidade);
        }

        public IList<Series> Lista()
        {
            return listaSeries;
        }

        public int ProximoID()
        {
            return listaSeries.Count;
        }

        public Series RetornaPorID(int id)
        {
            return listaSeries[id];
        }
    }
}
