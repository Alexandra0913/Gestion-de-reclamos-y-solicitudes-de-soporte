using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            Id = id;
            Descripcion = descripcion;
            Estado = "Pendiente";
        }

        public void Mostrar()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Descripcion: " + Descripcion);
            Console.WriteLine("Estado: " + Estado);
        }
    }
}