using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXAML
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new MyXAMLPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

