using System;
using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Reflection;
using System.Threading.Tasks;

namespace USTaxes
{
    public class MainPage : ContentPage
    {
        Label amountLabel;
        Entry amountEntry;
        Label cityLabel;
        Entry cityEntry;
        Label stateLabel;
        Entry stateEntry;
        Label queryLabel;
        Picker queryPicker;
        Button button;
        List<Location> result;
        ListView listView;
        Task readFile;

        public MainPage()
        {
            amountLabel = new Label
            {
                Text = "Average Tax Return",
                Padding = new Thickness(5, 0, 0, 0)
            };
            amountEntry = new Entry();
            cityLabel = new Label
            {
                Text = "City",
                Padding = new Thickness(5, 3, 0, 0)
            };
            cityEntry = new Entry();
            stateLabel = new Label
            {
                Text = "State",
                Padding = new Thickness(5, 3, 0, 0)
            };
            stateEntry = new Entry();

            queryLabel = new Label
            {
                Text = "Query Type",
                Padding = new Thickness(5, 3, 0, 0)
            };
            queryPicker = new Picker();
            List<string> pickerOptions = new List<string>();
            pickerOptions.Add("Zip codes with equivalent return");
            pickerOptions.Add("Zip codes in city-state");
            queryPicker.ItemsSource = pickerOptions;

            button = new Button { Text = "Query" };
            button.Clicked += OnClicked;

            result = new List<Location>();
            listView = new ListView();
            listView.BackgroundColor = Color.WhiteSmoke;
            listView.Margin = new Thickness(5, 0, 5, 0);
            listView.ItemsSource = result;

            StackLayout topLevel = new StackLayout
            {
                Padding = new Thickness(10, 55, 10, 0),
                BackgroundColor = Color.WhiteSmoke
            };
            topLevel.Children.Add(amountLabel);
            topLevel.Children.Add(amountEntry);
            topLevel.Children.Add(cityLabel);
            topLevel.Children.Add(cityEntry);
            topLevel.Children.Add(stateLabel);
            topLevel.Children.Add(stateEntry);
            topLevel.Children.Add(queryLabel);
            topLevel.Children.Add(queryPicker);
            topLevel.Children.Add(button);
            topLevel.Children.Add(listView);
            Content = topLevel;
        }

        public void OnClicked(object sender, EventArgs e)
        {
            string selectedOption = (string)queryPicker.SelectedItem;
            result = new List<Location>();
            if (selectedOption == "Zip codes with equivalent return")
            {
                try
                {
                    int amount = Convert.ToInt32(amountEntry.Text);
                    if (amount > 0)
                    {
                        readFile = ReadFileAmount("zipcodes.tsv", amount);
                        ConfigureListView();
                    }
                    else
                    {
                        amountEntry.Text = "Please enter a valid dollar amount";
                    }
                }
                catch
                {
                    amountEntry.Text = "Please enter a valid dollar amount";
                }
            }
            else if (selectedOption == "Zip codes in city-state")
            {
                try
                {
                    string city = cityEntry.Text.ToUpper();
                    string state = stateEntry.Text.ToUpper();
                    if (city != "" && state != "")
                    {
                        readFile = ReadFileCityState("zipcodes.tsv", city, state);
                        ConfigureListView();
                    }
                }
                catch
                {
                    cityEntry.Text = "Please enter a valid city";
                    stateEntry.Text = "Please enter a valid state";
                }
            }
        }

        public async Task ReadFileCityState(string fileName, string city,
            string state)
        {
            var assembly =
                IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            string namespaceName = "USTaxes";
            Stream stream =
                assembly.GetManifestResourceStream(namespaceName + "." +
                fileName);
            using (var input = new StreamReader(stream))
            {
                input.ReadLine(); // to skip header
                while (!input.EndOfStream)
                {
                    string line = await input.ReadLineAsync();
                    string[] toks = line.Split('\t');
                    string cityCol = toks[3];
                    string stateCol = toks[4];
                    string taxReturnsFiled = toks[16];
                    string totalWages = toks[18];
                    if (taxReturnsFiled != "" && totalWages != "")
                    {
                        if (cityCol.Equals(city) &&
                        stateCol.Equals(state))
                        {
                            int taxReturnsFiledDouble =
   Convert.ToInt32(taxReturnsFiled);
                            int totalWagesDouble =
                                Convert.ToInt32(totalWages);
                            int averageReturn =
                                totalWagesDouble / taxReturnsFiledDouble;
                            result.Add(new Location(Convert.ToInt32(toks[1]),
                                    city, state, averageReturn));
                        }
                    }
                }
            }
        }

        public async Task ReadFileAmount(string fileName, int amount)
        {
            var assembly =
                IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            string namespaceName = "USTaxes";
            Stream stream =
                assembly.GetManifestResourceStream(namespaceName + "." +
                fileName);
            using (var input = new StreamReader(stream))
            {
                input.ReadLine(); // to skip header
                int previousZip = 0;
                while (!input.EndOfStream)
                {
                    string line = await input.ReadLineAsync();
                    string[] toks = line.Split('\t');
                    string taxReturnsFiled = toks[16];
                    string totalWages = toks[18];
                    int currentZip = Convert.ToInt32(toks[1]);
                    if (taxReturnsFiled != "" && totalWages != "")
                    {
                        int taxReturnsFiledDouble =
                            Convert.ToInt32(taxReturnsFiled);
                        int totalWagesDouble =
                            Convert.ToInt32(totalWages);
                        int averageReturn =
                            totalWagesDouble / taxReturnsFiledDouble;
                        if (currentZip != previousZip &&
                            averageReturn - 100 <= amount &&
                            averageReturn + 100 >= amount)
                        {
                            result.Add(new Location(Convert.ToInt32(toks[1]),
                                toks[3], toks[4], averageReturn));
                        }
                    }
                    previousZip = currentZip;
                }
            }
            result.Sort((x, y) => x.zipCode.CompareTo(y.zipCode));
        }

        public void ConfigureListView()
        {
            //lv = new ListView { HeightRequest = 200 };
            listView.ItemsSource = new List<Location>(result);
            listView.ItemTemplate = new DataTemplate(() =>
            {
                // Create views with bindings for displaying each property.v
                Label zipCode = new Label();
                zipCode.SetBinding(Label.TextProperty, "zipCode");
                zipCode.FontAttributes = FontAttributes.Bold;
                zipCode.FontSize = 16;

                Label city = new Label();
                city.SetBinding(Label.TextProperty, "city");
                city.FontSize = 16;

                Label state = new Label();
                state.SetBinding(Label.TextProperty, "state");
                state.FontSize = 16;

                Label averageReturn = new Label();
                averageReturn.SetBinding(Label.TextProperty, "averageReturn");
                averageReturn.FontSize = 16;

                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { zipCode, city, state, averageReturn }
                    }
                };
            });
        }
    }

    public class Location
    {
        public int zipCode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int averageReturn { get; set; }

        public Location(int zipCode, string city, string state,
            int averageReturn)
        {
            this.zipCode = zipCode;
            this.city = city;
            this.state = state;
            this.averageReturn = averageReturn;
        }

        public override string ToString()
        {
            return "" + zipCode + " " + city + " " + state + " " +
                averageReturn;

        }
    }
}

