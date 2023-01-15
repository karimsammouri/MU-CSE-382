using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResponsiveLayouts {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Device2Page : ContentPage {
		private View portraitLayout;
		private View landscapeLayout;
		public Device2Page() {

			if (Device.Idiom == TargetIdiom.Tablet) {
				StackLayout stackVert = new StackLayout { Orientation = StackOrientation.Vertical };
				stackVert.Children.Add(new Label { Text = "House 1", FontSize = 30, HorizontalOptions=LayoutOptions.Center });
				stackVert.Children.Add(new Image { Source = "house1.jpg" });
				stackVert.Children.Add(new Label { Text = "House 2", FontSize = 30, HorizontalOptions = LayoutOptions.Center });
				stackVert.Children.Add(new Image { Source = "house2.jpg" });
				portraitLayout = stackVert;

				Grid grid = new Grid {
					Padding = new Thickness(0, 40, 0, 0),
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.Center,
					Margin = new Thickness(10),
					RowDefinitions =
					{
						new RowDefinition { Height = GridLength.Auto },
						new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					},
					ColumnDefinitions =
					{
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					}
				};

				grid.Children.Add(new Label { Text = "House 1", FontSize = 30, HorizontalOptions = LayoutOptions.Center }, 0, 0);
				grid.Children.Add(new Label { Text = "House 2", FontSize = 30, HorizontalOptions = LayoutOptions.Center }, 1, 0);
				grid.Children.Add(new Image { Source = "house1.jpg" }, 0, 1);
				grid.Children.Add(new Image { Source = "house2.jpg" }, 1, 1);
				landscapeLayout = grid;
			} else {
				StackLayout stackVert = new StackLayout { Orientation = StackOrientation.Vertical };
				stackVert.Children.Add(new Image { Source = "house1.jpg" });
				stackVert.Children.Add(new Image { Source = "house2.jpg" });
				portraitLayout = stackVert;

				StackLayout stackHorz = new StackLayout { Orientation = StackOrientation.Horizontal };
				stackHorz.Children.Add(new Image { Source = "house1.jpg" });
				stackHorz.Children.Add(new Image { Source = "house2.jpg" });
				landscapeLayout = stackHorz;
			}
		}
		protected override void OnSizeAllocated(double width, double height) {
			base.OnSizeAllocated(width, height);
			bool isNowLandscape = width > height;
			if (isNowLandscape) {
				Content = landscapeLayout;
			} else {
				Content = portraitLayout;
			}
		}
	}
}