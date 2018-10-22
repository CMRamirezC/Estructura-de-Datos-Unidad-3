using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3.__BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Black Jack (juego del 21)"; // el titulo de la consola 
            Operaciones BlackJack = new Operaciones();// se crea un nueo objeto de la clase Operaciones
            bool Condicion = true;
            string Opcion;
            do
            {
                try
                {
                    BlackJack.ComenzarJuego();// llama al metodo principal de la clase "BlackJack" para comenzar el juego
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
