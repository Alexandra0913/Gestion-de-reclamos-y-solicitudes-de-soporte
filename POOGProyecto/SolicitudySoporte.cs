using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POOGProyecto
{
    internal class SolicitudSoporte : Reclamo

    {
            private string usuario;

            public string Usuario
            {
                get { return usuario; }
                set { usuario = value; }
            }

            public SolicitudSoporte(int id, string descripcion, string usuario)
                : base(id, descripcion)
            {
                this.usuario = usuario;
            }

            public void MostrarSoporte()
            {
                Mostrar();
                Console.WriteLine("Usuario: " + Usuario);
            }

            public static string ObtenerTipoErrorPorOpcion(int opciones)
            {
                switch (opciones)
                {
                    case 1:
                        return "Conexion";
                    case 2:
                        return "InicioSesion";
                    case 3:
                        return "Rendimiento";
                    case 4:
                        return "Otro";
                    default:
                        return "Invalido";
                }
            }
        }
    }