using System;
using System.Collections.Generic;
using System.Text;

namespace Brickwork
{
    class OutputOperations // operations for the second layer of bricks 
    {
        // Builds the second layer based on limitations of the first layer. 
        public int[,] BuildSecondLayer(int[,] inputWall, int M, int N)
        {
            //represents the second layer of the brick wall
            int[,] outputWall = new int[M, N];
            //represents the number of the current brick
            int brickCounter = 1;
            for (int i = 0; i < M - 1; i += 2)
            {
                for (int j = 0; j < N - 1; j += 2)
                {
                    if (inputWall[i, j] == inputWall[i + 1, j] || inputWall[i, j + 1] == inputWall[i + 1, j + 1])
                    {
                        outputWall[i, j] = brickCounter;
                        outputWall[i, j + 1] = brickCounter;
                        brickCounter++;
                        outputWall[i + 1, j] = brickCounter;
                        outputWall[i + 1, j + 1] = brickCounter;
                        brickCounter++;
                    }
                    else
                    {
                        outputWall[i, j] = brickCounter;
                        outputWall[i + 1, j] = brickCounter;
                        brickCounter++;
                        outputWall[i, j + 1] = brickCounter;
                        outputWall[i + 1, j + 1] = brickCounter;
                        brickCounter++;
                    }
                }
            }
            return outputWall;
        }

        //prints the second layer onto the console
        public void PrintOutputWall( int[,] outputWall, int M, int N)
        {
            //Contains the string that will be outputed
            string[] output = new string[M * 2 + 1];
            output[0] = new string('*', N * 2 + 1);
            //Contains the current top row
            StringBuilder outputTopRow = new StringBuilder();
            //Contains the current bottom row
            StringBuilder outputBottomRow = new StringBuilder();//Contains the current bottom row
            for (int i = 0; i < M; i++)
            {
                outputTopRow.Append("*");
                outputBottomRow.Append("*");

                for (int j = 0; j < N; j++)
                {
                    outputTopRow.Append(outputWall[i, j].ToString());
                    if (j + 1 < N)
                    {
                        if (outputWall[i, j] == outputWall[i, j + 1])
                        {
                            outputTopRow.Append(" ");
                        }
                        else
                        {
                            outputTopRow.Append("*");
                        }
                    }
                    else
                    {
                        outputTopRow.Append("*");
                    }
                    if (i + 1 < M)
                    {
                        if (outputWall[i, j] == outputWall[i + 1, j])
                        {
                            outputBottomRow.Append(" ");
                        }
                        else
                        {
                            outputBottomRow.Append("*");
                        }
                    }
                    else
                    {
                        outputBottomRow.Append("*");
                    }
                    outputBottomRow.Append("*");
                }
                output[i * 2 + 1] = outputTopRow.ToString();
                output[i * 2 + 2] = outputBottomRow.ToString();
                outputTopRow.Clear();
                outputBottomRow.Clear();
            }

            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
        }

    }
}
