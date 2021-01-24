using System;

namespace Brickwork
{
    class Program
    {
        static void Main(string[] args)
        {
            //InputOperations is used for filling first layer
            InputOperations inputOperations = new InputOperations();
            //OutputOperations is used for second layer logic
            OutputOperations outputOperations = new OutputOperations();

            Console.WriteLine("Enter how many rows are in the brick wall? The number must be a whole, even number larger than 0 and lower than 100!");

            //represents number of brick rows
            int M = inputOperations.SetBrickWallDimensions();

            Console.WriteLine("Enter how many columns are in the brick wall? The number must be a whole, even number larger than 0 and lower than 100!");
            //represents number of brick columns
            int N = inputOperations.SetBrickWallDimensions();

            Console.WriteLine(M + " X " + N);

            Console.WriteLine("Construct the first layer of the brickwall. A brick can't span more than 2 rows or columns.");


            //Begins output. A solution for the given task, always exists
            //the first layer of brick wall, created by the user
            int[,] inputWall = inputOperations.InputBrickWall(M, N);

            Console.WriteLine();

            // the second layer of the brick wall 
            int[,] outputWall = outputOperations.BuildSecondLayer(inputWall, M, N);
            outputOperations.PrintOutputWall(outputWall, M, N);

            Console.ReadKey(true);
        }
    }
}
