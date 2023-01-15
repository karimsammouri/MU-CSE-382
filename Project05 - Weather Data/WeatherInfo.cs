using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherData
{
    public class WeatherInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", Date.ToString("MM/dd/yyyy"), Temperature);
        }
    }
}
