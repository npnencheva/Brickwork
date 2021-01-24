using System;
using System.Collections.Generic;
using System.Text;

namespace Brickwork
{   
    // Input operations connected to the first layer
    class InputOperations 
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

        // takes how many rows and columns are in the brick wall, reads the user input and fills the data into an array, which represents the brick wall   
        public int[,] InputBrickWall(int M, int N) 
        {
            // array representing the first layer, created by the user
            int[,] inputWall = new int[M, N];

            for (int i = 0; i < M; i++)
            {
                //reads the user input line and separates the values by a space
                string[] row = Console.ReadLine().Split(" "); 

                for (int j = 0; j < N; j++)
                {
                    try
                    {
                        inputWall[i, j] = Int32.Parse(row[j]);

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

            Validate(inputWall, M, N);
            return inputWall;
        }

        //Validates if there is any brick that spans more than 2 rows or columns, or if there are invalid values
        private void Validate(int[,] wall, int M, int N) 
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
