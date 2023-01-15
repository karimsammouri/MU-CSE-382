using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XAML
{
    public partial class NumberPad : ContentPage
    {
        public NumberPad()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            if (cLabel.Text != "0")
                cLabel.Text = cLabel.Text + button.Text;
            else
                cLabel.Text = button.Text;
        }
        void Clear_Clicked(System.Object sender, System.EventArgs e)
        {
            cLabel.Text = "0";
        }
    }
}
