using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherData
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            DB.OpenConnection();
            var data = DB.conn.Table<WeatherInfo>().ToList();
            List<Year> years = new List<Year>();
            for (int i = 2015; i <= 2021; i++)
            {
                Year year = new Year(i);
                foreach (WeatherInfo weatherInfo in
                    data.Where(d => d.Date.Year == i).ToList())
                {
                    year.temperatureSum += weatherInfo.Temperature;
                    year.entryTotal += 1;
                }
                year.AverageTemperature();
                years.Add(year);
            }
            lv.ItemsSource = years;
        }
        YearPage page;

        async void lv_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Year year = (Year)e.Item;
            page = new YearPage(year.year.ToString());
            await Navigation.PushAsync(page, true);
        }
    }
}

