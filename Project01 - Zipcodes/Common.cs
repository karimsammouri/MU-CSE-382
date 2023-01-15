using System;
namespace Common
{
    public class Common
    {
        public static void Main(String[] args)
        {
            USLocations.USLocations locations = new
                    USLocations.USLocations("zipcodes.tsv");
            while (true)
            {
                Console.Write("commons> ");
                string input = Console.ReadLine();
                if (input.Equals("exit"))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                string[] states = input.Split(' ');
                string state1 = states[0];
                string state2 = states[1];
                ISet<string> commons = locations.GetCommonCityNames(state1, state2);
                foreach (string common in commons)
                {
                    Console.WriteLine(common);
                }
                Console.WriteLine();
            }
        }
    }
}

