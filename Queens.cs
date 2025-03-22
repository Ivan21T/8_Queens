using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Задача_царици
{
   
    internal class Program
    {
        public static ulong Queens(int n, bool[,] chessBoard)
        {
            if (n == 0)
            {
                for (int p = 0; p < chessBoard.GetLength(0); p++)
                {
                    for (int t = 0; t < chessBoard.GetLength(1); t++)
                    {
                        if (chessBoard[p,t])
                        {
                            Console.Write("\u2655 ");
                        }
                        else
                        {
                            Console.Write("* ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                return 1;
            }
            ulong totalSolution = 0;
            int i = n - 1;
            for (int j = 0; j < chessBoard.GetLength(1); j++)
            {
                 bool placeQueen = true;
                 int[] dx = new int[] { 1,1,1 };
                 int[] dy = new int[] { 0, -1, 1 };
                 for (int p = 0;placeQueen && p < dx.Length; p++)
                 {
                     int x = i;
                     int y = j;
                     while (x >= 0 && x < chessBoard.GetLength(0) && y >= 0 && y < chessBoard.GetLength(1))
                     {
                            if (chessBoard[x, y])
                            {
                                placeQueen = false;
                                break;
                            }
                            x += dx[p];
                            y += dy[p];
                      }
                 }
                 if (placeQueen)
                 {
                    chessBoard[i, j] = true;
                    totalSolution += Queens(n - 1, chessBoard);
                    chessBoard[i, j] = false;
                 }
            }
            
            return totalSolution;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int queens=int.Parse(Console.ReadLine());
            int rows = queens;
            int cols = queens;
            Console.WriteLine(Queens(queens, new bool[rows, cols]));
        }
    }
}
