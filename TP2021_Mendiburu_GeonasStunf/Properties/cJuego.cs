﻿using System;
using System.Collections.Generic;
using System.Text;


namespace TP2021_Mendiburu_GeonasStunf
{

    public class cJuego
    {
        public int cant_tableros_a_generar;//a hacer
        public int cant_tab_generados;//ya hechos
        public cTablero matriz_alfil;
        public Amenazas casillas_amenazadas;
        public cTablero pos_piezas;
        public Amenazas cant_amenazasxCasillas;
        public cTablero[] matrizFatales;
        public Pieza[,] Tableros;
        int libertad_alfil6;
        int libertad_alfil7;
        //int[,] cuartoTablero=new int[4,4];
  
        public Pieza[] arrayPiezas;
        public void GenerarTableros()
        {
            cant_tab_generados = 0;//ponco mi cantidad de tableros generados en 0
                                   //hago el while

            while (cant_tab_generados < cant_tableros_a_generar)//-> necesito completar n tableros
            {
                libertad_alfil6 = 0;
                libertad_alfil7 = 0;

                pos_piezas.InicializarMatrizEn0();//nuevo tablero, nuevas matrices
                casillas_amenazadas.InicializarMatrizEn0();
                cant_amenazasxCasillas.InicializarMatrizEn0();

                //torre 1
                arrayPiezas[2].pos.EleccionAlAzar();//elijo la posición de mi torre al azar.
                casillas_amenazadas.AmenazasMovimientoTorre(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[2]);//marco las amenazas
                pos_piezas.tablero[arrayPiezas[2].pos.fila, arrayPiezas[2].pos.columna] = ((int)arrayPiezas[2].tipoPieza);//marco la posicion en la matriz de posiciones

                //torre 2
                cPosicion aux = new cPosicion();//creo una posicion auxiliar que uso para inicializar valores
                //aux = arrayPiezas[2].pos;//le cambie pq sino nunca entraba al while
                aux.fila = (int)arrayPiezas[2].pos.fila;
                aux.columna = (int)arrayPiezas[2].pos.columna;

                while (casillas_amenazadas.tablero[aux.fila, aux.columna] != 0 || aux.fila == arrayPiezas[2].pos.fila || arrayPiezas[2].pos.columna == aux.columna)
                {
                    aux.EleccionAlAzar();//selecciono una posicion hasta que cumpla con los criterios que necesito

                }
                arrayPiezas[3].pos.fila = (int)aux.fila;//igualo a esa posicion encontrada
                arrayPiezas[3].pos.columna = (int)aux.columna;//igualo a esa posicion encontrada

                pos_piezas.tablero[aux.fila, aux.columna] = 5;//torre2
                casillas_amenazadas.AmenazasMovimientoTorre(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[3]);

                //alfil 1
                while (casillas_amenazadas.tablero[aux.fila, aux.columna] != 0)//condicion para ver si se puede mover el alfil{
                {
                    aux.EleccionAlAzar();
                    libertad_alfil6 = (int) matriz_alfil.tablero[aux.fila, aux.columna];
                    if (libertad_alfil6 == 1)
                        libertad_alfil7 = 2;
                    else libertad_alfil7 = 1;
                }
                pos_piezas.tablero[aux.fila, aux.columna] = 6;//alfil 1
                arrayPiezas[4].pos.fila = (int)aux.fila;
                arrayPiezas[4].pos.columna = (int)aux.columna;

                casillas_amenazadas.AmenazasMovimientoAlfil(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[4]);

                aux.EleccionAlAzar();
                int cont_it = 0;
                //alfil 2
                while (casillas_amenazadas.tablero[aux.fila, aux.columna] != 0 || cont_it == 0)//condicion para ver si se puede mover el alfil{
                {
                    if(matriz_alfil.tablero[aux.fila, aux.columna] == libertad_alfil7)
                    {
                        cont_it = 1;
                        break;
                    }
                    aux.EleccionAlAzar();

                }
                pos_piezas.tablero[aux.fila, aux.columna] = 7;//alfil 2
                arrayPiezas[5].pos.fila = (int)aux.fila;
                arrayPiezas[5].pos.columna = (int)aux.columna;

                casillas_amenazadas.AmenazasMovimientoAlfil(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[5]);

                //reina
                while (casillas_amenazadas.tablero[aux.fila, aux.columna] != 0
                    || (casillas_amenazadas.tablero[aux.fila, aux.columna] == 6 ||
                    casillas_amenazadas.tablero[aux.fila, aux.columna] == 2) && ((aux.columna == arrayPiezas[2].pos.columna ||
                    aux.fila == arrayPiezas[2].pos.fila) || (aux.columna == arrayPiezas[3].pos.columna ||
                    aux.fila == arrayPiezas[3].pos.fila)))
                {
                    //lo pongo en un lugar donde NO haya amenazas
                    aux.EleccionAlAzar();
                }
                pos_piezas.tablero[aux.fila, aux.columna] = 8;
                arrayPiezas[6].pos.fila = aux.fila;
                arrayPiezas[6].pos.columna = aux.columna;

                casillas_amenazadas.AmenazasMovimientoReina(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[6]);

                //para que no me salte un -1 chequeo que hayan posiciones libres
                casillas_amenazadas.ChequeoCasillerosLibres();
                if (casillas_amenazadas.casillas_no_amenazadas == 0 )//no deberia pasar porque no estan todas las fichass
                {
                    bool chequear = ChequearTablero();

                    if (chequear)
                    {
                        copiarPosiciones();

                        cant_tab_generados++;
                        Console.WriteLine("\nTengo tablero n°:" + cant_tab_generados);
                        pos_piezas.ImprimirTablero();
                        //casillas_amenazadas.ImprimirTablero();

                        Console.WriteLine("\nAtaques fatales:" + cant_tab_generados);
                        casillas_amenazadas.ataquesLevesyFatales(matrizFatales[cant_tab_generados-1], pos_piezas, arrayPiezas);
                        matrizFatales[cant_tab_generados - 1].ImprimirTablero();


                    }

                    //taabba
                }
                else
                {
                    //posicione todas las casillas al azar, ahora tengo que colocar donde encuentre una posicion vacia
                    //caballo1
                    int[] cuartoMin = tableroMinAmenazas();
                    cPosicion auxLibre = new cPosicion();
                    auxLibre = cant_amenazasxCasillas.BuscarPosicionLibre((int)arrayPiezas[0].tipoPieza, arrayPiezas,libertad_alfil6, libertad_alfil7, matriz_alfil.tablero, cuartoMin[0], cuartoMin[1]);
                    arrayPiezas[0].pos.fila = (int)auxLibre.fila;//pongo el caballo 1
                    arrayPiezas[0].pos.columna = (int)auxLibre.columna;//pongo el caballo 1

                    pos_piezas.tablero[arrayPiezas[0].pos.fila, arrayPiezas[0].pos.columna] = 2;
                    casillas_amenazadas.AmenazasMovimientoCaballos(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[0]);

                    //caballo2
                    cuartoMin = tableroMinAmenazas();
                    auxLibre = cant_amenazasxCasillas.BuscarPosicionLibre((int)arrayPiezas[1].tipoPieza, arrayPiezas, libertad_alfil6, libertad_alfil7, matriz_alfil.tablero, cuartoMin[0], cuartoMin[1]);
                    arrayPiezas[1].pos.fila = (int)auxLibre.fila;
                    arrayPiezas[1].pos.columna = (int)auxLibre.columna;

                    pos_piezas.tablero[arrayPiezas[1].pos.fila, arrayPiezas[1].pos.columna] = 3;
                    casillas_amenazadas.AmenazasMovimientoCaballos(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[1]);

                    //rey
                    cuartoMin = tableroMinAmenazas();
                    auxLibre = cant_amenazasxCasillas.BuscarPosicionLibre((int)arrayPiezas[7].tipoPieza, arrayPiezas, libertad_alfil6, libertad_alfil7, matriz_alfil.tablero, cuartoMin[0], cuartoMin[1]);
                    arrayPiezas[7].pos.fila = (int)auxLibre.fila;
                    arrayPiezas[7].pos.columna = (int)auxLibre.columna;

                    pos_piezas.tablero[arrayPiezas[7].pos.fila, arrayPiezas[7].pos.columna] = 9;
                    casillas_amenazadas.AmenazasMovimientoRey(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[7]);

                    //me fijo si el tablero esta completo
                    casillas_amenazadas.ChequeoCasillerosLibres();
                    if (casillas_amenazadas.casillas_no_amenazadas == 0)
                    {
                        bool chequear = ChequearTablero();

                        if (chequear)
                        {
                            copiarPosiciones();

                            cant_tab_generados++;
                            Console.WriteLine("\nTengo tablero n°:" + cant_tab_generados);
                            pos_piezas.ImprimirTablero();
                           // casillas_amenazadas.ImprimirTablero();

                            Console.WriteLine("\nAtaques fatales:" + cant_tab_generados);
                            casillas_amenazadas.ataquesLevesyFatales(matrizFatales[cant_tab_generados-1], pos_piezas, arrayPiezas);
                            matrizFatales[cant_tab_generados - 1].ImprimirTablero();

                        }

                    }
                    else
                    {
                        int contador = 0;
                        while (contador < 10)
                        {
                            //Busco donde esta la pieza con la poscion mas amenazada

                                cant_amenazasxCasillas.retornoMax();
                                int max = casillas_amenazadas.tablero[cant_amenazasxCasillas.pos_max_amenazas.fila, cant_amenazasxCasillas.pos_max_amenazas.columna];//el valor de la pieza en el mas amenazas
                                cPosicion aux2 = new cPosicion();
                                cuartoMin = tableroMinAmenazas();                                
                                aux2 = casillas_amenazadas.BuscarPosicionLibre(max, arrayPiezas, libertad_alfil6, libertad_alfil7,matriz_alfil.tablero, cuartoMin[0], cuartoMin[1]);//pongo la posicion de esa pieza en otro lugar libre, pongo la pieza en 0, marco el valor nuevo en el tablero y completo amenazas
                            if (aux2.fila == -1 && aux2.columna == -1)
                            {
                                aux2 = casillas_amenazadas.BuscarPosicionLibre(9, arrayPiezas, libertad_alfil6, libertad_alfil7, matriz_alfil.tablero, cuartoMin[0], cuartoMin[1]);//pongo la posicion de esa pieza en otro lugar libre, pongo la pieza en 0, marco el valor nuevo en el tablero y completo amenazas
                                arrayPiezas[7].pos.fila = (int)aux2.fila;//nunca tiene que ser -1
                                arrayPiezas[7].pos.columna = (int)aux2.columna;//nunca tiene que ser -1
                                pos_piezas.LiberarPieza(9);
                                pos_piezas.tablero[arrayPiezas[7].pos.fila, arrayPiezas[7].pos.columna] = (int)arrayPiezas[7].tipoPieza;
                            }
                            else
                            {
                                arrayPiezas[max - 2].pos.fila = (int)aux2.fila;//nunca tiene que ser -1
                                arrayPiezas[max - 2].pos.columna = (int)aux2.columna;//nunca tiene que ser -1

                       
                                pos_piezas.LiberarPieza(max);
                                pos_piezas.tablero[arrayPiezas[max - 2].pos.fila, arrayPiezas[max - 2].pos.columna] = (int)arrayPiezas[max - 2].tipoPieza;
                            }
                                casillas_amenazadas.InicializarMatrizEn0();
                                cant_amenazasxCasillas.InicializarMatrizEn0();
                                casillas_amenazadas.AmenazarTablero(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas, true);
                                //movi la pieza y reamenace todo
                                casillas_amenazadas.ChequeoCasillerosLibres();
                           
                            if (casillas_amenazadas.casillas_no_amenazadas == 0)
                            {
                                bool chequear = ChequearTablero();

                                if (chequear)
                                {
                                    copiarPosiciones();

                                    cant_tab_generados++;
                                    Console.WriteLine("\nTengo tablero n°:" + cant_tab_generados);
                                    pos_piezas.ImprimirTablero();
                                   // casillas_amenazadas.ImprimirTablero();

                                    Console.WriteLine("\nAtaques fatales:" + cant_tab_generados);
                                    casillas_amenazadas.ataquesLevesyFatales(matrizFatales[cant_tab_generados-1], pos_piezas, arrayPiezas);
                                    matrizFatales[cant_tab_generados-1].ImprimirTablero();
                                    break;
                                }
                                else
                                {
                                  break;
                                }
                            }
                            else
                            {
                               
                                contador++;
                            }
                        }
                    }
                }
            }
        }
        public cJuego()
        {
            cant_tableros_a_generar = 10;//inicializo 10 pa que funque
            cant_tab_generados = 0;
            matriz_alfil = new cTablero();
            casillas_amenazadas = new Amenazas();
            pos_piezas = new cTablero();
            cant_amenazasxCasillas = new Amenazas();
            arrayPiezas = new Pieza[8];//yo recibiria una por parametro
            matrizFatales = new cTablero[cant_tableros_a_generar];
            Tableros = new Pieza[cant_tableros_a_generar, 8];
            for (int i = 0; i < cant_tableros_a_generar; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tableros[i, j] = new Pieza(0);
                   
                }
                matrizFatales[i] = new cTablero();
            }
        }
        public void InicializarTableroAlfil()
        {
            //int cont = 0;
            for (int i = 0; i < matriz_alfil.tablero.GetLength(0); i++)
            {
                for (int j = 0; j < matriz_alfil.tablero.GetLength(1); j++)
                {
                    if ((i+j) % 2 == 0 || (i+j) == 0)
                    {
                        matriz_alfil.tablero[i, j] = 1;
                    }
                    else
                    {
                        matriz_alfil.tablero[i, j] = 2;
                    }
                   // cont++;
                }
            }
        }
        public int[,] LlenarCuartoTablero(int cuarto)
        {
            int[,] cuartoTablero = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cuartoTablero[i, j] = 0;
                }
            }
            switch (cuarto)
            {
                case 1:
                    {
                        for (int i = 0; i < cuartoTablero.GetLength(0); i++)
                        {
                            for (int j = 0; j < cuartoTablero.GetLength(1); j++)
                            {
                                cuartoTablero[i, j] = pos_piezas.tablero[i, j];
                            }
                        }
                        return cuartoTablero;
                        //break;
                    }
                case 2://2ndo cuarto
                    {
                        for (int i = 0; i < cuartoTablero.GetLength(0); i++)
                        {
                            for (int j = 4; j < 4 + cuartoTablero.GetLength(1); j++)
                            {
                                cuartoTablero[i, j - 4] = pos_piezas.tablero[i, j];
                            }
                        }
                        return cuartoTablero;
                        //break;
                    }
                case 3://3ercuarto
                    {
                        for (int i = 4; i < 4 + cuartoTablero.GetLength(0); i++)
                        {
                            for (int j = 0; j < cuartoTablero.GetLength(1); j++)
                            {
                                cuartoTablero[i - 4, j] = pos_piezas.tablero[i, j];
                            }
                        }
                        return cuartoTablero;
                        //break;
                    }
                case 4:// 4to cuarto
                    {
                        for (int i = 4; i < 4 + cuartoTablero.GetLength(0); i++)
                        {
                            for (int j = 4; j < 4 + cuartoTablero.GetLength(1); j++)
                            {
                                cuartoTablero[i - 4, j - 4] = pos_piezas.tablero[i, j];
                            }
                        }
                        return cuartoTablero;
                        //break;
                    }
                default:
                    return cuartoTablero;
            }


        }              
        public bool ChequearTablero()
        {
            bool optn = true;
            int[] contador = new int[cant_tab_generados];
            if (cant_tab_generados == 0)
            {
                return optn;
            }

            for (int i = 0; i < pos_piezas.tablero.GetLength(0); i++)
            {
                for (int j = 0; j < cant_tab_generados; j++)
                {
                    
                    if (arrayPiezas[i].pos.fila != (int)Tableros[j, i].pos.fila || arrayPiezas[i].pos.columna != (int)Tableros[j, i].pos.columna)//hago variar la fila (osea el tablero) 
                    {                        
                        if(i==0)//caso caballos
                        {
                            if (arrayPiezas[i].pos.fila != (int)Tableros[j, i+1].pos.fila)
                            {
                                contador[j]++;
                            }
                        }
                        if (i == 2)//caso torres
                        {
                            if (arrayPiezas[i].pos.fila != (int)Tableros[j, i + 1].pos.fila)
                            {
                                contador[j]++;
                            }
                        }
                        if (i == 4)//caso alfiles
                        {
                            if (arrayPiezas[i].pos.fila != (int)Tableros[j, i + 1].pos.fila)
                            {
                                contador[j]++;
                            }
                        }
                    }

                }
            }
            for (int i = 0; i < cant_tab_generados; i++)
            {
                if (contador[i] == 0)
                {
                    optn = false;
                    return optn;
                }
            }
            return optn;
        }
        public void copiarPosiciones()
        {
            for (int i = 0; i < 8; i++)
            {
                if (cant_tab_generados < 10)
                {

                    Tableros[cant_tab_generados, i].pos.fila = (int)arrayPiezas[i].pos.fila;
                    Tableros[cant_tab_generados, i].pos.columna = (int)arrayPiezas[i].pos.columna;
                    Tableros[cant_tab_generados, i].tipoPieza = arrayPiezas[i].tipoPieza;
                }

            }
        }
        public int[] tableroMinAmenazas()
        {
            int[] rango = new int[2];
            int[] cont = new int[4];
            for (int i = 0; i < 4; i++)
            {
                cont[i] = 0;
            }
            int cuartoMinAmenazas = 0;

            //primer cuarto
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (casillas_amenazadas.tablero[i, j] == 0)
                        cont[0]++;
                }
            }

            //segundo cuarto
            for (int i = 0; i < 4; i++)
            {
                for (int j = 4; j < 8; j++)
                {
                    if (casillas_amenazadas.tablero[i, j] == 0)
                        cont[1]++;
                }
            }

            //tercer cuarto
            for (int i = 4; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (casillas_amenazadas.tablero[i, j] == 0)
                        cont[2]++;
                }
            }

            //cuarto cuarto
            for (int i = 4; i < 8; i++)
            {
                for (int j = 4; j < 8; j++)
                {
                    if (casillas_amenazadas.tablero[i, j] == 0)
                        cont[3]++;
                }
            }

            //busco el cuarto con menor amenazas
            int minAmenazas = cont[0];
            for (int i = 0; i < 4; i++)
            {
                if (cont[i] > minAmenazas)//significa que el cuarto tiene MAS casillas sin amenazas
                {
                    minAmenazas = cont[i];
                    cuartoMinAmenazas = i;
                }
            }
            switch (cuartoMinAmenazas)
            {
                case 0:
                    {
                        rango[0] = 0;
                        rango[1] = 0;
                        break;
                    }

                case 1:
                    {
                        rango[0] = 0;
                        rango[1] = 4;
                        break;
                    }
                case 2:
                    {
                        rango[0] = 4;
                        rango[1] = 0;
                        break;
                    }
                case 3:
                    {
                        rango[0] = 4;
                        rango[1] = 4;
                        break;
                    }

                default:
                    break;
            }
            return rango;

        }
       
 
    }
}

