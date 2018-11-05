using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1_Vacas_de_Bob
{
    class Program
    {
        static void Main(string[] args)
        {
            bool condicion = true;
            do
            {
                try
                {
                    Operacion op = new Operacion();
                    op.Principal();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.Write(" Deseas reiniciar programa?: ");
                    if (Console.ReadLine().ToUpper() == "NO")
                    {
                        condicion = false;
                    }
                    else
                    {
                        condicion = true;
                        Console.Clear();
                    }
                }
            } while (condicion == true);
        }
    }
}
