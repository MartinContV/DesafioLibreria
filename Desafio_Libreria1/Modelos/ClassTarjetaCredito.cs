using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Libreria1.Modelos
{
    public class TarjetaCredito
    {
        public string Numero { get; set; }
        public string FechaVencimiento { get; set; }
        public string CodigoSeguridad { get; set; }

        public TarjetaCredito(string numero, string fechaVencimiento, string codigoSeguridad)
        {
            Numero = numero;
            FechaVencimiento = fechaVencimiento;
            CodigoSeguridad = codigoSeguridad;
        }
        public bool VerificarTarjeta()
        {
            return true;
        }
    }
}
