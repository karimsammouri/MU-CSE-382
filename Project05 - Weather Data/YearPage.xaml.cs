using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace WeatherData
{
    public partial class YearPage : ContentPage
    {
        public YearPage(String year)
        {
            InitializeComponent();
            var data = DB.conn.Table<WeatherInfo>().ToList();
            List<Month> months = new List<Month>();
            List<String> monthsStr = new List<String> { "Jan", "Feb", "Mar",
                "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            int monthIndex = 1;
            foreach (String monthStr in monthsStr)
            {
                Month month = new Month(monthStr);
                foreach (WeatherInfo weatherInfo in
                    data.Where(d => d.Date.Year.ToString() == year &&
                    d.Date.Month == monthIndex).ToList())
                {
                    month.temperatureSum += weatherInfo.Temperature;
                    month.entryTotal += 1;
                }
                month.AverageTemperature();
                months.Add(month);
                monthIndex++;
            }
            lv.ItemsSource = months;
        }
    }
}