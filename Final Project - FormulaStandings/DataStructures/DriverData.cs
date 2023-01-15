using System;
using System.Collections.Generic;

namespace FormulaStandings
{
    public class DriverData
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
            public StandingsTable StandingsTable { get; set; }
        }

        public class StandingsTable
        {
            public string season { get; set; }
            public List<StandingsList> StandingsLists { get; set; }
        }

        public class StandingsList
        {
            public string season { get; set; }
            public string round { get; set; }
            public List<DriverStanding> DriverStandings { get; set; }
        }

        public class DriverStanding
        {
            public int position { get; set; }
            public string positionText { get; set; }
            public int points { get; set; }
            public int wins { get; set; }
            public Driver Driver { get; set; }
            public List<Constructor> Constructors { get; set; }
        }

        public class Constructor
        {
            public string constructorId { get; set; }
            public string url { get; set; }
            public string name { get; set; }
            public string nationality { get; set; }
        }

        public class Driver
        {
            public string driverId { get; set; }
            public int permanentNumber { get; set; }
            public string code { get; set; }
            public string url { get; set; }
            public string givenName { get; set; }
            public string familyName { get; set; }
            public string dateOfBirth { get; set; }
            public string nationality { get; set; }
        }
    }
}

