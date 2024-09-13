using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Libreria1.Modelos
{
    public class Libreria
    {
        public Dictionary<string, List<Libro>> Categorias { get; private set; }

        public Libreria()
        {

            Categorias = new Dictionary<string, List<Libro>>();


            Categorias["Ficcion"] = new List<Libro>
        {
            new Libro("El Señor de los Anillos", 29, 10)
        };

            Categorias["Historia"] = new List<Libro>
        {
            new Libro("Sapiens", 19, 5)
        };

            Categorias["Ciencia"] = new List<Libro>
        {
            new Libro("Breve historia del tiempo", 15, 8)
        };
        }

        public void MostrarCategorias()
        {
            Console.WriteLine("Categorías disponibles:");
            foreach (var categoria in Categorias.Keys)
            {
                Console.WriteLine($"- {categoria}");
            }
        }
        public void MostrarLibrosPorCategoria(string categoria)
        {
            if (Categorias.ContainsKey(categoria))
            {
                Console.WriteLine($"Libros en la categoría {categoria}:");
                foreach (var libro in Categorias[categoria])
                {
                    libro.MostrarDetalles();
                }
            }
            else
            {
                Console.WriteLine("Categoria no encontrada.");
            }
        }
        public bool ProcesarCompra(Libro libro, int cantidad)
        {
            if (libro.Stock >= cantidad)
            {
                libro.Stock -= cantidad;
                Console.WriteLine($"Compra exitosa. {cantidad} unidad(es) de '{libro.Nombre}' adquirida(s).");
                return true;
            }
            else
            {
                Console.WriteLine("No hay suficiente stock disponible.");
                return false;
            }
        }
    }
}
