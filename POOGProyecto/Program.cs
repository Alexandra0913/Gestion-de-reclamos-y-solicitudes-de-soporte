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

            Console.WriteLine("-¡- Registros de nuevos reclamos -¡-");
            Console.Write("Ingrese el ID del reclamo que necesita buscar: ");

            int idBuscar = 0;
            bool valido = false;

            while (!valido)
            {
                try
                {
                    idBuscar = int.Parse(Console.ReadLine());

                    if (idBuscar > 0)
                    {
                        valido = true;
                    }
                    else
                    {
                        Console.WriteLine("El numero que ingrese tiene que ser mayor que 0:");
                    }
                }
                catch
                {
                    Console.WriteLine("Porfavor ingrese un numero valido:");
                }
            }

            bool encontrado = false;

            foreach (Reclamo rc in reclamos)
            {
                if (rc.Id == idBuscar)
                {
                    Console.WriteLine("El reclamo ha sido encontrado:");

                    if (rc is SolicitudSoporte)
                    {
                        ((SolicitudSoporte)rc).MostrarSoporte();
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

            string nombre = "";

            while (nombre == "")
            {
                Console.WriteLine("\nIngrese su nombre por favor:");
                nombre = Console.ReadLine();
            }

            Console.WriteLine("Seleccione el tipo de error:");
            Console.WriteLine("1 - Conexion");
            Console.WriteLine("2 - Inicio de sesion");
            Console.WriteLine("3 - Rendimiento");
            Console.WriteLine("4 - Otro");

            int opcion = 0;
            bool opcionValida = false;

            while (!opcionValida)
            {
                try
                {
                    opcion = int.Parse(Console.ReadLine());

                    if (opcion >= 1 && opcion <= 4)
                    {
                        opcionValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Seleciona una de las opciones entre 1 y 4:");
                    }
                }
                catch
                {
                    Console.WriteLine("Ingrese un numero valido:");
                }
            }

            string tipo = SolicitudSoporte.ObtenerTipoErrorPorOpcion(opcion);

            string descripcion = "Error de " + tipo;

            int nuevoId = reclamos.Count + 1;
            SolicitudSoporte s = new SolicitudSoporte(nuevoId, descripcion, nombre);
            reclamos.Add(s);

            Console.WriteLine();
            Console.WriteLine("--=--=--=--=--=--=--=--=--=--=--=--=--=--");
            Console.WriteLine("Lista registrada de reclamos");
            Console.WriteLine("--=--=--=--=--=--=--=--=--=--=--=--=--=--");

            foreach (Reclamo r in reclamos)
            {
                if (r is SolicitudSoporte)
                {
                    ((SolicitudSoporte)r).MostrarSoporte();
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
            using (StreamWriter sw = new StreamWriter("reclamos.txt"))
            {
                foreach (Reclamo r in reclamos)
                {
                    if (r is SolicitudSoporte s)
                    {
                        sw.WriteLine("S");
                        sw.WriteLine(s.Id);
                        sw.WriteLine(s.Descripcion);
                        sw.WriteLine(s.Estado);
                        sw.WriteLine(s.Usuario);
                    }
                    else
                    {
                        sw.WriteLine("R");
                        sw.WriteLine(r.Id);
                        sw.WriteLine(r.Descripcion);
                        sw.WriteLine(r.Estado);
                    }
                }
            }
        }

        static void CargarArchivo(List<Reclamo> reclamos)
        {
            if (!File.Exists("reclamos.txt"))
                return;

            using (StreamReader sr = new StreamReader("reclamos.txt"))
            {
                string tipo;

                while ((tipo = sr.ReadLine()) != null)
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
                    else if (tipo == "S")
                    {
                        string usuario = sr.ReadLine();
                        SolicitudSoporte s = new SolicitudSoporte(id, descripcion, usuario);
                        s.Estado = estado;
                        reclamos.Add(s);
                    }
                }
            }
        }
    }
}
