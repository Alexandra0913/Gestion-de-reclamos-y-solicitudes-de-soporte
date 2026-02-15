using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOGProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Reclamo> reclamos = new List<Reclamo>();

            Reclamo r1 = new Reclamo(1, "Este sistema no sirve como deberia");
            SoliSoporte s1 = new SoliSoporte(2, "Error al iniciar sesion", "Danilo");

            Reclamo r2 = new Reclamo(3, "Es demasiado lento");
            SoliSoporte s2 = new SoliSoporte(4, "Error de conexion", "Danilo");

            reclamos.Add(r1);
            reclamos.Add(s1);
            reclamos.Add(r2);
            reclamos.Add(s2);

            Console.WriteLine("\n ------- Registros de nuevos reclamos -------");
            Console.Write("Ingrese el ID del reclamo que necesita buscar: ");

            int idBuscar;
            while (!int.TryParse(Console.ReadLine(), out idBuscar))
            {
                Console.Write("El ID es invalido, Porfavor intentelo de nuevo: ");
            }

            Reclamo encontrado = reclamos.Find(r => r.Id == idBuscar);

            if (encontrado != null)
            {
                Console.WriteLine("\nReclamo encontrado:\n");

                if (encontrado is SoliSoporte)
                {
                    ((SoliSoporte)encontrado).MostrarSoporte();
                }
                else
                {
                    encontrado.Mostrar();
                }
            }
            else
            {
                Console.WriteLine("\nNo se encontró ningún reclamo con ese ID.");
            }


            Console.WriteLine("Ingrese su nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Seleccione el tipo de error:");
            Console.WriteLine("1 - Conexion");
            Console.WriteLine("2 - Inicio de sesion");
            Console.WriteLine("3 - Rendimiento");
            Console.WriteLine("4 - Otro");

            int opcion = int.Parse(Console.ReadLine());

            SoliSoporte temp = new SoliSoporte(0, "", "");
            string tipo = temp.ObtenerTipoErrorPorOpcion(opcion);

            string descripcion = "Error de " + tipo;

            SoliSoporte s = new SoliSoporte(5, descripcion, nombre);
            reclamos.Add(s);

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Lista registrada de reclamos");
            Console.WriteLine("----------------------------");

            foreach (Reclamo r in reclamos)
            {
                if (r is SoliSoporte)
                {
                    SoliSoporte sl = (SoliSoporte)r;
                    sl.MostrarSoporte();
                }
                else
                {
                    r.Mostrar();
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}