using System;
using static FormulaStandings.RaceData;
using static FormulaStandings.RaceResultsData;

namespace FormulaStandings
{
    public class DriverInfo
    {
        public int position { get; set; }
        public int points { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public string constructor { get; set; }

        public override string ToString()
        {
            return String.Format("{0},{1}-{2}", name, nationality, constructor);
        }
    }
}

