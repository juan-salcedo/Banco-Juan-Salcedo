using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{

    public class CuentaAhorro : Cuenta
    {
        const decimal TOPEMINIMO= 10000;
        public CuentaAhorro(decimal saldo) : base(saldo)
        {
            TipoCuenta = "Cuenta Ahorro";
        }
      
        public override string Consignar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo = valor + Saldo;
                AgregarMovimiento("Consignado", valor);
                return $" su consignacion es de {valor} y su nuevo saldo es de {Saldo}";
            }
            return " no se pueden consignar valores negativo";
        }

       
        public override string Retirar(decimal valor)
        {
            if ((Saldo > 0) && (Saldo-valor >= TOPEMINIMO))
            {
                Saldo = Saldo - valor;
                AgregarMovimiento("retirado", valor);
                return $" Su retiro es de {valor} y su nuevo saldo es de {Saldo}";
            }
            return "No es sopible retirar de la cuenta";
        }
    }
}
