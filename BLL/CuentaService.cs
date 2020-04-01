using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;
namespace BLL
{
    public class CuentaService
    {
        CuentaRepository cuentaRepository = new CuentaRepository();
        public string Guardar(Persona persona)
        {
            if ((persona.cuenta!=null)&& (cuentaRepository.Buscar(persona.Identificacion)==null))
            {
                cuentaRepository.Guardar(persona);
                return "la persona se registro correctamente";
            }
            return "no se registro la persona";
        }
        public string Eliminar(string numeroCuenta)
        {
            if (cuentaRepository.BuscarNumeroCuenta(numeroCuenta)!=null)
            {
                cuentaRepository.Eliminar(cuentaRepository.BuscarNumeroCuenta(numeroCuenta));
                return " se elimino correctamente";
            }
            return "no se encontro ninguna cuenta con ese numero";
        }
        public List<Persona> ImprimirLista()
        {
            return cuentaRepository.ImprimirLista();
        }

        public Persona Buscar(string identificacion)
        {
            return cuentaRepository.Buscar(identificacion);
        }
       
        
        

    }
}
