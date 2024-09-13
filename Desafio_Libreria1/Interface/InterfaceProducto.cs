using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Libreria1.Menu
{
    public interface IProducto
    {
        string Nombre { get; set; }
        decimal Precio { get; set; }
        int Stock { get; set; }

        void MostrarDetalles();
    }
}
