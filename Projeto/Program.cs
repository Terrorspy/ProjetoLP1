using System;

namespace Projeto
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[,] matrix = new int[5,5];

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                   matrix[0, 0] = 21;
                   matrix[0, 1] = 22;
                   matrix[0, 2] = 23;
                   matrix[0, 3] = 24;
                   matrix[0, 4] = 25;
                   matrix[1, 0] = 20;
                   matrix[1, 1] = 19;
                   matrix[1, 2] = 18;
                   matrix[1, 3] = 17;
                   matrix[1, 4] = 17;
                   matrix[1, 4] = 16; 
                   matrix[2, 0] = 11;
                   matrix[2, 1] = 12;
                   matrix[2, 2] = 13;
                   matrix[2, 3] = 14;
                   matrix[2, 4] = 15;
                   matrix[3, 0] = 10;   
                   matrix[3, 1] = 9;
                   matrix[3, 2] = 8;
                   matrix[3, 3] = 7;
                   matrix[3, 4] = 6;
                   matrix[4, 0] = 1;
                   matrix[4, 1] = 2;
                   matrix[4, 2] = 3;
                   matrix[4, 3] = 4;
                   matrix[4, 4] = 5;    
                  
                   Console.Write(matrix[i, j] + " ");

                }
                Console.Write("]");
                Console.Write("\n");
                
            }
        }
    }
}
