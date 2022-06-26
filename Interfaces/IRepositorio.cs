using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_Series.Interfaces
{
    public interface IRepositorio<T>
    {

        IList<T> Lista();
        T RetornaPorID(int id);
        void Insere(T entidade);
        void Exclui(int id);
        int ProximoID();
        void Atualiza(int id, T objeto);
    }
}
