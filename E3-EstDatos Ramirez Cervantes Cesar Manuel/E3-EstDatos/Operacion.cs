using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_EstDatos
{
    public class Operacion
    {
        public void Principal()
        {
            Stack Lista = new Stack();
            Queue Cola = new Queue();

            Ejercicio1(Lista);
            Ejercicio2();
            Ejercicio4();
            Console.WriteLine(" Tiempo: ");
            Ejercicio3();
        }

        public void Ejercicio1(Stack lista)
        {
            //¿Qué valores se devuelven durante la siguiente serie de operaciones de pila,
            //si se ejecutan en una pila inicialmente vacía ?
            //push(5), push(3), pop(), push(2), push(8),
            //pop(), pop(), push(9), push(1), pop(), push(7), push(6), pop(), pop(), push(4),
            //pop(), pop()
            Console.WriteLine(" >>> Ejercicio 1 <<<");
            lista.Push(5);
            lista.Push(3);
            lista.Pop();
            lista.Push(2);
            lista.Push(8);
            lista.Pop();
            lista.Pop();
            lista.Push(9);
            lista.Push(1);
            lista.Pop();
            lista.Push(7);
            lista.Push(6);
            lista.Pop();
            lista.Pop();
            lista.Push(4);
            lista.Pop();
            lista.Pop();

            foreach (var item in lista)
            {
                Console.WriteLine(" " + item);
            }
        }

        public void Ejercicio2()
        {
            //Escriba en este metodo un modulo que pueda leer  y almacenar palabras reservadas en una lista enlazada 
            //e identificadores y literales en Otra lista enlazada.
            //Cuando el programa haya terminado de leer la entrada, mostrar
            //Los contenidos de cada lista enlazada.
            //Revise que es un Identificador y que es un literal
            Console.WriteLine(" >>> Ejecicio 2 <<< ");
            string palabra;
            string[] test = {"abstract","enum", "long", "stackalloc", "as", "event","namespace","static","base","explicit","new", "string",
                "bool", "extern",   "null", "struct","break","false","object","switch","byte", "finally",  "operator","this",
                "case", "Fixed",   "out", "throw", "catch",    "float",   "override",  "true",
                "char",    "for",   "params",  "try", "checked",  "foreach",  "private",  "typeof",
                "class",   "goto",  "protected", "uint", "const",   "if",    "public", "ulong",
                "continue", "implicit",    "readonly",  "unchecked", "decimal", "in", "ref", "unsafe",
                "default",  "int",  "return",   "ushort", "delegate",    "interface",   "sbyte",  "using",
                "do",   "internal", "sealed", "virtual", "double",   "is",   "short", "void", "else", "lock","sizeof","while"};
            LinkedList<string> palabrareservada = new LinkedList<string>();
            LinkedList<string> identificador = new LinkedList<string>();
            LinkedList<string> literales = new LinkedList<string>();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Introduce la palabra No.{0}: ", i + 1);
                palabra = Console.ReadLine();
                int valor;
                valor = Convert.ToInt32(palabra[0]);
                if (valor >= 65 && valor <= 122 || palabra[0] == '_')
                {
                    foreach (string item in test)
                    {
                        if (palabra == item)
                        {
                            palabrareservada.AddFirst(item);
                            goto final;
                        }
                    }
                    identificador.AddFirst(palabra);
                    final:
                    Console.Clear();
                }
                else
                {
                    literales.AddFirst(palabra);
                    Console.Clear();
                }
            }
            Console.WriteLine("Identificadores introducidos: ");
            foreach (var r in identificador)
            {
                Console.WriteLine(r);
            }
            Console.ReadKey();
            Console.WriteLine("Literales introducidos: ");
            foreach (var r in literales)
            {
                Console.WriteLine(r);
            }
            Console.ReadKey();
            Console.WriteLine("Palabras Reservadas itroducidas: ");
            foreach (var r in palabrareservada)
            {
                Console.WriteLine(r);
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void Ejercicio3()
        {
            //mida el tiempo entre Un lista ligada y una lista normal en el tiempo de ejecucion de 9876 elementos agregados.
            Console.WriteLine(" >>> Ejecicio 3 <<< ");
            const int total = 9999;
            List<string> Lista = new List<string>();
            LinkedList<string> Listaligada = new LinkedList<string>();
            for (int i = 0; i < 8979; i++)
            {
                Lista.Add("*");
                Listaligada.AddLast("#");
            }
            var t1 = Stopwatch.StartNew();
            for (int i = 0; i < total; i++)
            {
                foreach (string item in Lista)
                {
                    if (item.Length != 5)
                    {
                        throw new Exception();
                    }
                }
            }
            t1.Stop();
            var t2 = Stopwatch.StartNew();
            for (int i = 0; i < total; i++)
            {
                foreach (string item in Listaligada)
                {
                    if (item.Length != 5)
                    {
                        throw new Exception();
                    }
                }
            }
            t2.Stop();

            Console.WriteLine("Lista: " + ((double)(t1.Elapsed.TotalMilliseconds * 1000000) / total).ToString("0.00 ns"));
            Console.WriteLine("Lista ligada: " + ((double)(t2.Elapsed.TotalMilliseconds * 1000000) / total).ToString("0.00 ns"));
        }

        public void Ejercicio4()
        {
            // Diseñar e implementar una clase que le permita a un maestro hacer un seguimiento de las calificaciones
            // en un solo curso.Incluir métodos que calculen la nota media, la
            //calificacion más alto, y el calificacion más bajo. Escribe un programa para poner a prueba tu clase.
            //implementación. Minimo 30 Calificaciones, de 30 alumnos.
            Console.WriteLine(" >>> Ejecercicio 4 <<< ");
            Clase curso = new Clase();
            curso.NombreClase = " CLASE:Estructura de Datos";
            curso.Maestro = " JUAN";
            Stack Alumnos = new Stack();
            Stack<int> Calificaciones = new  Stack<int>();
            Console.WriteLine(curso.NombreClase);         
            Console.WriteLine(curso.Maestro);          
            Console.Write(" Numero de alumnos: ");
            int num = int.Parse(Console.ReadLine());
            for(int i = 0; i < num; i++)
            {
                Console.Write(" Nombre del alumno {0}: ", i + 1);
                Alumnos.Push(Console.ReadLine());

                Console.Write(" Calificacion del alumno {0}: ", i + 1);
                Calificaciones.Push(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(" El promedio es: {0}",curso.Promedio(Calificaciones));
            Console.WriteLine(" El mayor es: {0}", Calificaciones.Max());
            Console.WriteLine(" El menor es: {0}", Calificaciones.Min());
        }
    }
}
