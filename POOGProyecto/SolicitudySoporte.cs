using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOGProyecto
{
    internal class SoliSoporte : Reclamo
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public SoliSoporte(int id, string descripcion, string usuario) : base(id, descripcion)
        {
            this.usuario = usuario;
        }

        public void MostrarSoporte()
        {
            Mostrar();
            Console.WriteLine("Usuario: " + usuario);
        }
        public bool ErrorV(string tipo)
        {
            string[] tiposPermitidos = { "Conexion", "InicioSesion", "Rendimiento", "Otro" };
            return tiposPermitidos.Contains(tipo);
        }
        public string ObtenerTipoErrorPorOpcion(int opciones)
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