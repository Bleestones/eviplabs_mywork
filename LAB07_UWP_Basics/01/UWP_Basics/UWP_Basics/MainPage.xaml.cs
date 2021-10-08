﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Basics
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            firstRectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
            sliderTextBox.Text = slider.Value.ToString();
        }

        private void colorBtn_Click(object sender, RoutedEventArgs e)
        {
            colorBtn.Foreground = new SolidColorBrush(Windows.UI.Colors.Yellow);
            colorBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
        }

        private byte changed = 0;
        private void backgroundBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (changed)
            {
                case 0:
                    {
                        stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.DarkSlateBlue);
                        changed = 1;
                        break;
                    }
                case 1:
                    {
                        stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.Black);
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
                        firstRectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                        thirdRectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
                        rectangleColorSwitch++;
                        break;
                    }
                case 2:
                    {
                        firstRectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
                        secondRectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                        rectangleColorSwitch++;
                        break;
                    }
                case 3:
                    {
                        secondRectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
                        thirdRectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
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
            stackPanel.Children.Add(deleteButton);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            stackPanel.Children.Remove((Button)sender);
            ((Button)sender).Click -= Btn_Click; //Ez enélkül is működik. Mi lesz, ha ez a sor mégsincsen benne?
            //A feladat megoldásában ezt a részt, hogyan lehet másképpen megcsinálni?
        }
    }
}
