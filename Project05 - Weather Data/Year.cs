using System;
namespace WeatherData
{
    public class Year
    {
        public int year { get; set; }
        public double temperatureSum { get; set; }
        public int entryTotal { get; set; }
        public double averageTemperature { get; set; }

        public Year(int year)
        {
            this.year = year;
        }

        public void AverageTemperature()
        {
            averageTemperature = temperatureSum / entryTotal;
        }
    }
}

