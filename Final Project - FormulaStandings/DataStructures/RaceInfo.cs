using System;

namespace FormulaStandings
{
    public class RaceInfo
    {
        public int round { get; set; }
        public string dateMonth { get; set; }
        public string dateDay { get; set; }
        public string country { get; set; }
        public string circuit { get; set; }

        public override string ToString()
        {
            return String.Format("{0},{1}-{2}", round, country, circuit);
        }
    }
}

