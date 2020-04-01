using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
namespace DAL
{
    public class CuentaRepository
    {
        List<Persona> personas = new List<Persona> ();
        public void Guardar(Persona persona)
        {
            personas.Add(persona);
        }
        public void Eliminar(Persona persona)
        {
            personas.Remove(persona);
        }
        public List<Persona> ImprimirLista()
        {
            return personas;
        }
        public Persona Buscar(string identificacion)
        {
            foreach (var persona in personas)
            {
                if (persona.Identificacion.Equals(identificacion))
                {
                    return persona;
                }
            }
            return null;
        }
        public Persona BuscarNumeroCuenta(string numeroCuenta)
        {
            foreach (var persona in personas)
            {
                if (persona.cuenta.NumeroCuenta.Equals(numeroCuenta))
                {
                    return persona;
                }
            }
            return null;
        }
     

    }
}
