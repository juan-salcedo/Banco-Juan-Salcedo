using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class Cuenta
    {
        public Persona persona { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal Saldo { get; set; }
        public List<Movimiento> movimientos { get; set; }
        public Cuenta(decimal saldo)
        {
            movimientos = new List<Movimiento>();
            Saldo = saldo;
        }

        public abstract string Consignar(decimal valor);
        public abstract string Retirar(decimal valor);


        public void AgregarMovimiento(string tipo,decimal valor)
        {
            Movimiento movimiento = new Movimiento();
            movimiento.Saldo = Saldo;
            movimiento.TipoMovimiento = tipo;
            movimiento.Fecha = DateTime.Now;
            movimiento.Valor = valor;
            movimientos.Add(movimiento);
        }

    }
}
