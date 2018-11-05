using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1_Vacas_de_Bob
{
    class Operacion
    {
        int seleccion;
        public bool activo { get; set; }
        int tiempoTotal;
        Vaca Mazie = new Vaca("Mazie", 2); // Creacion de las cuatro vacas con su nombre y tiempo en cruzar el puente 
        Vaca Daisy = new Vaca("Daisy", 4);
        Vaca Crazy = new Vaca("Crazy", 10);
        Vaca Lazy = new Vaca("Lazy", 20);
        List<Vaca> Vacas = new List<Vaca>(); // Lista donde se guardaran las vacas que iran cruzando el puente y quitando las que no
        public Operacion()
        {
            tiempoTotal = 0;
            activo = true;
            Vacas.Add(Mazie); // se agregan las vacas a la lista
            Vacas.Add(Daisy);
            Vacas.Add(Crazy);
            Vacas.Add(Lazy);
        }
        private void QuitarVaca(Vaca vaca)
        {
            Vacas.Remove(vaca);// metodo para quitar la vaca de la lista 
        }
        private void ImprimirVacas() // metodo para imprimir la lista con las vacas que se encuentran en ella 
        {
            int count = 0;
            foreach (Vaca vacasPasan in Vacas)
            {
                count++;
                Console.WriteLine("{0} {1} tiempo de cruze: {2} minutos", count, vacasPasan.Nombre, vacasPasan.Tiempo);
            }
        }
        private int VacaSola(Vaca vaca) //metodo para regresar el tiempo que hace una sola vaca en cruzar el puente
        {
            return vaca.Tiempo;
        }
        private int DosVacas(Vaca vaca1, Vaca vaca2)// metodo para calcular y regresar el tiempo que hacen dos vacas en cruzar el puente (regresa el tiempo mayor)
        {
            if (vaca1.Tiempo > vaca2.Tiempo)
            {
                return vaca1.Tiempo;
            }
            else
            {
                return vaca2.Tiempo;
            }
        }
        public void Principal()
        {
            Console.WriteLine(" Bob debe cruzar sus vacas atraves del puente en 34 minutos");
            Console.WriteLine(" Tiempo transcurrido {0} minutos", tiempoTotal);
            Console.WriteLine(" Vacas restantes por cruzar");
            ImprimirVacas();
            if (Vacas.Count == 1) // si solo se encuentra una vaca en la lista
            {
                seleccion = 1;// se toma como que solo se cruzara una vaca
            }
            else // si no, se preguntara cuantas vacas desea cruzar (1 o 2)
            {
                Console.WriteLine(" Deseas cruzar 1 o 2 vacas por el puente?: "); 
                seleccion = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            switch (seleccion)
            {
                case 1:
                    Console.WriteLine(" Cual vaca deseas cruzar? introduce el numero a su izquierda");
                    ImprimirVacas(); // se imprimen las vacas
                    seleccion = int.Parse(Console.ReadLine());
                    if (seleccion > Vacas.Count || seleccion < 1) // si la seleccion es mayor al numero de vacas en la lista o la seleccion es menor a 1
                    {
                        Console.WriteLine(" Error de seleccion"); // se manda un error
                        break;
                    }
                    tiempoTotal = tiempoTotal + VacaSola(Vacas[seleccion - 1]); // se calcula el tiempo sumandole el tiempo que hace la vaca sola 
                    Console.WriteLine(" La vaca {0} ha cruzado el puente", Vacas[seleccion - 1].Nombre);
                    Vacas.Remove(Vacas[seleccion - 1]); // se elimina la vaca que ha cruzado 
                    break;
                case 2:
                    Console.WriteLine(" Que vaca deseas cruzar? introduce el numero a su izquierda");
                    ImprimirVacas();
                    seleccion = int.Parse(Console.ReadLine());
                    if (seleccion > Vacas.Count || seleccion < 1)// si la seleccion es mayor al numero de vacas en la lista o la seleccion es menor a 1 
                    {
                        Console.WriteLine(" Error de seleccion");// manda error 
                        break;
                    }
                    Console.Clear();
                    Vaca vaca1 = Vacas[seleccion - 1]; // se crea una nueva vaca que se encuentra en la posicion seleccionada por el usuario en la lista 
                    Vacas.Remove(Vacas[seleccion - 1]);// se elimina la vaca que se selecciono de la lista 
                    Console.WriteLine(" Selecciona la vaca que ira con la vaca actual");
                    ImprimirVacas();
                    seleccion = int.Parse(Console.ReadLine());
                    if (seleccion > Vacas.Count || seleccion < 1)// si la seleccion es mayor l numero de vacas en la lista o es menor a 1 
                    {
                        Vacas.Add(vaca1);// se acrega la vaca a la lista 
                        Console.WriteLine(" Error de seleccion");// manda error
                        break;
                    }
                    tiempoTotal = tiempoTotal + DosVacas(vaca1, Vacas[seleccion - 1]); // calcula el tiempo que suman las dos vacas que cruzaron
                    Console.WriteLine(" Las vacas {0} y {1} han cruzado el puente", Vacas[seleccion - 1].Nombre, vaca1.Nombre);
                    Vacas.Remove(Vacas[seleccion - 1]);// remueve las vacas de la lista 
                    break;
                default:
                    Console.WriteLine(" Indice introducido incorrecto");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            if (Vacas.Count == 0)// si ya no hay ninguna vaca en espera para cruzar 
            {
                Console.WriteLine(" has terminado de cruzar las 4 vacas tu tiempo fue de {0} minutos", tiempoTotal);// imprime el tiempo total que hicieron
                if (tiempoTotal == 34)// si el tiempo fue de 34 minutos
                {
                    Console.WriteLine(" Felicidades lograste cruzar en 34 minutos");//manda mensade de que cumplio el objetivo
                }
                else// si no
                {
                    Console.WriteLine(" No curzaste en excactamente 34 intenta de nuevo");// manda mensaje de que no fue completado el objetivo 
                }
                activo = false;
            }
        }
    }
}
