using HelixToolkit.UWP;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LAB07_UWP_Basics
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            BuildPolynomDiagramModel();

            InitializeComponent();

            // Create polynomial diagram
            var plotViewWheel = new PlotViewWheel();
            plotViewWheel.Model = PolynomialDiagramModel;
            plotViewWheel.SetValue(Grid.ColumnProperty, 1);
            polynomGrid.Children.Add(plotViewWheel);

            Windows.UI.Xaml.Window.Current.CoreWindow.KeyDown += HotKeyDown;

            // Create 3D pivot item
            pivotItem3D = new PivotItem3D(grid3D);

            pivotItem3D.Viewport3DX_OnMouse3DDown += Viewport3DX_OnMouse3DDown;
            pivotItem3D.Viewport3DX_OnMouse3DUp += Viewport3DX_OnMouse3DUp;
            pivotItem3D.Viewport3DX_OnMouse3DMove += Viewport3DX_OnMouse3DMove;
            pivotItem3D.Viewport3DX_KeyDown += Viewport3DX_KeyDown;
        }

        private PivotItem3D pivotItem3D;
        private Windows.Foundation.Point prevPos;
        private bool viewport3DX_IsMouseDown = false;

        private void Viewport3DX_OnMouse3DDown(object sender, MouseDown3DEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Viewport3DX_OnMouse3DUp(object sender, MouseUp3DEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Viewport3DX_OnMouse3DMove(object sender, MouseMove3DEventArgs e)
        {
            if (prevPos != null && viewport3DX_IsMouseDown)
            {

            }
            prevPos = e.Position;
            throw new NotImplementedException();
        }

        private void Viewport3DX_KeyDown(Windows.UI.Core.CoreWindow s, Windows.UI.Core.KeyEventArgs e)
        {
            switch (e.VirtualKey)
            {
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        #region Polynomial tab
        public Dictionary<char, double> Coeffs { get; set; } = new Dictionary<char, double>
            {
                {'a', 0.01},
                {'b', 0.01},
                {'c', 0.01}
            };

        public PlotModel PolynomialDiagramModel { get; private set; }
        public IList<DataPoint> Data { get; set; } = new List<DataPoint>();

        public int PlotYRangeMin { get; set; } = -100;
        public int PlotYRangeMax { get; set; } = 100;
        public int PlotXRange { get; set; } = 10;
        public int PlotXResolution { get; set; } = 1000;

        private char lastCoeffLetter = 'c';
        private bool mousedown = false;

        private void BuildPolynomDiagramModel()
        {
            var lineSeries = new LineSeries();
            lineSeries.ItemsSource = Data;
            var xAxis = new OxyPlot.Axes.LinearAxis();
            xAxis.Title = "X";
            xAxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
            var yAxis = new OxyPlot.Axes.LinearAxis();
            yAxis.Title = "Y";
            //yAxis.Maximum = PlotYRangeMax;
            //yAxis.Minimum = PlotYRangeMin;
            yAxis.Position = OxyPlot.Axes.AxisPosition.Left;

            PolynomialDiagramModel = new PlotModel { Title = "a*x2+b*x+c" };
            PolynomialDiagramModel.Series.Add(lineSeries);
            PolynomialDiagramModel.Axes.Add(xAxis);
            PolynomialDiagramModel.Axes.Add(yAxis);

            UpdatePolynomDiagram();
            PolynomialDiagramModel.MouseMove += ActualModel_MouseMove;
            PolynomialDiagramModel.MouseUp += ActualModel_MouseUp;
            PolynomialDiagramModel.MouseDown += ActualModel_MouseDown;
        }

        private void ActualModel_MouseDown(object sender, OxyMouseEventArgs e)
            => mousedown = true;
        private void ActualModel_MouseUp(object sender, OxyMouseEventArgs e)
            => mousedown = false;

        private void ActualModel_MouseMove(object sender, OxyMouseEventArgs e)
        {
            if (mousedown)
            {
                PlotModel plot = PolynomialDiagramModel;
                ElementCollection<OxyPlot.Axes.Axis> axisList = plot.Axes;
                OxyPlot.Axes.Axis xAxis = null, yAxis = null;

                foreach (OxyPlot.Axes.Axis ax in axisList)
                {
                    if (ax.Position == OxyPlot.Axes.AxisPosition.Bottom)
                        xAxis = ax;
                    else if (ax.Position == OxyPlot.Axes.AxisPosition.Left)
                        yAxis = ax;
                }

                DataPoint p = OxyPlot.Axes.Axis.InverseTransform(e.Position, xAxis, yAxis);
                if (p.X > PlotXRange)
                {
                    PlotXRange = (int)p.X;
                    UpdatePolynomDiagram();
                }
                else if (p.X < -PlotXRange)
                {
                    PlotXRange = (int)-p.X;
                    UpdatePolynomDiagram();
                }
            }
        }

        private void UpdatePolynomDiagram()
        {
            Data.Clear();
            for (int i = -PlotXResolution; i <= PlotXResolution; i++)
            {
                var x = i * (double)PlotXRange / PlotXResolution;
                var y = 0.0;
                foreach (var coeff in Coeffs)
                {
                    var exp = (Coeffs.Count - 1) - (coeff.Key - 'a');
                    y += coeff.Value * Math.Pow(x, exp);
                }
                Data.Add(new DataPoint(x, y));
            }
            UpdateDiagramTitle();
            PolynomialDiagramModel.InvalidatePlot(true);
        }

        private void UpdateDiagramTitle()
        {
            var newTitle = "";
            var coeffLetter = 'a';
            for (int i = 0; i < Coeffs.Count; i++)
            {
                if (i < Coeffs.Count - 2)
                {
                    newTitle += coeffLetter + "*x" + (Coeffs.Count - 1 - i).ToString();
                    newTitle += "+";
                }
                else if (i < Coeffs.Count - 1)
                {
                    newTitle += coeffLetter + "*x";
                    newTitle += "+";
                }
                else
                {
                    newTitle += coeffLetter;
                }
                coeffLetter++;
            }
            PolynomialDiagramModel.Title = newTitle;
        }

        private void AddNewCoeff_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            lastCoeffLetter++;
            Coeffs.Add(lastCoeffLetter, 0.01);
            var coeffUC = new CoeffUserControl(lastCoeffLetter);
            //coeffUC.TextBox_BeforeTextChangingEv += TextBox_BeforeTextChanging;
            coeffUC.TextBox_KeyDownEv += TextBox_KeyDown;
            coeffUC.Slider_ValueChangedEv += Slider_ValueChanged;
            coeffStackPanel.Children.Insert(coeffStackPanel.Children.Count - 2, coeffUC);
            UpdatePolynomDiagram();
        }

        private void RemoveCoeff_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (coeffStackPanel.Children.Count > 2)
            {
                Coeffs.Remove(lastCoeffLetter);
                coeffStackPanel.Children.RemoveAt(coeffStackPanel.Children.Count - 3);
                lastCoeffLetter--;
                UpdatePolynomDiagram();
            }
        }

        /*private void TextBox_BeforeTextChanging(object sender, TextBoxBeforeTextChangingEventArgs args)
        {
            // Allow only digits, negative sign, and decimal point
            args.Cancel = !args.NewText.All(c => char.IsDigit(c) || c == '-' || c == '.');
        }*/

        private bool changingValFromTextBox = false;
        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            var textbox = (TextBox)sender;
            if (e.Key == VirtualKey.Enter && double.TryParse(textbox.Text, out var res))
            {
                var textboxParent = (StackPanel)textbox.Parent;
                var slider = (Slider)textboxParent.Children[1];
                changingValFromTextBox = true;
                slider.Value = res;
                Coeffs[textboxParent.Tag.ToString()[0]] = slider.Value;
                UpdatePolynomDiagram();
                changingValFromTextBox = false;
            }
        }

        private void Slider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            var slider = (Slider)sender;
            var sliderParent = (StackPanel)slider.Parent;
            if (sliderParent != null && !changingValFromTextBox)
            {
                var textBox = (TextBox)sliderParent.Children[0];
                textBox.Text = e.NewValue.ToString();
                Coeffs[sliderParent.Tag.ToString()[0]] = e.NewValue;
                UpdatePolynomDiagram();
            }
        }
        #endregion

        #region Image drag and drop tab
        private void ImageListView_DragEnter(object sender, Windows.UI.Xaml.DragEventArgs args)
            => ((GridView)sender).Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.DarkGray);

        private void ImageListView_DragLeave(object sender, Windows.UI.Xaml.DragEventArgs e)
            => ((GridView)sender).Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.White);

        private void ImageListView_DragOver(object sender, Windows.UI.Xaml.DragEventArgs e)
            => e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;

        public ObservableCollection<ImageItem> ImageItems { get; private set; } = new ObservableCollection<ImageItem>();

        private async void ImageListView_Drop(object sender, Windows.UI.Xaml.DragEventArgs e)
        {
            ((GridView)sender).Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.White);
            if (e.DataView.Contains(Windows.ApplicationModel.DataTransfer.StandardDataFormats.StorageItems))
            {
                var storageItems = await e.DataView.GetStorageItemsAsync();

                foreach (Windows.Storage.StorageFile storageItem in storageItems)
                {
                    var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    await bitmapImage.SetSourceAsync(await storageItem.OpenReadAsync());

                    var imageItem = new ImageItem
                    {
                        Id = Guid.NewGuid(),
                        Image = bitmapImage
                    };

                    ImageItems.Add(imageItem);
                }
            }
        }

        private void ImageListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var items = string.Join(",", e.Items.Cast<ImageItem>().Select(i => i.Id));
            e.Data.SetText(items);
            e.Data.RequestedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        }
        #endregion

        private void HotKeyDown(Windows.UI.Core.CoreWindow s, Windows.UI.Core.KeyEventArgs e)
        {
            var ctrl = Windows.UI.Xaml.Window.Current.CoreWindow.GetKeyState(VirtualKey.Control);
            if (ctrl.HasFlag(Windows.UI.Core.CoreVirtualKeyStates.Down))
            {
                switch (e.VirtualKey)
                {
                    case VirtualKey.Number1:
                        rootPivot.SelectedItem = polynomPivotItem;
                        break;
                    case VirtualKey.Number2:
                        rootPivot.SelectedItem = _3DPivotItem;
                        break;
                    case VirtualKey.Number3:
                        rootPivot.SelectedItem = imagePivotItem;
                        break;
                }
            }
        }
    }

    public class PlotViewWheel : OxyPlot.Windows.PlotView
    {
        protected new void OnPointerWheelChanged(PointerRoutedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.MouseWheelDelta > 0)
                ((LineSeries)Model.Series[0]).Color = OxyColors.Blue;
            else
                ((LineSeries)Model.Series[0]).Color = OxyColors.Red;
            base.OnPointerWheelChanged(e);
        }
    }

    public class ImageItem
    {
        public Guid Id { get; set; }
        public Windows.UI.Xaml.Media.Imaging.BitmapImage Image { get; set; }
    }
}
