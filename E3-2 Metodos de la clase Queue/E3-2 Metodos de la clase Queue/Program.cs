using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_2_Metodos_de_la_clase_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue cola = new Queue();
            cola.Enqueue("Cesar"); // Agrega un elemento al final de la cola.
            cola.Enqueue("Samantha"); // Agrega un elemento al final de la cola.
            cola.Enqueue("Minecraft"); // Agrega un elemento al final de la cola.
            cola.Enqueue("LoL"); // Agrega un elemento al final de la cola.

            int count = cola.Count; // Se guarda la cantidad de elementos que tiene la cola en una variable de tipo entero "count".
            for(int i = 0; i < count; i++) 
            {
                // Quita el primer elemento de la cola, al mismo tiempo que lo imprime en la consola. 
                Console.WriteLine(cola.Dequeue());
            }
            cola.TrimToSize(); // Elimina los espacios en blanco que quedaron al usar el Dequeue y le da el tamaño por defecto que tenia la cola 
            Console.ReadKey();
        }
    }
}
