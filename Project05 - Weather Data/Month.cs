using System;
namespace WeatherData
{
    public class Month
    {
        public String month { get; set; }
        public double temperatureSum { get; set; }
        public int entryTotal { get; set; }
        public double averageTemperature { get; set; }
        public string imageName { get; set; }

        public Month(String month)
        {
            this.month = month;
        }

        public void AverageTemperature()
        {
            averageTemperature = temperatureSum / entryTotal;
            if (averageTemperature < 40)
            {
                imageName = "cold.png";
            }
            else if (averageTemperature >= 80)
            {
                imageName = "hot.png";
            }
            else
            {
                imageName = "avg.png";
            }
        }
    }
}