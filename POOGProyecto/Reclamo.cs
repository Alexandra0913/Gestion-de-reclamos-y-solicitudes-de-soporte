using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOGProyecto
{
        internal class Reclamo
        {
            private int id;
            private string descripcion;
            private string estado;

            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }
            public string Estado
            {
                get { return estado; }
                set { estado = value; }
            }

            public Reclamo(int id, string descripcion)
            {
                this.id = id;
                this.descripcion = descripcion;
                estado = "Pendiente";

        }
        public void Mostrar()
            {
                Console.WriteLine("Id: " + id);
                Console.WriteLine("Descripcion: " + descripcion);
                Console.WriteLine("Estado: " + estado);
            }
        }
    }
