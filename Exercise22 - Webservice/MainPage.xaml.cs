using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TimeZone
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(city.Text))
            {
                string uriRequest = GenerateRequestUri(Constants.TimeZoneDBEndPoint, city.Text);
                TimeZone data = await _restService.GetTimeZoneData(uriRequest);
                zoneName.Text = data.ZoneName;
                abbreviation.Text = data.Abbreviation;
                gmtOffset.Text = data.GMTOffset;
            }
        }

        string GenerateRequestUri(string endpoint, string city)
        {
            string requestUri = endpoint;
            requestUri += $"?key={Constants.TimeZoneDBAPIKey}";
            requestUri += "&format=json";
            requestUri += "&by=zone";
            requestUri += $"&zone=America/{city}";
            return requestUri;
        }
    }
}

