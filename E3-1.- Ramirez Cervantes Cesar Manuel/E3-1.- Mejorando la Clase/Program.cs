using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_1.__Mejorando_la_Clase
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
                    Console.Title = " E3-1.- Clases de la Universidad ";
                    ArrayList Clases = new ArrayList(); // Se crea un arreglo de listas para guardar las clases 
                    int noClases; // variable tipo entero para guardar el numero de clases que ingresara el usuario 
                    string nombreClase; // variable tipo string para guardar el nombre de la clase (materia)
                    int noAlumnos; // variable tipo entero para el numero de alumnos que tendra cada clase
                    string nombreAlumno; // variable de tipo string para guardar el nombre de cada alumno 
                    int calificacion; // variable de tipo entero para guardar la calificacion de cada alumno 
                    Console.WriteLine(" Bienvenido Alumno o Maestro del Instituto Tecnologico de Tijuana ");
                    Console.Write(" Introduce cuantas materias son las que usted desea agregar: ");// pide el numero de clases que se agregaran 
                    noClases = int.Parse(Console.ReadLine());// convierte a tipo entero y guarda el numero de clases en la variable int noClases
                    for(int i = 0; i < noClases; i++) // ciclo for de 0 a  menor al numero de clases aumentando en 1 que pedira:
                    {
                        Console.WriteLine("\n Introduce los siguentes datos de la clase {0}", i + 1); 
                        Console.Write(" Nombre: "); // pide el nombre de la clase
                        nombreClase = Console.ReadLine(); // guarda el nombre de la clase en la variable string nombreClase
                        Console.Write(" Numero de alumnos: ");// pide el numero de alumnos que tiene la clase 
                        noAlumnos = int.Parse(Console.ReadLine());// convierte a tipo entero y guarda el numero de alumnos en la variable int noAlumnos
                        Clases.Add(nombreClase + " numero de alumnos: " + noAlumnos);// Agrega al arreglo de lista el nombre de la clase mas el numero de alumnos en una misma linea de texto 
                        for (int j = 0; j < noAlumnos; j++)// ciclo for desde 0 a menor al numero de alumnos aumentando en 1 que pedira: 
                        {
                            Console.Write("\n Nombre completo del alumno {0}: ",j + 1);// pide el nombre completo del alumno
                            nombreAlumno = Console.ReadLine();// guarda el nombre del alumno en la variable nombreAlumno
                            Console.Write(" Calificacion: ");// pide la calificacion del alumno
                            calificacion = int.Parse(Console.ReadLine());// convierte a tipo entero y guarda la calificacion del alumno en la variable int calificacion
                            if(calificacion > 0 && calificacion < 70)// condicion: si la calificacion es mayor a 0 y menor a 70 hara:
                            {
                                Clases.Add(nombreAlumno + ": no aprobado ");// agregara al arreglo de lista el nombre del alumno mas el texto de que no aprobo
                            }
                            else if(calificacion >= 70 && calificacion <= 100)// de no cumplirse lo anterior, si la calificacion es mayor o igual a 70 y si la calificacion es menor o igual a 100 hara:
                            {
                                Clases.Add(nombreAlumno + ": con calificacion de " + calificacion);// agregara al arreglo de lista el nombre del alumno mas la calificacion 
                            }
                        }
                        Console.Clear();// cada vez que se termine el primer ciclo se limpiara la consola
                    }
                    foreach(var item in Clases)// por cada item de cualquier tipo en el arreglo de lista hara:
                    {
                        Console.WriteLine(item);// imprime el item es decir cada elemento que contenga el arreglo de lista
                    }
                    Console.ReadKey();
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
