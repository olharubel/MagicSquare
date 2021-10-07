using System;


namespace MagicSquare
{
    class Program
    {
        public static string TestMatrix(int[,] square, int n)
        {
            int sumDiagonal1 = 0;
            int sumDiagonal2 = 0;
            int[] sumRow = new int[n];
            int[] sumColumns = new int[n];
            for(int i = 0; i < n; ++i)
            {
                for(int j = 0; j < n; ++j)
                {
                    sumRow[i] += square[i, j];
                    sumColumns[i] += square[j, i];
                }
            }

            int[] sumDiagonal = new int[2];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if(i == j)
                    {
                        sumDiagonal1 += square[i, j];
                    }
                   
                    if(i + j == n -1)
                    {
                        sumDiagonal2 += square[i, j];
                    }
                   
                }
            }

            int totalSum = (n * (n * n + 1)) / 2;

            if (Array.TrueForAll(sumRow, value => value == totalSum))
            {
                if(Array.TrueForAll(sumColumns, value => value == totalSum))
                {
                    if(sumDiagonal1 == totalSum && sumDiagonal2 == totalSum)
                    {
                        return "Matrix is magic square!!!";
                    }
                }
            }

            return "Matrix is not magic square!!!";
        }

        static void Main(string[] args)
        {
            int n = 9;
            int[,] square = new int[n, n];


            for (int a = 0; a < n; ++a)
            {
                for (int b = 0; b < n; ++b)
                {
                    square[a, b] = 0;
                }
            }

            int elem = 1;

            int central = n / 2;
            int i = 0;
            int j = n / 2;
            square[0, central] = elem;


            for (int k = 0; k < n*n-1; ++k)
            {
                if (i == 0 && j < n - 1)
                {
                    i = n - 1;
                    j = j + 1;
                    square[i, j] = ++elem;
                }
                else if (i > 0 && j == n - 1)
                {
                    i = i - 1;
                    j = 0;
                    square[i, j] = ++elem;
                }

                else if(i == 0 && j == n - 1)
                {
                    i = n - 1;
                    j = 0;
                    if(square[i, j] != 0)
                    {
                        i = 1;
                        j = n - 1;
                        square[i, j] = ++elem;
                    }
                    else
                    {
                        square[i, j] = ++elem;
                    }
                  
                }

                else if(i != 0 && j < n - 1)
                {
                    i = i - 1;
                    j = j + 1;
                    if(square[i, j] != 0)
                    {
                        i = i + 2;
                        j = j - 1;
                        square[i, j] = ++elem;
                    }
                    else if(square[i,j] == 0)
                    {
                        square[i, j] = ++elem;
                    }
                }


            }


            for (int a = 0; a < n; ++a)
            {
                for (int b = 0; b < n; ++b)
                {
                    Console.Write(square[a, b] + "\t");
                }

                Console.WriteLine();
            }

            string result = TestMatrix(square, n);
            Console.WriteLine(result);
          

            Console.ReadLine();
        }
    }
}





