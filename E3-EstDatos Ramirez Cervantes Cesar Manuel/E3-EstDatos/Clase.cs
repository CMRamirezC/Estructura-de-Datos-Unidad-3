using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_EstDatos
{
    public class Clase
    {
        public string Maestro { get; set; }
        public string Alumno { get; set; }
        public string NombreClase { get; set; }
        public int Calificacion { get; set; }
        public Clase()
        {

        }
        public object Promedio(Stack<int> Calificaciones)
        {
            int suma = 0;
            foreach(var item in Calificaciones)
            {
                suma = suma + item;
            }

            return suma / Calificaciones.Count;
        }
    }
}
