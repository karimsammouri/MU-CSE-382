// I have successfully completed all the requirements of this project.

using System;

using Xamarin.Forms;

namespace LayoutDemo
{
    public class MainPage : ContentPage
    {
        Entry entry;
        Label entryLabel;

        int buttonPresses = 0;
        Button button;
        Label buttonLabel;

        Switch switchToggle;
        Label switchLabel;

        CheckBox checkBox;
        Label checkBoxLabel;

        Stepper stepper;
        Label stepperLabel;

        Slider slider;
        Label sliderLabel;

        public MainPage()
        {
            entry = new Entry();
            entry.WidthRequest = 70;
            entryLabel = new Label { Text = "0" };
            entry.TextChanged += entryChanged;

            button = new Button { Text = "Click me" };
            buttonLabel = new Label { Text = "0" };
            button.Clicked += OnClicked;

            switchToggle = new Switch { IsToggled = true };
            switchLabel = new Label { Text = "on" };
            switchToggle.Toggled += OnToggled;

            checkBox = new CheckBox { IsChecked = true };
            checkBoxLabel = new Label { Text = "checked" };
            checkBox.CheckedChanged += OnChecked;

            stepper = new Stepper
            {
                Value = 0.5,
                Increment = 0.1,
                Minimum = 0,
                Maximum = 1
            };
            stepperLabel = new Label { Text = "0.5" };
            stepper.ValueChanged += OnValueChangedStepper;

            slider = new Slider
            {
                Value = 0.5,
                Minimum = 0,
                Maximum = 1,
                WidthRequest = 300
            };
            sliderLabel = new Label { Text = "0.5" };
            slider.ValueChanged += OnValueChangedSlider;

            StackLayout entryLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            entryLayout.Children.Add(entry);
            entryLayout.Children.Add(entryLabel);

            StackLayout buttonLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            buttonLayout.Children.Add(button);
            buttonLayout.Children.Add(buttonLabel);

            StackLayout switchLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            switchLayout.Children.Add(switchToggle);
            switchLayout.Children.Add(switchLabel);

            StackLayout checkBoxLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            checkBoxLayout.Children.Add(checkBox);
            checkBoxLayout.Children.Add(checkBoxLabel);

            StackLayout stepperLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            stepperLayout.Children.Add(stepper);
            stepperLayout.Children.Add(stepperLabel);

            StackLayout sliderLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            sliderLayout.Children.Add(slider);
            sliderLayout.Children.Add(sliderLabel);

            StackLayout topLevel = new StackLayout();
            topLevel.Children.Add(entryLayout);
            topLevel.Children.Add(buttonLayout);
            topLevel.Children.Add(switchLayout);
            topLevel.Children.Add(checkBoxLayout);
            topLevel.Children.Add(stepperLayout);
            topLevel.Children.Add(sliderLayout);

            this.Content = topLevel;
        }

        private void entryChanged(object sender, TextChangedEventArgs e)
        {
            entryLabel.Text = Convert.ToString(entry.Text.Length);
        }

        private void OnClicked(object sender, EventArgs e)
        {
            buttonPresses++;
            buttonLabel.Text = Convert.ToString(buttonPresses);
        }

        private void OnToggled(object sender, ToggledEventArgs e)
        {
            if (switchLabel.Text.Equals("on"))
                switchLabel.Text = "off";
            else
                switchLabel.Text = "on";
        }

        private void OnChecked(object sender, CheckedChangedEventArgs e)
        {
            if (checkBoxLabel.Text.Equals("checked"))
                checkBoxLabel.Text = "unchecked";
            else
                checkBoxLabel.Text = "checked";
        }

        private void OnValueChangedStepper(object sender, ValueChangedEventArgs e)
        {
            stepperLabel.Text = Convert.ToString(stepper.Value);
        }

        private void OnValueChangedSlider(object sender, ValueChangedEventArgs e)
        {
            sliderLabel.Text = String.Format("{0:0.0}", slider.Value);
        }
    }
}

