using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3.__BlackJack
{
    class Operaciones
    {
        internal void ComenzarJuego()
        {
            List<Carta> Cartas = IniciarCartas(); // Lista de Cartas 
            Queue<Carta> CartasDelJugador = RepartirCartas(Cartas); // Cola para juargar las cartas que se le daran al jugador, asi mismo llamando el metodo para revolver y repartir dichas cartas
            int suma = 0;
            bool AS = false;
            for (int i = 0; i < 2; i++) // for para imprimir las cartas del jugador y calcular la suma de sus puntos 
            {
                Console.WriteLine(CartasDelJugador.Peek().Numero + " de " + CartasDelJugador.Peek().Figura);
                if(CartasDelJugador.Peek().Numero == "AS") // si la carta es un as:
                {
                    AS = true; //retorna un true 
                }
                else
                {
                    AS = false; //retorna un false
                }
                suma = suma + CartasDelJugador.Peek().Valor; // calcula la suma de los puntos de las cartas
                CartasDelJugador.Dequeue();
            }
            if(AS == true)//si es true que la carta es un as:
            {
                Console.Write(" Tienes un As, deseas que su valor sea 1 0 11?: ");//pregunta si desea que el as tenga el valor de 1 0 11
                suma = suma + int.Parse(Console.ReadLine());//se suma el nuevo valor del as
            }
            while(suma < 21)
            {
                Random random = new Random();
                Console.Write(" Deseas tomar otra carta?: "); // pregunta si desea otra carta si tiene menos de 21 puntos
                string opcion = Console.ReadLine();
                switch (opcion.ToUpper())
                {
                    case "SI":// si la respuesta es si:
                        Carta nuevaCarta = Cartas[random.Next(0, Cartas.Count - 1)]; // se crea una nueva carta obtenida desde la lista de cartas en una posicion random
                        Console.WriteLine(" Tu nueva carta es {0} de {1}", nuevaCarta.Numero, nuevaCarta.Figura); // imprime la carta
                        if(nuevaCarta.Numero == "AS") // si la nueva carta es un as:
                        {
                            Console.Write(" Tienes un As, deseas que su valor sea 1 0 11?: ");
                            suma = suma + int.Parse(Console.ReadLine());//suma el nuevo valor del as 
                        }
                        suma = suma + nuevaCarta.Valor;//suma el valor de la nueva carta
                        break;
                    case "NO"://si la respuesta es no:
                        suma = 22;//hace que la suma sea mayor a 21 para asi se tome como partida perdida
                        break;
                }
            }
            if (suma > 21) // si la suma es mayor a 21
            {
                Console.WriteLine(" Has perdido la partida!"); // se pierde la partida
            }
            else if (suma == 21) // si la suma es igual a 21
            {
                Console.WriteLine(" Has ganado la partida!");// se gana la partida
            }
        }
        private Queue<Carta> RepartirCartas(List<Carta> cartas) // metodo para revolver y repartir las cartas al jugador
        {
            List<Carta> NoRevueltas = cartas; //se crea una nueva lista de las cartas que no esta revuelta
            Queue<Carta> CartasRevueltas = new Queue<Carta>(); // se crea la cola donde estaran las 2 cartas del jugador ya revueltas
            Random Num = new Random();
            for (int i = 0; i < 2; i++)
            {
                int Posicion = Num.Next(0, NoRevueltas.Count - 1);
                CartasRevueltas.Enqueue(NoRevueltas[Posicion]);//se agrega una carta a la cola de la lista de cartas de una posicion random
                NoRevueltas.RemoveAt(Posicion);// remueve la carta que se uso de la lista de cartas
            }
            return CartasRevueltas;//retorna la cola con las cartas revueltas
        }
        private List<Carta> IniciarCartas()//metodo para la creacion de las 52 cartas
        {
            List<Carta> Cartas = new List<Carta>();//se crea la lista de cartas

            for(int i = 1; i < 14; i++)//desde 1 hasta 14: 
            {
                Carta Corazon = new Carta();// se crea una carta de corazones
                Carta Espadas = new Carta();// se crea una carta de espadas
                Carta Rombos = new Carta();// se crea una carta de rombos 
                Carta Tréboles = new Carta();// se crea una carta de treboles
                switch(i)//switch para los casos en que i sea 1,11,12,13 para darles su respectiva letra
                {
                    case 1:
                        Corazon.Numero = "AS";// se le asigna al numero de la carta "AS"
                        Espadas.Numero = "AS";// se le asigna al numero de la carta "AS"
                        Rombos.Numero = "AS";// se le asigna al numero de la carta "AS"
                        Tréboles.Numero = "AS";// se le asigna al numero de la carta "AS"
                        break;
                    case 11:
                        Corazon.Numero = "J";// se le asigna al numero de la carta "J"
                        Corazon.Valor = i; // se le asigna el valor a la carta 
                        Espadas.Numero = "J";// se le asigna al numero de la carta "J"
                        Espadas.Valor = i;// se le asigna el valor a la carta 
                        Rombos.Numero = "J";// se le asigna al numero de la carta "J"
                        Rombos.Valor = i;// se le asigna el valor a la carta 
                        Tréboles.Numero = "J";// se le asigna al numero de la carta "J"
                        Tréboles.Valor = i;// se le asigna el valor a la carta 
                        break;
                    case 12:
                        Corazon.Numero = "Q";// se le asigna al numero de la carta "Q"
                        Corazon.Valor = i;// se le asigna el valor a la carta 
                        Espadas.Numero = "Q";// se le asigna al numero de la carta "Q"
                        Espadas.Valor = i;// se le asigna el valor a la carta 
                        Rombos.Numero = "Q";// se le asigna al numero de la carta "Q"
                        Rombos.Valor = i;// se le asigna el valor a la carta 
                        Tréboles.Numero = "Q";// se le asigna al numero de la carta "Q"
                        Tréboles.Valor = i;// se le asigna el valor a la carta 
                        break;
                    case 13:
                        Corazon.Numero = "K";// se le asigna al numero de la carta "K"
                        Corazon.Valor = i;// se le asigna el valor a la carta 
                        Espadas.Numero = "K";// se le asigna al numero de la carta "K"
                        Espadas.Valor = i;// se le asigna el valor a la carta 
                        Rombos.Numero = "K";// se le asigna al numero de la carta "K"
                        Rombos.Valor = i;// se le asigna el valor a la carta 
                        Tréboles.Numero = "K";// se le asigna al numero de la carta "K"
                        Tréboles.Valor = i;// se le asigna el valor a la carta 
                        break;
                    default:
                        Corazon.Numero = i.ToString();// se le asigna al numero de la carta
                        Corazon.Valor = i;// se le asigna el valor a la carta 
                        Espadas.Numero = i.ToString();// se le asigna al numero de la carta
                        Espadas.Valor = i;// se le asigna el valor a la carta 
                        Rombos.Numero = i.ToString();// se le asigna al numero de la carta
                        Rombos.Valor = i;// se le asigna el valor a la carta 
                        Tréboles.Numero = i.ToString();// se le asigna al numero de la carta
                        Tréboles.Valor = i;// se le asigna el valor a la carta 
                        break;
                }
                Corazon.Figura = "Corazones";// se le asigna la figura de la carta
                Espadas.Figura = "Espadas";// se le asigna la figura de la carta
                Rombos.Figura = "Rombos";// se le asigna la figura de la carta
                Tréboles.Figura = "Tréboles";// se le asigna la figura de la carta
                Cartas.Add(Corazon);// se agrega la carta de la figura corazon a la lista
                Cartas.Add(Espadas);// se agrega la carta de la figura espadas a la lista
                Cartas.Add(Rombos);// se agrega la carta de la figura rombos a la lista
                Cartas.Add(Tréboles);// se agrega la carta de la figura treboles a la lista
            }
            return Cartas;
        }
    }
}
