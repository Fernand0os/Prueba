using System;

namespace TicTacToe
{
    class Program
    {
        //Creamos un arreglo bidimensional para el tablero del juego
        static int[,] tablero = new int[3, 3]; // 3 filas, 3 columnas
        //Creamos un arreglo para los simbolos del tablero: Espacio en blanco, jug.1, jug.2
        static char[] simbolo = { ' ', 'O', 'X' };

        static void Main(string[] args)
        {
            bool terminado = false;

            //Dibujar el tablero inicial
            DibujarTablero();
            Console.WriteLine(" Jugador 1 = O\n Jugador 2 = X");

            do /*Usamos el ciclo do-while porque desconocemos el numero de veces que se tiene que llevar a cabo*/
            {
                // Le va a dar el turno al jugador 1
                PreguntarPosicion(1); // Envia el valor de 1 a la funcion de PreguntaPosicion

                //Dibujar la casilla que escogio el jugador 1
                DibujarTablero();

                // Comprobamossi ha ganado el jugador 1
                terminado = ComprobarGanador();

                if (terminado == true)
                {
                    Console.WriteLine("El jugador 1 ha ganado!");
                }
                else // Comprobamos si hubo un empate
                {
                    terminado = ComprobarEmpate();
                    if(terminado == true)
                    {
                        Console.WriteLine("Esto es un empate!");
                    }

                    // Si jugador un no gano pero tampoco hubo un empate, entonces es turno del jugador 2
                    else
                    {
                        // Turno del jugador 2
                        PreguntarPosicion(2);

                        //Dibjar la casilla del jugador numero 2
                        DibujarTablero();

                        //Comprobamos si ha ganado la partida el jugador 2
                        terminado = ComprobarGanador();

                        if (terminado == true)
                        {
                            Console.WriteLine("El jugador 2 ha ganado!");
                        }
                    }
                }

            } while (terminado == false);

        }

        static void DibujarTablero()
        {
            //Variables del conteo del ciclo
            int fila = 0;
            int columna = 0;

            Console.WriteLine(); // Espacio antes de dibujar el tablero
            Console.WriteLine("-------------"); // Dibujar la primera linea horizontal
            for(fila = 0; fila < 3; fila++)
            {
                Console.Write("|"); // Se va a encargar de dibujar la segunda linea horizontal
                for (columna = 0; columna < 3; columna++)
                {
                    // Se asigna un espacio, un circulo o un espacio segun corresponda
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------"); // Dibujar la primera linea horizontal
            }
        }

        // Va a preguntar donde escribir y lo dibuja en el tablero
        static void PreguntarPosicion(int jugador)// 1 = Jugador 1 ; 2 = jugador 2
        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}", jugador);
                //Pedimos el numero de fila
                do
                {
                    Console.Write("Selecciona la fila: ");
                    fila = Convert.ToInt32(Console.ReadLine());
                } while ((fila < 1) || (fila > 3));

                // Pedimos el numero de columna
                do
                {
                    Console.Write("Selecciona la columna: ");
                    columna = Convert.ToInt32(Console.ReadLine());
                } while ((columna < 1) || (columna > 3));

                if (tablero[fila - 1, columna - 1] != 0)
                    Console.WriteLine("Casilla ocupada!");

            } while(tablero[fila - 1, columna - 1] != 0);

            // Si todo es correcto se le asigna al jugador correspondiente
            tablero[fila - 1, columna - 1] = jugador;
        }

        // Este metodo nos devolvera True si hay 3 en linea
        static bool ComprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool ticTacToe = false;


            // Si en alguna fila todas las casillas son iguales y no estan vacias TicTacToe = True
            for(fila = 0; fila < 3; fila++)
            {
                if ((tablero[fila, 0] == tablero[fila, 1]) &&
                    (tablero[fila, 0] == tablero[fila, 2]) &&
                    (tablero[fila, 0] != 0))

                {
                    ticTacToe = true;
                }
            }
            
            // Si alguna columna tiene toas las casillas son iguales y no estan vacias
            for (columna = 0; columna < 3; columna++)
            {
                if ((tablero[0, columna] == tablero[1, columna]) &&
                    (tablero[0, columna] == tablero[2, columna]) &&
                    (tablero[0, columna] != 0))
                {
                    ticTacToe = true;
                }
            }

            //Si en alguna diagonal todas las casillas son iguales y no estan vacias
            if ((tablero[0, 0] == tablero[1, 1]) &&
                (tablero[0, 0] == tablero[2, 2]) &&
                (tablero[0, 0] != 0))
            {
                ticTacToe = true;
            }
            return ticTacToe;
        }

        //Comprobamos si hay un empate = True
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for(fila = 0; fila < 3; fila++)
            {
                for(columna = 0; columna < 3; columna++)
                {
                    if(tablero[fila,columna] == 0) // Si encuentra una sola casilla vacia, quiere decir que aun se puede seguir jugando
                    {
                        hayEspacio = true;
                    }
                }
            }
            return !hayEspacio; /* Si el ciclo anterior nos regresa un 'true', 
                                 * indicandonos que si hay espacios, entonces 
                                 * se tiene que regresar una negacion de true 
                                 * para que la condicion de empate no se cumpla 
                                 * en la funcion de Main*/
        }

    }
}
