using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_3.__Ramirez_Cervantes_Cesar_Manuel
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Condicion = true;
            string Opcion;
            do
            {
                try
                {
                    Operacion Op = new Operacion();
                    Op.IniciarJuego();
                    Console.Write(" Desea reiniciar el programa? (Si/No): ");
                    Opcion = Console.ReadLine();
                    switch (Opcion.ToUpper())
                    {
                        case "SI":
                            Condicion = true;
                            Console.WriteLine(" Reiniciando programa, presione cualquier recla para continuar... ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "NO":
                            Condicion = false;
                            Console.WriteLine(" Cerrando programa... ");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine(" Opcion incorrecta!, se reiniciara el programa... ");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (Condicion == true);
        }
    }
}
