using System;
using System.Linq;

namespace Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            int marioRow = 0;
            int marioCol = 0;
            for (int r = 0; r  < matrix.GetLength(0); r++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[r] = input;
                for (int c = 0; c < input.Length; c++)
                {
                    if (matrix[r][c] == 'M')
                    {
                        marioRow = r;
                        marioCol = c;
                    }
                }
            }
            bool mission = false;
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                char move = char.Parse(command[0]);
                int spownRow = int.Parse(command[1]);
                int spownCol = int.Parse(command[2]);
                matrix[spownRow][spownCol] = 'B';
                lives--;

                if (move == 'W')
                {
                    if (marioRow - 1 < 0)
                    {
                        continue;
                    }
                    matrix[marioRow][marioCol] = '-';
                    marioRow--;
                }
                if (move == 'S')
                {
                    if (marioRow + 1 == rows)
                    {
                        continue;
                    }
                    matrix[marioRow][marioCol] = '-';
                    marioRow++;
                }
                if (move == 'A')
                {
                    if (marioCol - 1 < 0)
                    {
                        continue;
                    }
                    matrix[marioRow][marioCol] = '-';
                    marioCol--;
                }
                if (move == 'D')
                {
                    if (marioCol + 1 == matrix[marioRow].Length)
                    {
                        continue;
                    }
                    matrix[marioRow][marioCol] = '-';
                    marioCol++;
                }
                if (lives <= 0)
                {
                    matrix[marioRow][marioCol] = 'X';
                    break;
                }
                if (matrix[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = 'X';
                        break;
                    }
                    
                }
                else if (matrix[marioRow][marioCol] == 'P')
                {
                    mission = true;
                    matrix[marioRow][marioCol] = '-';
                    break;
                }
                
                    matrix[marioRow][marioCol] ='M';
                
                
            }
            if (mission)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(matrix[i]);
            }
        }
    }
}
