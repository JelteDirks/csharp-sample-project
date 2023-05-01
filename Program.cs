// See https://aka.ms/new-console-template for more information
//Implements some basic functions
using System;
public class Trilateration
{
    //2D Array of Anchors: {x-coordindate, y-coordinate, range of anchor}
    //2D arrays are created with a comma in brackets [,]
    public static int[,] anchors = { { 2, 1, 5 }, { 6, 3, 3 }, { 3, 7, 4 } };

    //2D array of Points: {x-coordinate, y-coordinate}
    public int[,] points = { { 0, 0 }, { 8, 2 }, { 2, 10 }, { 4, 4 }, { 0, 5 }, { 3, 3 }, { 8, 0 }, { 4, 5 } };
    public void calculate(int[,] points)
    {
        //Loop over points
        for (int i = 0; i < points.GetLength(0); i++)
        {

            //Output string
            string output = "The point " + i + " lies in ";
            double shortestDist = -1;
            int shortestAnc = -1;

            //Loop over anchors
            for (int j = 0; j < anchors.GetLength(0); j++)
            {
                int[] a = { anchors[j, 0], anchors[j, 1], anchors[j, 2] };
                int[] p = { points[i, 0], points[i, 1] };

                //Calculating distance between the point and anchor
                double dist = CalculateDistance(a, p);
                if (dist <= anchors[j, 2])
                {
                    output += "anchor " + j;
                    if (j != 2)
                    {
                        output += ", ";
                    }
                    else
                    {
                        output += ". ";
                    }

                    if ((shortestDist == -1) || (dist < shortestDist))
                    {
                        shortestDist = dist;
                        shortestAnc = j;
                    }
                }
            }
            if (shortestDist != -1)
            {
                output += "The anchor with the strongest signal is anchor " + shortestAnc + ".";
            }
            else
            {
                output = "The point " + i + " does not lie in any anchor's coverage.";
            }
            Console.WriteLine(output);
        }
    }
    //Function to calculate the distance (x^2 + y^2 = z^2)
    public double CalculateDistance(int[] anchor, int[] point)
    {
        int x2 = Square(Math.Abs(anchor[0] - point[0]));
        int y2 = Square(Math.Abs(anchor[1] - point[1]));
        int z2 = x2 + y2;
        double distance = Math.Sqrt(z2);
        return distance;
    }
    int Square(int a)
    {
        return a * a;
    }

    //Main args method with object instance
    static void Main(string[] args)
    {
        Trilateration hospital = new Trilateration();
        hospital.calculate(hospital.points);

    }
}


