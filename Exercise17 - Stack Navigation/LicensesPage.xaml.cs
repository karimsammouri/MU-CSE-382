using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StackNavigation
{
    public partial class LicensesPage : ContentPage
    {
        public LicensesPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        XamarinPage xamarinPage;
        JavaPage javaPage;

        async void XamarinBtnClicked(System.Object sender, System.EventArgs e)
        {
            xamarinPage = new XamarinPage();
            await Navigation.PushAsync(xamarinPage, true);
        }

        async void JavaBtnClicked(System.Object sender, System.EventArgs e)
        {
            javaPage = new JavaPage();
            await Navigation.PushAsync(javaPage, true);
        }
    }
}