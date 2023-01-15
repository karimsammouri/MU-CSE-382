using System;
using System.Collections.Generic;

namespace FormulaStandings
{
    public class RaceData
    {
        public class Root
        {
            public MRData MRData { get; set; }
        }

        public class MRData
        {
            public string xmlns { get; set; }
            public string series { get; set; }
            public string url { get; set; }
            public string limit { get; set; }
            public string offset { get; set; }
            public string total { get; set; }
            public RaceTable RaceTable { get; set; }
        }

        public class RaceTable
        {
            public string season { get; set; }
            public List<Race> Races { get; set; }
        }

        public class Race
        {
            public string season { get; set; }
            public int round { get; set; }
            public string url { get; set; }
            public string raceName { get; set; }
            public Circuit Circuit { get; set; }
            public DateTime date { get; set; }
            public string time { get; set; }
            public FirstPractice FirstPractice { get; set; }
            public SecondPractice SecondPractice { get; set; }
            public ThirdPractice ThirdPractice { get; set; }
            public Qualifying Qualifying { get; set; }
            public Sprint Sprint { get; set; }
        }

        public class Circuit
        {
            public string circuitId { get; set; }
            public string url { get; set; }
            public string circuitName { get; set; }
            public Location Location { get; set; }
        }

        public class FirstPractice
        {
            public string date { get; set; }
            public string time { get; set; }
        }

        public class SecondPractice
        {
            public string date { get; set; }
            public string time { get; set; }
        }

        public class ThirdPractice
        {
            public string date { get; set; }
            public string time { get; set; }
        }

        public class Qualifying
        {
            public string date { get; set; }
            public string time { get; set; }
        }

        public class Sprint
        {
            public string date { get; set; }
            public string time { get; set; }
        }

        public class Location
        {
            public string lat { get; set; }
            public string @long { get; set; }
            public string locality { get; set; }
            public string country { get; set; }
        }
    }
}

