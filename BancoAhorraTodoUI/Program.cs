using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;

namespace BancoAhorraTodoUI
{
    class Program
    {
        static CuentaService CuentaService = new CuentaService();
        static void Main(string[] args)
        {
            MenuPrincipal();
        }
        public static void MenuCliente(Persona persona)
        {
            char Seguir = 'S';
            int op = 0;
            if (persona!= null)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1:Consignar");
                    Console.WriteLine("2:Retirar");
                    Console.WriteLine("3:Consultar Movimiento");
                    Console.WriteLine("4:Consultar Saldo");
                    Console.WriteLine("5:Salir");
                    Console.WriteLine("Eliga la opcion que desea");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1: Consignar(persona); break;
                        case 2: Retirar(persona); break;
                        case 3: ImprimirMovimiento(persona); break;
                        case 4: Saldo(persona); break;
                        case 5: Seguir = 'n'; break;
                        default: Console.WriteLine("opcion invalidad"); break;
                    }


                } while (Seguir == 'S');
            }
            else
            {
                Console.WriteLine("No esta registrada");
                Console.ReadKey();
            }

            
        }
        public static void MenuPrincipal()
        {
            char Seguir='S';
            int op = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu Principal");
                Console.WriteLine("1:registrarse");
                Console.WriteLine("2:Eliminar cuenta");
                Console.WriteLine("3:Consultar lista de cuentas");
                Console.WriteLine("4:Iniciar sesion");
                Console.WriteLine("5:Salir");
                Console.WriteLine("Eliga la opcion que desea");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1: CrearCuenta(); break;
                    case 2: EliminarPersona(); break;
                    case 3: ImprimirLista(); break;
                    case 4:MenuCliente(BuscarPersona()); break;
                    case 5: Seguir = 'n'; break;

                    default: Console.WriteLine("opcion invalidad"); break;
                }
               
            } while (Seguir=='S');

        }
        public static Persona BuscarPersona()
        {
            Console.Clear();
            Persona persona = new Persona();
            string identificacion;
            Console.WriteLine("ingrese su numero de cedula");
            identificacion = Console.ReadLine();
            persona= CuentaService.Buscar(identificacion);
            return persona;
        }
        public static void CrearCuenta()
        {
            Console.Clear();
            string TipoCueta;
            Persona persona = new Persona();
            Console.WriteLine("ingrese su documento");
            persona.Identificacion = Console.ReadLine();
            Console.WriteLine("ingrese su nombre");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("ingrese el tipo de cuenta que desea crear:Cuenta Ahorro digite (A)/Cuenta Corriente digite (C)");
            TipoCueta = Console.ReadLine();
            Console.WriteLine(persona.CrearTipoCuenta(TipoCueta));
            Console.WriteLine(CuentaService.Guardar(persona));
            Console.ReadKey();
        }
        public static void ImprimirLista()
        {
            Console.Clear();
            foreach (var persona in CuentaService.ImprimirLista())
            {
                Console.WriteLine($"NOMBRE:{persona.Nombre} TIPO DE CUENTA:" +
                    $"{persona.cuenta.TipoCuenta} SALDO:{persona.cuenta.Saldo}");
            }
            Console.ReadKey();
        }
        public static void Consignar(Persona persona)
        {
            Console.Clear();
            decimal valor;
            Console.WriteLine("Ingrese el valor que desea consignar");
            valor = decimal.Parse(Console.ReadLine());
            Console.WriteLine(persona.cuenta.Consignar(valor));
            Console.ReadKey();
                
        }
        public static void Retirar(Persona persona)
        {
            Console.Clear();
            decimal valor;
            Console.WriteLine("Ingrese el valor que desea retirar");
            valor = decimal.Parse(Console.ReadLine());
            Console.WriteLine(persona.cuenta.Retirar(valor));
            Console.ReadKey(); 

        }
        public static void EliminarPersona()
        {
            Console.Clear();
            string Respuesta;
            Console.WriteLine("ingrese el numero de cedula");
            Respuesta = Console.ReadLine();
            Console.WriteLine(CuentaService.Eliminar(Respuesta));
            Console.ReadKey();
        }
        public static void Saldo(Persona persona)
        {
            Console.Clear();
            Console.WriteLine($"su saldo es de {persona.cuenta.Saldo}");
            Console.ReadLine();
        }
        public static void ImprimirMovimiento(Persona persona)
        {
            Console.Clear();
            foreach (var item in persona.cuenta.movimientos )
            {
                Console.WriteLine($"usted ha {item.TipoMovimiento} de {item.Valor} con fecha {item.Fecha}");
            }
            Console.ReadKey();
        }
    }
}
