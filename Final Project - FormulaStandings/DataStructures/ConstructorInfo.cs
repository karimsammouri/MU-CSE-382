using System;

namespace FormulaStandings
{
    public class ConstructorInfo
    {
        public int position { get; set; }
        public int points { get; set; }
        public string name { get; set; }
        public int wins { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
