using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.C.__Ramirez_Cervantes_Cesar_Manuel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = " EC3-1.- Metodos de la clase Stack ";
            Stack <object> Pila = new Stack <object>();

            Pila.Push(12345);// se agrega el numero a la pila 
            Pila.Push(100);// se agrega el numero a la pila
            Pila.Push(57);// se agrega el numero a la pila
            Pila.Push(12);// se agrega el nuemro a la pila

            Console.WriteLine(" Elementos que fueron agregados a la pila: ");
            foreach(var item in Pila)// por cada elemento en la pila:
            {
                Console.WriteLine(" " + item);// se imprimira el elemento
            }

            // Contains
            Console.WriteLine();
            Console.WriteLine(" Contains, verificar si la pila contiene el numero 57: ");
            if(Pila.Contains(57) == true)// verifica si la pila contiene el numero 57, si lo contiene:
            {
                Console.WriteLine(" el numero 57 si se encuentra en la pila!! ");// imprimira el mensaje de que si lo encontro en la pila
            }
            else// si no lo contiene:
            {
                Console.WriteLine(" el numero 57 no se encuentra en la pila!! ");// imprime el mensaje de que no lo encontro
            }
            Console.WriteLine();

            // GetType
            Console.WriteLine(" GetType (Tipo): ");
            Console.WriteLine(" " + Pila.GetType().BaseType);// imprime el tipo de dato de los elementos que contiene la pila
            Console.WriteLine();

            // To String
            Console.WriteLine(" To String, elementos de la pila a string: ");
            foreach(var item in Pila)// por cada elemento en la pila:
            {
                Console.WriteLine(" " + item.ToString());// imprime el elemento convertido a tipo string
            }
            Console.WriteLine();

            // To Array
            Console.WriteLine(" To Array, elementos de la pila agregados a un arreglo: ");
            object [] numeros = new object[Pila.Count];// se crea un arreglo de tipo object 
            numeros = Pila.ToArray();// guarda los elementos de la pila en modo arreglo a el arreglo "numeros"
            foreach(int num in numeros)// por cada elemento del tipo entero en el arreglo "numeros":
            {
                Console.Write(" " + num);// imprime el elemento(numero)
            }
            Console.WriteLine();

            // GetEnumerator
            Console.WriteLine();
            Console.WriteLine(" GetEnumerator (Enumerador): ");
            Console.WriteLine(Pila.GetEnumerator());// no entendi para que lo podia usar o como usarlo
        }
    }
}
