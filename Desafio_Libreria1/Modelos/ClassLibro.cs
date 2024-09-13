using Desafio_Libreria1.Menu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Desafio_Libreria1.Modelos
{
    public class Libro : IProducto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Libro(string nombre, decimal precio, int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Nombre: {Nombre}, Precio: {Precio:C}, Stock disponible: {Stock}");
        }
    }
}
