using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio_3_To_Do_List
{
    class Operacion
    {
        Tarea tarea;
        List<Tarea> Pendientes = new List<Tarea>();// se crea listas para las tareas pendientes, en proceso y las terminadas
        List<Tarea> EnProceso = new List<Tarea>();
        List<Tarea> Terminadas = new List<Tarea>();
        public void Principal()
        {
            bool Condicion = true;
            string Opcion;
            do
            {
                try
                {
                    Console.Title = " >>> To Do List <<< ";
                    Console.WriteLine("\n 1.- Ver Tareas      2.- Agreagar Tarea ");
                    Console.Write("----------------------------------------");
                    switch(Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            VerTareas();
                            Console.Write("\n Que seccion de tareas desea revisar? (1.-Pendientes  2.-En Proceso  3.-Terminadas): ");//pide al usuario que seleccione que tareas desea ver 
                            switch(Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    VerPendiente();
                                    break;
                                case ConsoleKey.D2:
                                    VerEnProceso();
                                    break;
                                case ConsoleKey.D3:
                                    VerTerminada();
                                    break;
                                default:
                                    Console.WriteLine("\n Error de tecla presionada!!! ");
                                    break;
                            }
                            break;
                        case ConsoleKey.D2:
                            AgregarTarea();
                            break;
                        default:
                            Console.WriteLine("\n Error de tecla presionada!!! ");
                            break;
                    }
                    Console.Write("\n Desea volver al menu? (Si/No): ");
                    Opcion = Console.ReadLine();
                    switch (Opcion.ToUpper())
                    {
                        case "SI":
                            Condicion = true;
                            Console.WriteLine("\n Regresando al menu, presione cualquier recla para continuar... ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "NO":
                            Condicion = false;
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("\n Opcion incorrecta!, se reiniciara el programa... ");
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
        public void VerTareas()// metodo para imprimir las listas de las tareas (pendientes, en proceso y las terminadas)
        {
            Console.WriteLine("\n ->Tareas Pendientes<- ");
            int Count = 1;
            foreach (var item in Pendientes)
            {
                Console.WriteLine(" {0}.- " + item.Nombre, Count);
                Count = Count + 1;
            }
            Console.WriteLine("\n ->Tareas en Proceso<- ");
            Count = 1;
            foreach (var item in EnProceso)
            {
                Console.WriteLine(" {0}.- " + item.Nombre, Count);
                Count = Count + 1;
            }
            Console.WriteLine("\n ->Tareas Terminadas<- ");
            Count = 1;
            foreach (var item in Terminadas)
            {
                Console.WriteLine(" {0}.- " + item.Nombre, Count);
                Count = Count + 1;
            }
        }
        public void AgregarTarea()// metodo para agregar una tarea a su respectiva lista
        {
            Console.Clear();
            int Count = 1;
            tarea = new Tarea();
            tarea.ID = Count;
            Console.Write("\n Escribe el nombre de la tarea: ");
            tarea.Nombre = Console.ReadLine();
            Console.WriteLine(" Descripcion: ");
            tarea.Descripcion = Console.ReadLine();
            tarea.FechaInicial = DateTime.Now;
            Console.Write(" Define la fecha limite para esta tarea (MM/DD/AAAA): ");
            tarea.FechaFinal = Convert.ToDateTime(Console.ReadLine());
            Console.Write(" Cual es el estado de la tarea? (proceso / terminada): ");
            string estado = Console.ReadLine();
            if(estado.ToUpper() == "PROCESO")//si el usuario ingresa como en proceso la tarea
            {
                EnProceso.Add(tarea);//se agrega la tarea creada en la lista de tareas en proceso 
            }
            else if(estado.ToUpper() == "TERMINADA")// si ingresa que esta terminada 
            {
                Terminadas.Add(tarea);// agrega la tarea creada en la lista de tareas terminadas
            }
            else
            {
                Pendientes.Add(tarea);// si ninguna de las dos se cumple entonces se tomara la tarea creada como pendiente y se agrega en dicha lista 
            }
            Count = Count + 1;
        }
        public void VerPendiente()//metodo para ver una tarea en especifico de la lista de pendientes
        {
            Console.Clear();
            int Count = 1;
            if(Pendientes.Count == 0)// si la lista de pendientes esta vacia 
            {
                Console.WriteLine("\n No tienes ninguna tarea pendiente! ");// muestra mensaje de que aun no ha agregado una tarea pendiente
            }
            else// si no se cumple 
            {
                foreach (var item in Pendientes) // imprime las tareas pendientes
                {
                    Console.WriteLine(" {0}.- " + item.Nombre, Count);
                    Count = Count + 1;
                }
                Console.WriteLine("\n Que numero de tarea desea ver?: ");// pregunta que tarea desea revisar
                int num = int.Parse(Console.ReadLine());
                var tareaSeleccionada = (from t in Pendientes  //busca la tarea con el id que el usuario selecciono
                                         where t.ID == num
                                         select t);
                foreach (var item in tareaSeleccionada) // de la tarea que encontro con el id que solicito el usuario imprime su nombre, estado y la descripcion 
                {
                    Console.WriteLine(item.Nombre);
                    Console.WriteLine("\n Estado: PENDIENTE ");
                    Console.WriteLine("\n Descripcion: \n" + item.Descripcion);
                }
            }
        }
        public void VerEnProceso()//metodo para ver una tarea en especifico de la lista en proceso
        {
            Console.Clear();
            int Count = 1;
            if (EnProceso.Count == 0)
            {
                Console.WriteLine("\n No tienes ninguna tarea en proceso! ");
            }
            else
            {
                foreach (var item in EnProceso)
                {
                    Console.WriteLine(" {0}.- " + item.Nombre, Count);
                    Count = Count + 1;
                }
                Console.WriteLine("\n Que numero de tarea desea ver?: ");
                int num = int.Parse(Console.ReadLine());
                var tareaSeleccionada = (from t in EnProceso
                                         where t.ID == num
                                         select t);
                foreach (var item in tareaSeleccionada)
                {
                    Console.WriteLine(item.Nombre);
                    Console.WriteLine("\n Estado: EN PROCESO ");
                    Console.WriteLine("\n Descripcion: \n" + item.Descripcion);
                }
            }
        }
        public void VerTerminada()//metodo para ver una tarea en especifico de la lista de terminadas
        {
            Console.Clear();
            int Count = 1;
            if (Terminadas.Count == 0)
            {
                Console.WriteLine(" No tienes ninguna tarea terminada! ");
            }
            else
            {
                foreach (var item in Terminadas)
                {
                    Console.WriteLine(" {0}.- " + item.Nombre, Count);
                    Count = Count + 1;
                }
                Console.WriteLine(" Que numero de tarea desea ver?: ");
                int num = int.Parse(Console.ReadLine());
                var tareaSeleccionada = (from t in Terminadas
                                         where t.ID == num
                                         select t);
                foreach (var item in tareaSeleccionada)
                {
                    Console.WriteLine(item.Nombre);
                    Console.WriteLine(" Descripcion: \n" + item.Descripcion);
                    Console.WriteLine("\n TAREA PENDIENTE ");
                }
            }
        }
    }
}
