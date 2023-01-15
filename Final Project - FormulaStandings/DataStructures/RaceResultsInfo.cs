using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FormulaStandings
{
    public class RaceResultsInfo
    {
        public int position { get; set; }
        public int points { get; set; }
        public string driver { get; set; }
        public string driverCode { get; set; }
        public string nationality { get; set; }
        public string constructor { get; set; }
        public string time { get; set; }

        public override string ToString()
        {
            return String.Format("{0},{1}-{2}", driver, nationality, constructor);
        }
    }
}