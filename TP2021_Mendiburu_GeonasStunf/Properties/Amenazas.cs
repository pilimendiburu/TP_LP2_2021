﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP2021_Mendiburu_GeonasStunf
{
    public class Amenazas : cTablero//HERENCIA
    {
        public int casillas_no_amenazadas;
        public cPosicion pos_max_amenazas;
        public int max_amenazas;

        //char[,] ataques_fatales_y_leves = new char[8, 8];
        public Amenazas()
        {
            casillas_no_amenazadas = 0;
            pos_max_amenazas = new cPosicion();
            max_amenazas = (int)tablero[0, 0];

        }
        public void AmenazasMovimientoCaballos(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza) //necesito poner el numero por eso{ 
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == pieza.pos.fila)
                        break;
                    if ((i == (pieza.pos.fila + 2) && pieza.pos.columna + 1 == j) || (i == (pieza.pos.fila - 2) && (pieza.pos.columna + 1) == j))
                    {
                        tablero[i, j] = (int)pieza.tipoPieza;
                        Amz_x_Cas[i, j]++;
                    }
                    if ((pieza.pos.fila + 2 == i && j == pieza.pos.columna - 1) || (pieza.pos.fila - 2 == i && j == pieza.pos.columna - 1))
                    {

                        tablero[i, j] = (int)pieza.tipoPieza;
                        Amz_x_Cas[i, j]++;
                    }
                    if ((pieza.pos.fila + 1 == i && j == pieza.pos.columna + 2) || (pieza.pos.fila - 1 == i && j == pieza.pos.columna + 2))
                    {
                        tablero[i, j] = (int)pieza.tipoPieza;
                        Amz_x_Cas[i, j]++;
                    }
                    if ((pieza.pos.fila + 1 == i && j == pieza.pos.columna - 2) || (pieza.pos.fila - 1 == i && j == pieza.pos.columna - 2))
                    {
                        tablero[i, j] = (int)pieza.tipoPieza;
                        Amz_x_Cas[i, j]++;
                    }

                }
            }
            tablero[pieza.pos.fila, pieza.pos.columna] = (int)pieza.tipoPieza;
            Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] = Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] + 1;
        }
        public void AmenazasMovimientoTorre(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == pieza.pos.fila)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        tablero[i, j] = (int)pieza.tipoPieza;//completo matriz con amenazas con nro correspondiente
                        Amz_x_Cas[i, j] = Amz_x_Cas[i, j] + 1;//completo matriz con cant ataques sumando 1
                    }

                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (i == pieza.pos.columna)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        tablero[j, i] = (int)pieza.tipoPieza;//completo matriz con amenazas con nro correspondiente
                        Amz_x_Cas[j, i] = Amz_x_Cas[j, i] + 1;//completo matriz con cant ataques sumando 1
                    }
                }
            }
            //ImprimirTablero();
            //complete dos veces la matriz con 1 en la posicion propuesta
            Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] -= 1;
        }
        public void AmenazasMovimientoAlfil(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza)
        {

            int i = pieza.pos.fila;
            int j = pieza.pos.columna;
           
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] += 1;
                    tablero[i, j] = (int)pieza.tipoPieza;

                    i++;
                    j++;
                }
                i = pieza.pos.fila;
                j = pieza.pos.columna;
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] += 1;
                    tablero[i, j] = (int)pieza.tipoPieza;

                    i--;
                    j--;
                }
                Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] -= 1;
                i = pieza.pos.fila;
                j = pieza.pos.columna;
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] += 1;
                    tablero[i, j] = (int)pieza.tipoPieza;

                    i++;
                    j--;
                }
                Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] -= 1;
                i = pieza.pos.fila;
                j = pieza.pos.columna;
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] += 1;
                    tablero[i, j] = (int)pieza.tipoPieza;

                    i--;
                    j++;
                }
                Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] -= 1;
            
           
        }
        public void AmenazasMovimientoReina(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza)
        {
            AmenazasMovimientoAlfil(Amz_x_Cas, pos_piezas, pieza);
            AmenazasMovimientoTorre(Amz_x_Cas, pos_piezas, pieza);
            Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] += 1;
        }
        public cPosicion BuscarPosicionLibre(int pieza, Pieza[] arrayPiezas, int A6, int A7, int[,] matriz_alfil, int r1,int r2, bool rey = false)
        {
            //int cont = 0;
            cPosicion pos = new cPosicion();
            for (int i = r1; i < r1+4; i++)
            {
                for (int j = r2; j < r2+4; j++)
                {
                    if (tablero[i, j] == 0)
                    {
                        pos.fila = i;
                        pos.columna = j;
                        //casillas_no_amenazadas = cont + 1

                        switch (pieza)
                        {

                            case 2:
                            case 3:
                            case 8:
                            case 9:
                                return pos;
                            case 4:
                                {
                                    if (pos.columna != arrayPiezas[3].pos.columna || pos.fila != arrayPiezas[3].pos.fila)
                                        return pos;
                                    break;

                                }
                            case 5:
                                {
                                    if (pos.columna != arrayPiezas[2].pos.columna || pos.fila != arrayPiezas[2].pos.fila)
                                        return pos;
                                    break;
                                }
                            case 6:
                                {
                                    if (matriz_alfil[pos.fila, pos.columna] == A6)
                                        return pos;
                                    else
                                    {
                                        if (matriz_alfil[pos.fila, pos.columna] == A7)
                                        {
                                            pos.fila = -1;
                                            pos.columna = -1;
                                        }

                                    }
                                    break;
                                    //hola
                                }
                            case 7:
                                {
                                    if (matriz_alfil[pos.fila, pos.columna] == A7)
                                        return pos;                               
                                    else
                                    {
                                        if (matriz_alfil[pos.fila, pos.columna] == A6)
                                        {
                                            pos.fila = -1;
                                            pos.columna = -1;
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }


            }
            return pos;//
        }
        public void AmenazasMovimientoRey(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (pieza.pos.fila == i)
                    {
                        if (pieza.pos.columna - 1 == j || j == pieza.pos.columna + 1)
                        {
                           
                                tablero[i, j] = (int)pieza.tipoPieza;//pongo en REY
                                Amz_x_Cas[i, j]++;
                            
                        }
                    }
                    if (pieza.pos.columna == j)
                    {
                        if (pieza.pos.fila - 1 == i || i == pieza.pos.fila + 1)
                        {
                         
                                tablero[i, j] = (int)pieza.tipoPieza;//pongo en REY
                                Amz_x_Cas[i, j]++;
                          
                        }
                    }
                    if (i == pieza.pos.fila + 1 || i == pieza.pos.fila - 1)
                    {
                        if (j == pieza.pos.columna + 1 || j == pieza.pos.columna - 1)
                        {
                           
                                tablero[i, j] = (int)pieza.tipoPieza;//pongo en REY
                                Amz_x_Cas[i, j]++;
                            
                        }
                    }
                }

            }
            tablero[pieza.pos.fila, pieza.pos.columna] = (int)pieza.tipoPieza;
        }       
        public void AmenazarTablero(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza[] piezas, bool sumar) {

            for (int i = 0; i < 8; i++)
            {
                switch (piezas[i].tipoPieza)
                {
                    case e_Pieza.CABALLO1:
                        AmenazasMovimientoCaballos(Amz_x_Cas, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.CABALLO2:
                        AmenazasMovimientoCaballos(Amz_x_Cas, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.TORRE1:
                        AmenazasMovimientoTorre(Amz_x_Cas, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.TORRE2:
                        AmenazasMovimientoTorre(Amz_x_Cas, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.ALFIL1:
                        AmenazasMovimientoAlfil(Amz_x_Cas, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.ALFIL2:
                        AmenazasMovimientoAlfil(Amz_x_Cas, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.REINA:
                        AmenazasMovimientoReina(Amz_x_Cas, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.REY:
                        AmenazasMovimientoRey(Amz_x_Cas, pos_piezas, piezas[i]);
                        break;
                    default:
                        break;
                }
            }
        }
        public void ChequeoCasillerosLibres()
        {
            casillas_no_amenazadas = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero[i, j] == 0)
                        casillas_no_amenazadas++;
                }

            }
        }
        public void retornoMax()
        {
            pos_max_amenazas.fila = 0;
            pos_max_amenazas.columna = 0;

            max_amenazas = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((int)tablero[i, j] > max_amenazas)
                    {
                        max_amenazas = (int)tablero[i, j];
                        pos_max_amenazas.fila = i;
                        pos_max_amenazas.columna = j;
                    }

                }
            }
        }     
        public void ataquesLevesyFatales(cTablero matriz_Fatales, cTablero pos_piezas, Pieza[] piezas)
        {
            //IDEA: rellenar matriz nueva 
            //rellanar matriz_Fatales con funciones de amenazas de cada pieza HASTA encontrar un pieza en el tablero.
            matriz_Fatales.InicializarMatrizEn0();

            for (int i = 0; i < 8; i++)
            {
                switch (piezas[i].tipoPieza)
                {
                    case e_Pieza.CABALLO1:
                        AmenazasFatalesCaballos(matriz_Fatales, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.CABALLO2:
                        AmenazasFatalesCaballos(matriz_Fatales, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.TORRE1:
                        AmenazasFatalesTorre(matriz_Fatales, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.TORRE2:
                        AmenazasFatalesTorre(matriz_Fatales, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.ALFIL1:
                        AmenazasFatalesAlfil(matriz_Fatales, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.ALFIL2:
                        AmenazasFatalesAlfil(matriz_Fatales, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.REINA:
                        AmenazasFatalesReina(matriz_Fatales, pos_piezas, piezas[i]);
                        break;
                    case e_Pieza.REY:
                        AmenazasFatalesRey(matriz_Fatales, pos_piezas, piezas[i]);
                        break;
                    default:
                        break;
                }
            }

        }
        public void AmenazasFatalesCaballos(cTablero matriz_Fatales, cTablero pos_piezas, Pieza pieza) //necesito poner el numero por eso{ 
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == pieza.pos.fila)
                        break;
                    if ((i == (pieza.pos.fila + 2) && pieza.pos.columna + 1 == j) || (i == (pieza.pos.fila - 2) && (pieza.pos.columna + 1) == j))
                    {
                        matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                    }
                    if ((pieza.pos.fila + 2 == i && j == pieza.pos.columna - 1) || (pieza.pos.fila - 2 == i && j == pieza.pos.columna - 1))
                    {
                        matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                    }
                    if ((pieza.pos.fila + 1 == i && j == pieza.pos.columna + 2) || (pieza.pos.fila - 1 == i && j == pieza.pos.columna + 2))
                    {
                        matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                    }
                    if ((pieza.pos.fila + 1 == i && j == pieza.pos.columna - 2) || (pieza.pos.fila - 1 == i && j == pieza.pos.columna - 2))
                    {
                        matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                    }

                }
            }
            matriz_Fatales.tablero[pieza.pos.fila, pieza.pos.columna] = (int)pieza.tipoPieza;
            
        }
        public void AmenazasFatalesTorre(cTablero matriz_Fatales, cTablero pos_piezas, Pieza pieza)
        {
            for(int i = pieza.pos.fila; i >= 0; i--)
            {
                if(pos_piezas.tablero[i, pieza.pos.columna] == 0)
                {
                    matriz_Fatales.tablero[i, pieza.pos.columna] = (int)pieza.tipoPieza;

                }
                if(pos_piezas.tablero[i, pieza.pos.columna]!=0&& pos_piezas.tablero[i, pieza.pos.columna]!=(int)pieza.tipoPieza)
                {
                    matriz_Fatales.tablero[i, pieza.pos.columna] = (int)pieza.tipoPieza;
                    break;
                }
                else
                    matriz_Fatales.tablero[i, pieza.pos.columna] = (int)pieza.tipoPieza;
            }         

            for(int i=pieza.pos.fila; i<8;i++)
            {
                if (pos_piezas.tablero[i, pieza.pos.columna] == 0)
                {
                    matriz_Fatales.tablero[i, pieza.pos.columna] = (int)pieza.tipoPieza;
                }
                if (pos_piezas.tablero[i, pieza.pos.columna] != 0 && pos_piezas.tablero[i, pieza.pos.columna] != (int)pieza.tipoPieza)
                {
                    matriz_Fatales.tablero[i, pieza.pos.columna] = (int)pieza.tipoPieza;
                    break;
                }
                else
                    matriz_Fatales.tablero[i, pieza.pos.columna] = (int)pieza.tipoPieza;
            }


            for (int j = pieza.pos.columna; j >= 0; j--)
            {
                if (pos_piezas.tablero[pieza.pos.fila, j] == 0)
                {
                    matriz_Fatales.tablero[pieza.pos.fila, j] = (int)pieza.tipoPieza;

                }
                if (pos_piezas.tablero[pieza.pos.fila, j] != 0 && pos_piezas.tablero[pieza.pos.fila, j] != (int)pieza.tipoPieza)
                {
                    matriz_Fatales.tablero[pieza.pos.fila, j] = (int)pieza.tipoPieza;
                    break;
                }
                else
                    matriz_Fatales.tablero[pieza.pos.fila, j] = (int)pieza.tipoPieza;

            }

            for (int j = pieza.pos.columna; j < 8; j++)
            {
                if (pos_piezas.tablero[pieza.pos.fila, j] == 0)
                {
                    matriz_Fatales.tablero[pieza.pos.fila, j] = (int)pieza.tipoPieza;

                }
                if (pos_piezas.tablero[pieza.pos.fila, j] != 0 && pos_piezas.tablero[pieza.pos.fila, j] != (int)pieza.tipoPieza)
                {
                    matriz_Fatales.tablero[pieza.pos.fila, j] = (int)pieza.tipoPieza;
                    break;
                }
                else
                    matriz_Fatales.tablero[pieza.pos.fila, j] = (int)pieza.tipoPieza;
            }
            
        }
        public void AmenazasFatalesAlfil(cTablero matriz_Fatales, cTablero pos_piezas, Pieza pieza)
        {
            int i = pieza.pos.fila;
            int j = pieza.pos.columna;


            while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
            {
                if (pos_piezas.tablero[i, j] == 0)
                {
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;

                }
                if (pos_piezas.tablero[i, j] != 0 && pos_piezas.tablero[i, j] != (int)pieza.tipoPieza)
                {
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                    break;
                }
                if (pos_piezas.tablero[i, j] == (int)pieza.tipoPieza)
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                i++;
                j++;

            }
            i = pieza.pos.fila;
            j = pieza.pos.columna;
            while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
            {
                if (pos_piezas.tablero[i, j] == 0)
                {
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;

                }
                if (pos_piezas.tablero[i, j] != 0 && pos_piezas.tablero[i, j] != (int)pieza.tipoPieza)
                {
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                    break;
                }
                if (pos_piezas.tablero[i, j] == (int)pieza.tipoPieza)
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;

                i--;
                j--;
            }
            i = pieza.pos.fila;
            j = pieza.pos.columna;
            while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
            {
                if (pos_piezas.tablero[i, j] == 0)
                {
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;


                }
                if (pos_piezas.tablero[i, j] != 0 && pos_piezas.tablero[i, j] != (int)pieza.tipoPieza)
                {
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                    break;
                }
                if (pos_piezas.tablero[i, j] == (int)pieza.tipoPieza)
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                i++;
                j--;
            }
            i = pieza.pos.fila;
            j = pieza.pos.columna;
            while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
            {

                if (pos_piezas.tablero[i, j] == 0)
                {
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;


                }
                if (pos_piezas.tablero[i, j] != 0 && pos_piezas.tablero[i, j] != (int)pieza.tipoPieza)
                {
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                    break;
                }
                if (pos_piezas.tablero[i, j] == (int)pieza.tipoPieza)
                    matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;
                i--;
                j++;
            }
           
        }
        public void AmenazasFatalesReina(cTablero matriz_Fatales, cTablero pos_piezas, Pieza pieza)
        {
            AmenazasFatalesAlfil(matriz_Fatales, pos_piezas, pieza);
            AmenazasFatalesTorre(matriz_Fatales, pos_piezas, pieza);
            
        }
        public void AmenazasFatalesRey(cTablero matriz_Fatales, cTablero pos_piezas, Pieza pieza)
        {
            //REY amenaza siempre igual aunque haya pieza -> no le cambia nada
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (pieza.pos.fila == i)
                    {
                        if (pieza.pos.columna - 1 == j || j == pieza.pos.columna + 1)
                        {

                            matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;

                        }
                    }
                    if (pieza.pos.columna == j)
                    {
                        if (pieza.pos.fila - 1 == i || i == pieza.pos.fila + 1)
                        {
                            matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;

                        }
                    }
                    if (i == pieza.pos.fila + 1 || i == pieza.pos.fila - 1)
                    {
                        if (j == pieza.pos.columna + 1 || j == pieza.pos.columna - 1)
                        {

                            matriz_Fatales.tablero[i, j] = (int)pieza.tipoPieza;

                        }
                    }
                }

            }
            matriz_Fatales.tablero[pieza.pos.fila, pieza.pos.columna] = (int)pieza.tipoPieza;
        }
      

    }
}