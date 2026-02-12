using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOGProyecto
{
        internal class SolicitudSoporte : Reclamo
        {
            private string tecnico;

            public string Tecnico
            {
                get { return tecnico; }
                set { tecnico = value; }
            }

            public SolicitudSoporte(int id, string descripcion, string tecnico) : base(id, descripcion)
            {
                this.tecnico = tecnico;
            }
            public void MostrarSoporte()
            {
                Mostrar();
                Console.WriteLine("Tecnico: " + tecnico);
            }
        }
}