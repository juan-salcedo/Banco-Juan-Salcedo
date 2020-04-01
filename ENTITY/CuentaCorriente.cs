using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class CuentaCorriente : Cuenta
    {
        const decimal TOPE =100000;
        public CuentaCorriente(decimal saldo) : base(saldo)
        {
            TipoCuenta = "Cuenta Corriente";
        }
        public override string Consignar(decimal valor)
        {
            if ((valor <= Saldo) && (valor > 0))
            {
                Saldo = Saldo - valor;
                AgregarMovimiento("Consignado", valor);
                return $" Su consignacion es de {valor} y su nuevo saldo es de {Saldo}";
            }
            return "No es sopible consignar en la cuenta";
        }

       

        public override string Retirar(decimal valor)
        {
            if ((valor+Saldo<=TOPE)&&(valor>0))
            {
                Saldo = Saldo + valor;
                AgregarMovimiento("retirado", valor);
                return $" Su retiro es de {valor} y su nuevo saldo es de {Saldo}";
            }
            return "No es sopible retirar de la cuenta";
        }

       
    }
}
