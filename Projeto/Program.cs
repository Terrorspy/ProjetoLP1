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
                   Console.Write(matrix[i, j] + " ");
                   
                }
                Console.Write("]");
                Console.Write("\n");
                
            }
        }
    }
}
