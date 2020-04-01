using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public Cuenta cuenta { get; set; }



        public string CrearTipoCuenta(string respuesta)
        {
            cuenta = null;
            decimal SaldoInicial;
            if (respuesta.Equals("A"))
            {
                SaldoInicial = 10000;
                cuenta = new CuentaAhorro(SaldoInicial);
                cuenta.NumeroCuenta = Identificacion;
                return "se creo correctamente su Cuenta de Ahorro";
            }
            if (respuesta.Equals("C"))
            {
                SaldoInicial = 0;
                cuenta = new CuentaCorriente(SaldoInicial);
                cuenta.NumeroCuenta = Identificacion;
                return "se creo correctamente su Cuenta de Corriente";
            }
            return "no fue posible crear la cuenta";
        }






    }
}
