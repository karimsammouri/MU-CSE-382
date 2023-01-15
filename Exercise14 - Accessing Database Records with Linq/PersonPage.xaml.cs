using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBSetup {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonPage : ContentPage {
		DataTemplate longTemplate, shortTemplate;
		public PersonPage() {
			InitializeComponent();
		}
		protected override void OnAppearing() {
			base.OnAppearing();
			longTemplate = CreateLongTemplate();
			shortTemplate = CreateShortTemplate();
			var theTable = MainPage.conn.Table<CreateDB.Person>();
			FormatToggled(null, null);
		}
		DataTemplate CreateLongTemplate() {
			DataTemplate r = new DataTemplate(() => {
				Label nameLabel = new Label {
					FontAttributes = FontAttributes.Bold,
					FontSize = 20, HorizontalTextAlignment = TextAlignment.Center,
					TextColor = Color.Green
				};
				nameLabel.SetBinding(Label.TextProperty, "Name");

				Label dobLabel = new Label { FontSize = 12 };
				dobLabel.SetBinding(Label.TextProperty, "DOBShortString");

				Label quoteLabel = new Label { FontSize = 12, FontAttributes = FontAttributes.Italic,
												VerticalOptions = LayoutOptions.StartAndExpand };
				quoteLabel.SetBinding(Label.TextProperty, "FamousQuote");

				Grid grid = new Grid { VerticalOptions = LayoutOptions.FillAndExpand };
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80, GridUnitType.Absolute) });
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				grid.Children.Add(nameLabel, 0, 2, 0, 1);
				grid.Children.Add(dobLabel, 0, 1);
				grid.Children.Add(quoteLabel, 1, 1);
				return new ViewCell {
					View = grid
				};
			});
			return r;
		}
		DataTemplate CreateShortTemplate() {
			DataTemplate r = new DataTemplate(() => {
				Label nameLabel = new Label();
				nameLabel.SetBinding(Label.TextProperty, "Item1");
				nameLabel.FontSize = 16;
				nameLabel.TextColor = Color.Green;

				Label quoteLabel = new Label();
				quoteLabel.SetBinding(Label.TextProperty, "Item2");
				quoteLabel.FontSize = 10;
				quoteLabel.FontAttributes = FontAttributes.Italic;
				quoteLabel.TextColor = Color.Black;

				Grid grid = new Grid();
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(300, GridUnitType.Absolute) });
				grid.Children.Add(nameLabel, 0, 0);
				grid.Children.Add(quoteLabel, 1, 0);
				return new ViewCell {
					View = grid
				};
			});
			return r;
		}
		private void PersonSelectedLong(object sender, SelectedItemChangedEventArgs e) {
			CreateDB.Person person = (CreateDB.Person)e.SelectedItem;
			if (person != null) {
                webview.Source = new UrlWebViewSource { Url = person.URL };
            }
        }
		private void PersonSelectedShort(object sender, SelectedItemChangedEventArgs e) {
			Tuple<string, string, string> tuple = (Tuple<string, string, string>)e.SelectedItem;
			if (tuple != null) {
				webview.Source = new UrlWebViewSource { Url = tuple.Item3 };
            }
        }
		private void FormatToggled(object sender, ToggledEventArgs e) {
			var theTable = MainPage.conn.Table<CreateDB.Person>();
			if (longFormat.IsToggled) {
				lv.ItemSelected += PersonSelectedLong;
				lv.ItemSelected -= PersonSelectedShort;
				lv.ItemsSource = theTable.ToList();
				lv.ItemTemplate = longTemplate;
				formatLabel.Text = "Long format";
			} else {
				lv.ItemSelected -= PersonSelectedLong;
				lv.ItemSelected += PersonSelectedShort;
				lv.ItemsSource = theTable.Select(p => new Tuple<string, string, string>(p.Name, p.FamousQuote, p.URL)).ToList();
				lv.ItemTemplate = shortTemplate;
                formatLabel.Text = "Short format";
            }
        }
	}
}