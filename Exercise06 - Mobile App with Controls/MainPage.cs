// I have successfully completed all requirements of this project.

using System;
using Xamarin.Forms;

namespace SecondApp
{
    class MainPage : ContentPage
    {
        Label result;
        Label number1Label;
        Entry number1;
        Label number2Label;
        Entry number2;
        Button sum;

        Label datePickerLabel;
        DatePicker datePicker;

        Label switchLabel;
        Switch switchToggle;

        Label stepperLabel;
        Stepper stepper;

        Label sliderLabel;
        Slider slider;

        Label progressLabel;
        ProgressBar progress;

        public MainPage()
        {
            result = new Label() {  Text = "0" };
            number1Label = new Label() { Text = "First Number" };
            number1 = new Entry();
            number2Label = new Label() { Text = "Second Number" };
            number2 = new Entry();
            sum = new Button();
            sum.Text = "Sum numbers";

            datePickerLabel = new Label() { Text = "Date Picker" };
            datePicker = new DatePicker();
            datePicker.Date = new DateTime(1999, 12, 13);

            switchLabel = new Label() { Text = "Switch" };
            switchToggle = new Switch();
            switchToggle.IsToggled = true;

            stepperLabel = new Label() { Text = "Stepper" };
            stepper = new Stepper();

            sliderLabel = new Label() { Text = "Slider" };
            slider = new Slider();

            progressLabel = new Label() { Text = "Progress Bar" };
            progress = new ProgressBar();

            StackLayout panel = new StackLayout();

            panel.Padding = new Thickness(30, 30, 30, 30);
            panel.Children.Add(result);
            panel.Children.Add(number1Label);
            panel.Children.Add(number1);
            panel.Children.Add(number2Label);
            panel.Children.Add(number2);
            panel.Children.Add(sum);

            panel.Children.Add(datePickerLabel);
            panel.Children.Add(datePicker);

            panel.Children.Add(switchLabel);
            panel.Children.Add(switchToggle);

            panel.Children.Add(stepperLabel);
            panel.Children.Add(stepper);

            panel.Children.Add(sliderLabel);
            panel.Children.Add(slider);

            panel.Children.Add(progressLabel);
            panel.Children.Add(progress);

            this.Content = panel;

            sum.Clicked += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            try
            {
                result.Text = Convert.ToString(Convert.ToInt32(number1.Text) +
                    Convert.ToInt32(number2.Text));
            }
            catch
            {
                result.Text = "Please insert two integers";
            }
        }
    }
}


