using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ListViewCSTemplate {
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum |
                    AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property |
                    AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public sealed class PreserveAttribute : Attribute {
        public bool AllMembers;
        public bool Conditional;
    }

    [Preserve(AllMembers = true)]

    public class School {
        public string Name { get; set; }
        public string WebsiteURL { get; set; }
        public Color SchoolColor { get; set; }
        public Color School2ndColor { get; set; }
    }

    public class MainPage : ContentPage {
        // The default iOS configuration of WebView requires https sites.
        public ObservableCollection<School> schoolList = new ObservableCollection<School> {
                new School { Name="Miami", WebsiteURL="https://www.miamioh.edu", SchoolColor=Color.Red, School2ndColor= Color.Black},
                new School { Name="Ohio State", WebsiteURL="https://www.osu.edu", SchoolColor=Color.Red, School2ndColor=Color.Gray},
                new School { Name="U. Cincinnati", WebsiteURL="https://www.uc.edu", SchoolColor=Color.Red, School2ndColor=Color.Black },
                new School { Name="Ohio", WebsiteURL="https://www.ohio.edu", SchoolColor=Color.Green, School2ndColor=Color.Gold },
        };

        ListView listView;
        String[] colors = { "Red", "Green", "Blue", "Cyan", "Yellow", "Black", "Purple", "Gray" };
        Picker colorPicker1, colorPicker2;
        Entry name, url;
        WebView webView;
        Label selectedSchool;
        public MainPage() {

            ConfigureListView2(out listView, schoolList);

            StackLayout topLevelPanel = new StackLayout();

            StackLayout newSchoolPanel = new StackLayout { Orientation = StackOrientation.Horizontal };
            StackLayout schoolColorPanel = new StackLayout { Orientation = StackOrientation.Horizontal };
            name = new Entry { Text = "some school", WidthRequest = 150, FontSize = 14 };
            url = new Entry { Text = "www.school.edu", WidthRequest = 150, FontSize = 14 };
            colorPicker1 = new Picker { WidthRequest = 150, FontSize = 14 };
            colorPicker2 = new Picker { WidthRequest = 150, FontSize = 14 };
            colorPicker1.ItemsSource = colorPicker2.ItemsSource = colors;
            colorPicker1.SelectedIndex = 0;
            colorPicker2.SelectedIndex = 1;
            Button addButton = new Button { Text = "Add", WidthRequest = 150 };
            addButton.Clicked += OnAddClicked;
            webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "https://www.osu.edu/"
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            newSchoolPanel.Children.Add(name);
            newSchoolPanel.Children.Add(url);
            schoolColorPanel.Children.Add(colorPicker1);
            schoolColorPanel.Children.Add(colorPicker2);
            newSchoolPanel.Children.Add(addButton);

            listView.SelectedItem = schoolList[1];
            selectedSchool = new Label { Text = schoolList[1].Name };

            topLevelPanel.Children.Add(newSchoolPanel);
            topLevelPanel.Children.Add(schoolColorPanel);
            topLevelPanel.Children.Add(addButton);
            topLevelPanel.Children.Add(listView);
            topLevelPanel.Children.Add(webView);
            topLevelPanel.Children.Add(selectedSchool);

            listView.ItemTapped += ListView_ItemTapped;
            topLevelPanel.Padding = new Thickness(0, 40, 0, 0);

            Content = topLevelPanel;
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) {
            selectedSchool.Text = ((School)e.Item).WebsiteURL;
            webView.Source = new UrlWebViewSource { Url = ((School)e.Item).WebsiteURL };
        }
        private void OnAddClicked(object sender, EventArgs e) {
            var converter = new ColorTypeConverter();
            Color firstColor = (Color)converter.ConvertFromInvariantString((string)colorPicker1.SelectedItem);
            Color secondColor = (Color)converter.ConvertFromInvariantString((string)colorPicker2.SelectedItem);
            schoolList.Add(new School {
                Name = name.Text,
                WebsiteURL = "https://" + url.Text,
                SchoolColor = firstColor,
                School2ndColor = secondColor
            });
        }
        public void ConfigureListView(out ListView lv, ObservableCollection<School> schools) {
            lv = new ListView { HeightRequest = 200 };
            lv.ItemsSource = schools;

            // Define template for displaying each item.
            // (Argument of DataTemplate constructor is called for 
            //      each item; it must return a Cell derivative.)
            lv.ItemTemplate = new DataTemplate(() => {
                // Create views with bindings for displaying each property.
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                nameLabel.FontSize = 16;

                BoxView mainColor = new BoxView();
                mainColor.SetBinding(BoxView.ColorProperty, "SchoolColor");
                mainColor.HeightRequest = mainColor.WidthRequest = 10;

                BoxView secondaryColor = new BoxView();
                secondaryColor.SetBinding(BoxView.ColorProperty, "School2ndColor");
                secondaryColor.HeightRequest = secondaryColor.WidthRequest = 10;

                // Return an assembled ViewCell.
                return new ViewCell {
                    View = new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                                new StackLayout {
                                    Children = {
                                        mainColor, secondaryColor,
                                    }
                                },
                                nameLabel,
                            }
                    }
                };
            });
        }
        public void ConfigureListView2(out ListView lv, ObservableCollection<School> schools)
        {
            lv = new ListView { HeightRequest = 200 };
            lv.ItemsSource = schools;

            // Define template for displaying each item.
            // (Argument of DataTemplate constructor is called for 
            //      each item; it must return a Cell derivative.)
            lv.ItemTemplate = new DataTemplate(() => {
                // Create views with bindings for displaying each property.
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                nameLabel.SetBinding(Label.TextColorProperty, "SchoolColor");
                nameLabel.SetBinding(Label.BackgroundColorProperty, "School2ndColor");
                nameLabel.FontSize = 16;

                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                                nameLabel
                        }
                    }
                };
            });
        }
    }
}
