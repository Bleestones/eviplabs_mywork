using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using System.Text.RegularExpressions;
using Windows.UI;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Basics
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Button[,] buttons = new Button[3, 3];
        private Dictionary<string, SolidColorBrush> colors = new Dictionary<string, SolidColorBrush>()
        {
            {"darkRed" , new SolidColorBrush(Colors.DarkRed)},
            {"red", new SolidColorBrush(Colors.Red)},
            {"darkGray", new SolidColorBrush(Colors.DarkGray)},
            {"darkGreen", new SolidColorBrush(Colors.DarkGreen)},
            {"yellow", new SolidColorBrush(Colors.Yellow)},
            {"darkBlue", new SolidColorBrush(Colors.DarkBlue)},
            {"darkStateBlue", new SolidColorBrush(Colors.DarkSlateBlue)}
        };
        public MainPage()
        {
            this.InitializeComponent();
            stackPanel.Background = colors["darkRed"];
            firstRectangle.Fill = colors["red"];
            sliderTextBox.Text = slider.Value.ToString();
            ButtonMatrixInit();
        }

        private Color GetColor(Control solidColor)
        {
            return ((SolidColorBrush)solidColor.Background).Color;
        }

        private void SetColor(Control setobject, string colorName)
        {
            setobject.Background = colors[colorName];
        }

        private void ButtonMatrixInit()
        {
            for (int y = 0; y <= buttons.GetUpperBound(1); y++)
            {
                for (int x = 0; x <= buttons.GetUpperBound(0); x++)
                {
                    buttons[y, x] = new Button()
                    {
                        Name = "matrixButton"+y+x,
                        Width = 150,
                        Content = " ",
                        Background = colors["darkGray"]
                    };
                    Grid.SetRow(buttons[y, x], x);
                    Grid.SetColumn(buttons[y, x], y);
                    buttons[y, x].Click += Button_Click;
                    matrixButtonGrid.Children.Add(buttons[y, x]);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (GetColor(button) == Colors.DarkGray)
            {
                SetColor(button, "darkGreen");
            }
            else if(GetColor(button) == Colors.DarkGreen)
            {
                SetColor(button, "darkGray");
            }
            SetButtonColor(getButtonIndex(button));
            IsAllTheSameColorForWin();

        }

        private async void IsAllTheSameColorForWin()
        {
            for(int y = 0; y <= buttons.GetUpperBound(1); y++)
                for(int x = 0; x <= buttons.GetUpperBound(0); x++)
                {
                    if(GetColor(buttons[y,x]) != Colors.DarkGreen)
                        return;
                }
            MessageDialog win = new MessageDialog("You won!");
           await win.ShowAsync();
        }

        private void SetButtonColor(Tuple<int, int> indexesOfButton)
        {
            for(int y = 0; y <= buttons.GetUpperBound(1); y++)
            {
                for(int x = 0; x <= buttons.GetUpperBound(0); x++)
                {
                    if(!(indexesOfButton.Item1.Equals(y) && indexesOfButton.Item2.Equals(x)))
                    {
                        if ((indexesOfButton.Item2 == x && (y - indexesOfButton.Item1 == 1 || indexesOfButton.Item1 - y == 1)) || (indexesOfButton.Item1 == y && (x -indexesOfButton.Item2 == 1  || indexesOfButton.Item2 - x == 1)))
                        {
                            if (GetColor(buttons[y, x]) == Colors.DarkGreen)
                                SetColor(buttons[y, x], "darkGray");
                            else
                                SetColor(buttons[y, x], "darkGreen");
                        }
                    }
                }
            }
        }

        private Tuple<int, int> getButtonIndex(Button buttonName)
        {
            for(int y = 0; y <= buttons.GetUpperBound(1); y++)
            {
                for(int x = 0; x <= buttons.GetUpperBound(0); x++)
                {
                    if (buttons[y, x].Equals(buttonName))
                        return Tuple.Create(y, x);
                }
            }
            return null;
        }


        private void colorBtn_Click(object sender, RoutedEventArgs e)
        {
            colorBtn.Foreground = colors["yellow"];
            colorBtn.Background = colors["darkBlue"];
        }

        private byte changed = 0;
        private void backgroundBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (changed)
            {
                case 0:
                    {
                        stackPanel.Background = colors["darkStateBlue"];
                        changed = 1;
                        break;
                    }
                case 1:
                    {
                        stackPanel.Background = colors["darkRed"];
                        changed = 0;
                        break;
                    }
            }
        }

        private void addOfTwoTextBoxValue_Click(object sender, RoutedEventArgs e)
        {
            int firstValue;
            int secondValue;
            if (Int32.TryParse(firstTextBox.Text, out firstValue) && Int32.TryParse(seconTextBox.Text, out secondValue))
                valueOfTheTwoTextBox.Text = (firstValue + secondValue).ToString();
            else
                valueOfTheTwoTextBox.Text = "Not number!";
        }

        private void disbaleTheTwoTextBox_Click(object sender, RoutedEventArgs e)
        {
            firstTextBox.IsEnabled = false;
            seconTextBox.IsEnabled = false;
        }

        private byte rectangleColorSwitch = 2;
        private void switchButton_Click(object sender, RoutedEventArgs e)
        {
            switch(rectangleColorSwitch)
            {
                case 1:
                    {
                        firstRectangle.Fill = colors["red"];
                        thirdRectangle.Fill = colors["darkRed"];
                        rectangleColorSwitch++;
                        break;
                    }
                case 2:
                    {
                        firstRectangle.Fill = colors["darkRed"];
                        secondRectangle.Fill = colors["red"];
                        rectangleColorSwitch++;
                        break;
                    }
                case 3:
                    {
                        secondRectangle.Fill = colors["darkRed"];
                        thirdRectangle.Fill = colors["red"];
                        rectangleColorSwitch = 1;
                        break;
                    }
            }
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            sliderTextBox.Text = slider.Value.ToString();
        }

        private void sliderTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Regex.IsMatch(sliderTextBox.Text, "[^0-9]"))
            {
                sliderTextBox.Text = sliderTextBox.Text.Remove(sliderTextBox.Text.Length - 1);
            }
            else if(Regex.IsMatch(sliderTextBox.Text, "[0-9]"))
            {
                slider.Value = double.Parse(sliderTextBox.Text);
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = new Button()
            {
                Name = "deleteButton",
                Content = "Delete me",
                Width = 100
            };
            deleteButton.Click += Btn_Click; //feliratkozik
            deleteBtnPanel.Children.Add(deleteButton);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            deleteBtnPanel.Children.Remove((Button)sender);
            ((Button)sender).Click -= Btn_Click; //Ez enélkül is működik. Mi lesz, ha ez a sor mégsincsen benne?
            //A feladat megoldásában ezt a részt, hogyan lehet másképpen megcsinálni?
        }
    }
}
