using System;
using System.Collections.Generic;
using System.Text;

namespace Brickwork
{
    class InputOperations //
    {
        public int SetBrickWallDimensions() // set the wall dimentions, checks the input values from the user and validates them 
        {
            int dimension = 0;
            bool flag = true;

            while (flag)
            {
                try
                {
                    dimension = Int32.Parse(Console.ReadLine());

                    if ((dimension < 1) || (dimension > 100) || (dimension % 2 != 0))
                    {
                        Console.WriteLine("The number must be a whole, even number larger than 0 and lower than 100!");
                    }
                    else
                    {
                        flag = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a whole, even number larger than 0 and lower than 100.");
                }
            }
            return dimension;
        }

        public int[,] InputBrickWall(int M, int N) // takes how many rows and columns are in the brick wall, reads the user input and fills the data into an array, which represents the brick wall   
        {
            int[,] wall = new int[M, N];

            for (int i = 0; i < M; i++)
            {

                string[] row = Console.ReadLine().Split(" "); //reads the user input line and separates the values by a space

                for (int j = 0; j < N; j++)
                {
                    try
                    {
                        wall[i, j] = Int32.Parse(row[j]);

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid values");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Index out of range.");
                    }
                }
            }

            Validate(wall, M, N);
            return wall;
        }
        private void Validate(int[,] wall, int M, int N) //Validates if there is any brick that spans more than 2 rows or columns, or if there are invalid values
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if ((wall[i, j] == 0) || (wall[i, j] < 1) || (wall[i, j] > N * M))
                    {
                        throw new Exception("Invalid brick placement");
                    }
                    if (i + 2 < M)
                    {
                        if (wall[i, j] == wall[i + 2, j] && wall[i, j] == wall[i + 1, j])
                        {
                            throw new Exception("Brick spans to more than 2 rows and 2 columns");
                        }
                    }
                    if (j + 2 < N)
                    {
                        if (wall[i, j] == wall[i, j + 2] && wall[i, j] == wall[i, j + 1])
                        {
                            throw new Exception("Brick spans to more than 2 rows and 2 columns");
                        }
                    }
                }
            }
        }
    }
}
