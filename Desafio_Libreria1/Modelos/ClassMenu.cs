using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Libreria1.Modelos
{
    public class Menu
    {
        private Usuario usuarioActual;
        private Libreria libreria;

        public Menu()
        {
            libreria = new Libreria();
        }
        public void MostrarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Cartel();
                Console.WriteLine("\n=================================");
                Console.WriteLine("       *** MENÚ PRINCIPAL ***");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Registrarse");
                Console.WriteLine("2. Iniciar Sesión");
                Console.WriteLine("3. Salir");
                Console.WriteLine("=================================");
                Console.WriteLine("Seleccione una opción: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string opcion = Console.ReadLine();
                Console.ResetColor();

                switch (opcion)
                {
                    case "1":
                        RegistrarUsuario();
                        break;
                    case "2":
                        if (IniciarSesion())
                        {
                            MostrarMenuCategorias();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Hasta Pronto.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Cartel()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=================================");
            Console.WriteLine("    ¡Bienvenido a la Librería!");
            Console.WriteLine("=================================");
            Console.ResetColor();
        }
        private void RegistrarUsuario()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=================================");
            Console.WriteLine("         *** REGISTRO ***");
            Console.WriteLine("=================================");
            Console.ResetColor();

            Console.Write("Ingrese su nombre de usuario: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string nombreUsuario = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Ingrese su contraseña: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string contrasena = Console.ReadLine();
            Console.ResetColor();
            usuarioActual = new Usuario(nombreUsuario, contrasena);
        }

        private bool IniciarSesion()
        {
            Console.Clear();

            if (usuarioActual == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Debe registrar un usuario primero.");
                Console.ResetColor();
                Console.ReadKey();
                return false;
            }

            Console.Write("Ingrese su nombre de usuario: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string nombreUsuario = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Ingrese su contraseña: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string contrasena = Console.ReadLine();
            Console.ResetColor();

            if (usuarioActual.IniciarSesion(nombreUsuario, contrasena))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Inicio de sesión exitoso.");
                Console.ResetColor();
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nombre de usuario o contraseña incorrectos.");
                Console.ResetColor();
                Console.ReadKey();
                return false;
            }
        }
        private void MostrarMenuCategorias()
        {
            Console.Clear();

            libreria.MostrarCategorias();
            Console.Write("Seleccione una categoría: ");
            string categoria = Console.ReadLine();
            libreria.MostrarLibrosPorCategoria(categoria);
            Console.Write("Seleccione un libro por su nombre: ");
            string nombreLibro = Console.ReadLine();

            var libroSeleccionado = libreria.Categorias[categoria].Find(libro => libro.Nombre == nombreLibro);

            if (libroSeleccionado != null)
            {
                Console.Write("Ingrese la cantidad a comprar: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (libreria.ProcesarCompra(libroSeleccionado, cantidad))
                {
                    SolicitarDatosTarjeta();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Libro no encontrado.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        private void SolicitarDatosTarjeta()
        {
            Console.Clear();

            Console.Write("Ingrese el número de tarjeta: ");
            string numeroTarjeta = Console.ReadLine();
            Console.Write("Ingrese la fecha de vencimiento (MM/AA): ");
            string fechaVencimiento = Console.ReadLine();
            Console.Write("Ingrese el código de seguridad: ");
            string codigoSeguridad = Console.ReadLine();

            TarjetaCredito tarjeta = new TarjetaCredito(numeroTarjeta, fechaVencimiento, codigoSeguridad);

            if (tarjeta.VerificarTarjeta())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pago confirmado. Gracias por su compra.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tarjeta no valida.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
