using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POOGProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Reclamo> reclamos = new List<Reclamo>();

            CargarArchivo(reclamos);

            Console.WriteLine("\n----- Registros de nuevos reclamos -----");
            Console.Write("Ingrese el ID del reclamo que necesita buscar: ");

            int idBuscar = int.Parse(Console.ReadLine());

            bool encontrado = false;

            foreach (Reclamo rc in reclamos)
            {
                if (rc.Id == idBuscar)
                {
                    Console.WriteLine("\nReclamo encontrado:\n");

                    if (rc is SoliSoporte)
                    {
                        ((SoliSoporte)rc).MostrarSoporte();
                    }
                    else
                    {
                        rc.Mostrar();
                    }

                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("\nNo se encontro ningun reclamo con el ID indicado");
            }

            Console.WriteLine("\nIngrese su nombre porfavor:");
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

            int nuevoId = reclamos.Count + 1;
            SoliSoporte s = new SoliSoporte(nuevoId, descripcion, nombre);
            reclamos.Add(s);

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Lista registrada de reclamos");
            Console.WriteLine("----------------------------");

            foreach (Reclamo r in reclamos)
            {
                if (r is SoliSoporte)
                {
                    ((SoliSoporte)r).MostrarSoporte();
                }
                else
                {
                    r.Mostrar();
                }
                Console.WriteLine();
            }

            GuardarArchivo(reclamos);

            Console.ReadKey();
        }

        static void GuardarArchivo(List<Reclamo> reclamos)
        {
            StreamWriter sw = new StreamWriter("reclamos.txt");

            foreach (Reclamo r in reclamos)
            {
                if (r is SoliSoporte)
                {
                    SoliSoporte s = (SoliSoporte)r;
                    sw.WriteLine("S," + s.Id + "," + s.Descripcion + "," + s.Estado + "," + s.Usuario);
                }
                else
                {
                    sw.WriteLine("R," + r.Id + "," + r.Descripcion + "," + r.Estado);
                }
            }
            sw.Close();
        }
        static void CargarArchivo(List<Reclamo> reclamos)
        {
            StreamReader sr = new StreamReader("reclamos.txt");

            string tipo = sr.ReadLine();

            while (tipo != "")
            {
                int id = int.Parse(sr.ReadLine());
                string descripcion = sr.ReadLine();
                string estado = sr.ReadLine();

                if (tipo == "R")
                {
                    Reclamo r = new Reclamo(id, descripcion);
                    r.Estado = estado;
                    reclamos.Add(r);
                }

                if (tipo == "S")
                {
                    string usuario = sr.ReadLine();
                    SoliSoporte s = new SoliSoporte(id, descripcion, usuario);
                    s.Estado = estado;
                    reclamos.Add(s);
                }

                tipo = sr.ReadLine();
            }
            sr.Close();
        }

    }
}