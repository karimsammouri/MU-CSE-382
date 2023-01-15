using System;
namespace Distance
{
    public class Distance
    {
        public static void Main(String[] args)
        {
            USLocations.USLocations locations = new
                    USLocations.USLocations("zipcodes.tsv");
            while (true)
            {
                Console.Write("distance> ");
                string input = Console.ReadLine();
                if (input.Equals("exit"))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                string[] zips = input.Split(' ');
                int zip1 = Convert.ToInt32(zips[0]);
                int zip2 = Convert.ToInt32(zips[1]);
                double distanceKm = locations.Distance(zip1, zip2);
                double distanceMi = distanceKm * 0.62137;
                Console.WriteLine("The distance between {0} and {1} is {2:F2} " +
                    "miles ({3:F2} km)", zip1, zip2, distanceMi, distanceKm);
                Console.WriteLine();
            }
        }
    }
}

