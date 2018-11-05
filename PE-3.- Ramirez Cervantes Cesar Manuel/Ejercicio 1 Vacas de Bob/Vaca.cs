using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1_Vacas_de_Bob
{
    class Vaca
    {
        string nombre;
        int tiempo;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
        public Vaca() { }
        public Vaca(string n, int t)
        {
            nombre = n;
            tiempo = t;
        }
    }
}
