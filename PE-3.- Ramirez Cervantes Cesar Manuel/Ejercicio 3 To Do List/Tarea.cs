using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3_To_Do_List
{
    public class Tarea
    {
        public int ID
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public string Descripcion
        {
            get; set;
        }
        public DateTime FechaInicial
        {
            get; set;
        }
        public DateTime FechaFinal
        {
            get; set; 
        }
    }
}
