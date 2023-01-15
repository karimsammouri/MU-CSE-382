using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResponsiveLayouts {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasicLayoutPage : ContentPage {
		private bool currentOrientationLandscape;
		public BasicLayoutPage() {
			InitializeComponent();
		}
		protected override void OnSizeAllocated(double width, double height) {
			base.OnSizeAllocated(width, height);
			bool isNowLandscape = width > height;
			if (isNowLandscape != currentOrientationLandscape)
            {
				layout.Orientation = isNowLandscape ? StackOrientation.Horizontal : StackOrientation.Vertical;
                currentOrientationLandscape = isNowLandscape;
            }
        }
	}
}