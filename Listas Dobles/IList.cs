using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Dobles
{

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public interface IList
    {
        // Inserta un valor en el lugar correcto según el orden.
        void InsertInOrder(int value);

        // Elimina y devuelve el primer elemento de la lista.
        int DeleteFirst();

        // Elimina y devuelve el último elemento de la lista.
        int DeleteLast();

        // Elimina el primer valor que coincida con el valor dado. Retorna verdadero si fue eliminado.
        bool DeleteValue(int value);

        // Devuelve el valor del elemento del medio de la lista.
        int GetMiddle();

        // Combina dos listas ordenadas (listA y listB) en la lista actual en el orden especificado por direction.
        void MergeSorted(IList listB, SortDirection direction);
    }

}
