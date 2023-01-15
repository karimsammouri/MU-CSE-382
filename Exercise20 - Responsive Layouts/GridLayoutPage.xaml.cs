using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResponsiveLayouts {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GridLayoutPage : ContentPage {
		private bool? currentOrientationLandscape;
		public GridLayoutPage() {
			InitializeComponent();
		}
		protected override void OnSizeAllocated(double width, double height) {
			base.OnSizeAllocated(width, height);
			bool isNowLandscape = width > height;
			if (currentOrientationLandscape.HasValue && isNowLandscape == currentOrientationLandscape)
				return;

            currentOrientationLandscape = isNowLandscape;
            if (isNowLandscape) {
                innerGrid.RowDefinitions.Clear();
                innerGrid.ColumnDefinitions.Clear();
                innerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                innerGrid.Children.Remove(controlsGrid);
                innerGrid.Children.Add(controlsGrid, 1, 0);
            } else {
                innerGrid.RowDefinitions.Clear();
                innerGrid.ColumnDefinitions.Clear();
                innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                innerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                innerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                innerGrid.Children.Remove(controlsGrid);
                innerGrid.Children.Add(controlsGrid, 0, 1);
            }
        }
    }
}