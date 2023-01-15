using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project3Calc
{
    public partial class MainPage : ContentPage
    {
        string operation = null;
        string num1 = "";
        string num2 = "";

        string memory = "0";

        string starting = "0";
        string years = "30";
        string rate = "5";
        string investment = "500";
        string frequency = "Monthly";
        int balance = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "0")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "0";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "0";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "0";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "0";
                        ResultLabel.Text = num2;
                    }
                }
            }
            if (button.Text == "1")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "1";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "1";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "1";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "1";
                        ResultLabel.Text = num2;
                    }
                }
            }
            if (button.Text == "2")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "2";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "2";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "2";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "2";
                        ResultLabel.Text = num2;
                    }
                }
            }
            if (button.Text == "3")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "3";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "3";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "3";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "3";
                        ResultLabel.Text = num2;
                    }
                }
            }
            if (button.Text == "4")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "4";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "4";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "4";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "4";
                        ResultLabel.Text = num2;
                    }
                }
            }
            if (button.Text == "5")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "5";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "5";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "5";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "5";
                        ResultLabel.Text = num2;
                    }
                }
            }
            if (button.Text == "6")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "6";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "6";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "6";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "6";
                        ResultLabel.Text = num2;
                    }
                }
            }
            if (button.Text == "7")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "7";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "7";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "7";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "7";
                        ResultLabel.Text = num2;
                    }
                }
            }
            if (button.Text == "8")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "8";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "8";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "8";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "8";
                        ResultLabel.Text = num2;
                    }
                }
            }
            if (button.Text == "9")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        num1 += "9";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 += "9";
                        ResultLabel.Text = num2;
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        num1 = "9";
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        num2 = "9";
                        ResultLabel.Text = num2;
                    }
                }
            }

            if (button.Text == "+/-")
            {
                if (ResultLabel.Text != "0")
                {
                    if (operation == null)
                    {
                        if (!num1.Contains("-"))
                        {
                            num1 = "-" + num1;
                            StartButton.IsEnabled = false;
                            YearButton.IsEnabled = false;
                            RateButton.IsEnabled = false;
                            InvestmentButton.IsEnabled = false;
                        }
                        else
                        {
                            num1 = num1.Substring(1);
                            StartButton.IsEnabled = true;
                            YearButton.IsEnabled = true;
                            RateButton.IsEnabled = true;
                            InvestmentButton.IsEnabled = true;
                        }
                        ResultLabel.Text = num1;
                    }
                    else
                    {
                        if (!num2.Contains("-"))
                        {
                            num2 = "-" + num2;
                            StartButton.IsEnabled = false;
                            YearButton.IsEnabled = false;
                            RateButton.IsEnabled = false;
                            InvestmentButton.IsEnabled = false;
                        }
                        else
                        {
                            num2 = num2.Substring(1);
                            StartButton.IsEnabled = true;
                            YearButton.IsEnabled = true;
                            RateButton.IsEnabled = true;
                            InvestmentButton.IsEnabled = true;
                        }
                        ResultLabel.Text = num2;
                    }
                }
            }

            if (button.Text == "/")
            {
                operation = "division";
                ResultLabel.Text = "0";
            }
            if (button.Text == "X")
            {
                operation = "multiplication";
                ResultLabel.Text = "0";
            }
            if (button.Text == "-")
            {
                operation = "subtraction";
                ResultLabel.Text = "0";
            }
            if (button.Text == "+")
            {
                operation = "addition";
                ResultLabel.Text = "0";
            }
            if (button.Text == "=")
            {
                try
                {
                    int num1Int = Convert.ToInt32(num1);
                    int num2Int = Convert.ToInt32(num2);
                    int result = 0;
                    if (operation == "division")
                    {
                        result = num1Int / num2Int;
                    }
                    if (operation == "multiplication")
                    {
                        result = num1Int * num2Int;
                    }
                    if (operation == "subtraction")
                    {
                        result = num1Int - num2Int;
                    }
                    if (operation == "addition")
                    {
                        result = num1Int + num2Int;
                    }
                    if (result < 0)
                    {
                        StartButton.IsEnabled = false;
                        YearButton.IsEnabled = false;
                        RateButton.IsEnabled = false;
                        InvestmentButton.IsEnabled = false;
                    } else
                    {
                        StartButton.IsEnabled = true;
                        YearButton.IsEnabled = true;
                        RateButton.IsEnabled = true;
                        InvestmentButton.IsEnabled = true;
                    }
                    ResultLabel.Text = Convert.ToString(result);
                }
                catch
                {
                    ResultLabel.Text = "Error";
                }
            }

            if (button.Text == "MC")
            {
                memory = "0";
            }
            if (button.Text == "MR")
            {
                if (operation == null)
                {
                    num1 = memory;
                    ResultLabel.Text = num1;
                }
                else
                {
                    num2 = memory;
                    ResultLabel.Text = num2;
                }
            }
            if (button.Text == "M-")
            {
                int num1Int = Convert.ToInt32(memory);
                int num2Int = Convert.ToInt32(ResultLabel.Text);
                int result = num1Int - num2Int;
                memory = Convert.ToString(result);

            }
            if (button.Text == "M+")
            {
                int num1Int = Convert.ToInt32(memory);
                int num2Int = Convert.ToInt32(ResultLabel.Text);
                int result = num1Int + num2Int;
                memory = Convert.ToString(result);
            }

            if (button.Text == "START")
            {
                starting = ResultLabel.Text;
                StartLabel.Text = "$" + ResultLabel.Text;
                ResultLabel.Text = "0";
            }
            if (button.Text == "YEARS")
            {
                years = ResultLabel.Text;
                YearLabel.Text = ResultLabel.Text;
                ResultLabel.Text = "0";
            }
            if (button.Text == "RATE")
            {
                rate = ResultLabel.Text;
                RateLabel.Text = ResultLabel.Text + "%";
                ResultLabel.Text = "0";
            }
            if (button.Text == "INVEST")
            {
                investment = ResultLabel.Text;
                InvestmentLabel.Text = "$" + ResultLabel.Text;
                ResultLabel.Text = "0";
            }
            if (button.Text == "FREQ")
            {
                frequency = await DisplayActionSheet("Frequency", "Cancel", null,
                                    "Monthly", "Quarterly", "Annually");
                FrequencyLabel.Text = frequency;
            }

            if (button.Text == "FINAL")
            {
                int startingInt = Convert.ToInt32(starting);
                int yearsInt = Convert.ToInt32(years);
                int rateInt = Convert.ToInt32(rate);
                double rateDouble = rateInt / 100.0;
                int investmentInt = Convert.ToInt32(investment);
                int frequencyInt = 0;
                if (frequency == "Monthly")
                {
                    frequencyInt = 12;
                }
                else if (frequency == "Quarterly")
                {
                    frequencyInt = 4;
                }
                else
                {
                    frequencyInt = 1;
                }
                balance = Compute(startingInt, yearsInt, rateDouble, investmentInt, frequencyInt);
                BalanceLabel.Text = "$" + balance;
            }

            if (button.Text == "C")
            {
                operation = null;
                num1 = "";
                num2 = "";
                ResultLabel.Text = "0";
                StartButton.IsEnabled = true;
                YearButton.IsEnabled = true;
                RateButton.IsEnabled = true;
                InvestmentButton.IsEnabled = true;
            }
        }

        private int Compute(int start, int years, double perc, int investment, int depositsPerYear)
        {
            double bal = start;
            double monthlyRate = perc / 12.0;
            int monthsToDeposit = 12 / depositsPerYear;
            for (int y = 0; y < years; y++)
            {
                for (int m = 1; m <= 12; m++)
                {
                    bal += bal * monthlyRate;
                    if (m % monthsToDeposit == 0)
                    {
                        bal += investment; // make deposits at the end of the month
                    }
                }
            }
            return (int)Math.Round(bal);
        }
    }
}

