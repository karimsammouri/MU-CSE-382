// I have successfully completed all requirements of this project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PickerDemo
{
	public class School
    {
		public string name;
		public string url;

		public School(string n, string u)
        {
			name = n;
			url = u;
        }

        public override string ToString()
        {
            return name;
        }
    }
	public class MainPage : ContentPage
	{
		Picker picker;
        WebView webView;
        const string DEFAULT_URL = "https://www.miamioh.edu";

        public MainPage()
		{
			List<School> schools = new List<School>();
			schools.Add(new School("Miami", "https://miamioh.edu/"));
            schools.Add(new School("OSU", "https://www.osu.edu/"));
            schools.Add(new School("UC", "https://www.uc.edu/"));
            schools.Add(new School("OU", "https://www.ohio.edu/"));

            picker = new Picker();
            picker.ItemsSource = schools;
            picker.SelectedIndex = 0;
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = DEFAULT_URL
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            StackLayout panel = new StackLayout();
			panel.Children.Add(picker);
            panel.Children.Add(webView);

			Content = panel;
		}
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            School school = (School)picker.SelectedItem;
            webView.Source = new UrlWebViewSource
            {
                Url = school.url
            };
        }
	}
}
