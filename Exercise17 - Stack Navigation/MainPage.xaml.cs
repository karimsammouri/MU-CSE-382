using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StackNavigation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
        PrivacyPage privacyPage;
        UnitsPage unitsPage;
        AboutPage aboutPage;
        LicensesPage licensesPage;

        async void PrivacyBtnClicked(System.Object sender, System.EventArgs e)
        {
            privacyPage = new PrivacyPage();
            await Navigation.PushAsync(privacyPage, true);
        }

        async void UnitsBtnClicked(System.Object sender, System.EventArgs e)
        {
            unitsPage = new UnitsPage();
            await Navigation.PushAsync(unitsPage, true);
        }

        async void AboutBtnClicked(System.Object sender, System.EventArgs e)
        {
            aboutPage = new AboutPage();
            await Navigation.PushModalAsync(aboutPage, true);
        }

        async void LicensesBtnClicked(System.Object sender, System.EventArgs e)
        {
            licensesPage = new LicensesPage();
            await Navigation.PushAsync(licensesPage, true);
        }
    }
}

