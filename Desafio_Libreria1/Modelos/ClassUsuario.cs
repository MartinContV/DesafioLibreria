using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Libreria1.Modelos
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        public Usuario(string nombreUsuario, string contraseña)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
        }
        public bool IniciarSesion(string nombreUsuario, string contraseña)
        {
            return NombreUsuario == nombreUsuario && Contraseña == contraseña;
        }
    }
}
