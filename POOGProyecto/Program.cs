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
                SolicitudSoporte s1 = new SolicitudSoporte(2, "Error al iniciar sesion", "Danilo");

                Reclamo r2 = new Reclamo(1, "Es demasiado lento");
                SolicitudSoporte s2 = new SolicitudSoporte(2, "Error de conexion", "Danilo");

            reclamos.Add(r1);
                reclamos.Add(s1);

                foreach (Reclamo r in reclamos)
                {
                    if (r is SolicitudSoporte)
                    {
                        SolicitudSoporte s = (SolicitudSoporte)r;
                        s.MostrarSoporte();
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