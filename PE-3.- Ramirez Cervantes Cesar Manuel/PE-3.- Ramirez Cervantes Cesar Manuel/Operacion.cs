using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_3.__Ramirez_Cervantes_Cesar_Manuel
{
    class Operacion
    {
        int movimientos = 0;
        int discosTotales = 6;
        int posicion = 4;
        string cursor = "V";
        bool condicion = true;
        Stack<string> TorreOrigen = new Stack<string>();
        Stack<string> TorreAuxiliar = new Stack<string>();
        Stack<string> TorreDestino = new Stack<string>();
        public bool EstadoDePartida()
        {
            if (TorreDestino.Count == discosTotales)
                return false;
            else
                return true;
        }
        public void ImprimirTorres()
        {
            int Count = 7;
            foreach (var item in TorreOrigen)
            {
                Console.SetCursorPosition(0, Count);
                if (item == "###########")
                    Console.WriteLine();
                else
                    Console.Write(item);
                Count = Count + 1;
            }
            Count = 7;
            foreach (var item in TorreAuxiliar)
            {
                Console.SetCursorPosition(24, Count);
                if (item == "###########")
                    Console.WriteLine();
                else
                    Console.Write(item);
                Count = Count + 1;
            }
            Count = 7;
            foreach (var item in TorreDestino)
            {
                Console.SetCursorPosition(44, Count);
                if (item == "###########")
                    Console.WriteLine();
                else
                    Console.Write(item);
                Count = Count + 1;
            }
        }
        public void MostrarCursor(int posicion, string disco)
        {
            Console.SetCursorPosition(posicion, 4);
            Console.Write("_");
            Console.SetCursorPosition(posicion, 5);
            Console.WriteLine(disco);
        }
        public string SeleccionarDisco(int posicion)
        {
            switch (posicion)
            {
                case 4:
                    if (TorreOrigen.Peek().Length > 0 && TorreOrigen.Peek().Length != 11)
                        return TorreOrigen.Pop();
                    else
                        return "V";
                case 24:
                    if (TorreAuxiliar.Peek().Length > 0 && TorreAuxiliar.Peek().Length != 11)
                        return TorreAuxiliar.Pop();
                    else
                        return "V";
                case 44:
                    if (TorreDestino.Peek().Length > 0 && TorreDestino.Peek().Length != 11)
                        return TorreDestino.Pop();
                    else
                        return "V";
                default:
                    return "V";
            }
        }
        public string MoverDisco(int position, string item)
        {
            if (item == "V")
                return "V";
            else
            {
                switch (position)
                {
                    case 4:
                        if (TorreOrigen.Peek().Length > item.Length)
                        {
                            TorreOrigen.Push(item);
                            return "V";
                        }
                        else
                            return item;
                    case 24:
                        if (TorreAuxiliar.Peek().Length > item.Length)
                        {
                            TorreAuxiliar.Push(item);
                            return "V";
                        }
                        else
                            return item;
                    case 44:
                        if (TorreDestino.Peek().Length > item.Length)
                        {
                            TorreDestino.Push(item);
                            return "V";
                        }
                        else
                            return item;
                    default:
                        return "V";
                }
            }
        }
        public void IniciarJuego()
        {
            Console.Title = " >>> Torres De Hanoi <<<";
            TorreAuxiliar.Push("###########");
            TorreDestino.Push("###########");
            TorreOrigen.Push("###########");
            TorreOrigen.Push(" #########");
            TorreOrigen.Push("  #######");
            TorreOrigen.Push("   #####");
            TorreOrigen.Push("    ###");
            TorreOrigen.Push("     #");
            Console.Clear();
            while (condicion == true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(" -> Objetivo: lograr pasar la piramire de discos hasta la 3era torre, con la condicion de que un disco mayor en tamaño\n no pueda colocarse en uno de menor tamaño. <-");
                Console.SetCursorPosition(30, 14);
                Console.Write(" -> Movimientos Actuales: {0} <-", movimientos);
                MostrarCursor(posicion, cursor);
                ImprimirTorres();
                ConsoleKeyInfo Control = Console.ReadKey(true);
                switch (Control.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (posicion > 4)
                            posicion = posicion - 20;
                        break;
                    case ConsoleKey.RightArrow:
                        if (posicion < 44)
                            posicion = posicion + 20;
                        break;
                    case ConsoleKey.Enter:
                        movimientos++;
                        if (cursor == "V")
                            cursor = SeleccionarDisco(posicion);
                        else
                        {
                            string numero = cursor;
                            cursor = MoverDisco(posicion, numero);
                        }
                        break;
                    default:
                        Console.WriteLine(" Error de tecla!!!");
                        break;
                }
                condicion = EstadoDePartida();
                Console.Clear();
            }
            Console.WriteLine(" Completado en {0} movimientos", discosTotales);
        }
    }
}
