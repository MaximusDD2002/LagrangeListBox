using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace LagrangeListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double j;
        List<XY> listXY;
        LineSeries lineY = new LineSeries();
        LineSeries lineX = new LineSeries();
        public MainWindow()
        {
            InitializeComponent();

            listXY = new List<XY>()
            {
                new XY()
                {
                    X = 2,
                    Y = 15
                },
                new XY()
                {
                    X = 3,
                    Y = 39
                },
                new XY()
                {
                    X = 6,
                    Y = 243
                },
                new XY()
                {
                    X = 7,
                    Y = 375
                },
                new XY()
                {
                    X = 9,
                    Y = 771
                }
            };

            this.ListBoxNumbers.ItemsSource = listXY;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ListBoxNumbers.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listXY.Add(new XY()
            {
                X = 0,
                Y = 0
            });
            this.ListBoxNumbers.ItemsSource = listXY;
            this.ListBoxNumbers.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int cnt = listXY.Count;
            if (cnt > 0 && ListBoxNumbers.SelectedIndex > -1)
            {
                listXY.RemoveAt(ListBoxNumbers.SelectedIndex);
            }
            this.ListBoxNumbers.Items.Refresh();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<double> X = new List<double>();
            List<double> Y = new List<double>();
            ChartValues<string> valuesX = new ChartValues<string>();
            ChartValues<Double> valuesY = new ChartValues<Double>();
            SeriesCollection series = new SeriesCollection();
            double c = 1;
            double v = 1;
            double d, f = 1;
            double rez;
            double finalRez = 0;

            foreach (var item in this.listXY)
            {
                X.Add(item.X);
                Y.Add(item.Y);
            }

            for (int p = 0; p < Y.Count(); p++)
            {

                for (int x = 0; x < X.Count(); x++)
                {
                    if (c != 0 && x != p)
                    {
                        c = j - X[x];
                        v = v * c;
                        Console.WriteLine(v);
                    }
                }

                for (int x = 0; x < Y.Count(); x++)
                {
                    d = X[p] - X[x];
                    if (d != 0)
                    {
                        f = f * d;
                        Console.WriteLine(f);
                    }
                }

                rez = (v / f) * Y[p];

                v = 1;
                f = 1;

                finalRez = finalRez + rez;
            }


            endResult.Content = "The end result is: " + finalRez;


            foreach (var item in this.listXY)
            {
                valuesX.Add(item.X.ToString());

                valuesY.Add(item.Y);
            }

            string stringY = valuesY.ToString();

            CartesianChart1.AxisX.Clear();
            CartesianChart1.AxisX.Add(new Axis()
            {
                Title = "stringX",
                Labels = valuesX
            });

            lineY.Values = valuesY;

            series.Add(lineY);

            CartesianChart1.Series = series;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            j = Double.Parse(Coordinate.Text);
        }
    }

    public class XY
    {
        public double X { get; set; }
        public double Y { get; set; }
        public override string ToString()
        {
            return this.X + " | " + this.Y;
        }
    }

    public class getX
    {
        public double X { get; set; }
        public override string ToString()
        {
            return "" + this.X;
        }
    }

    public class getY
    {
        public double Y { get; set; }
        public override string ToString()
        {
            return "" + this.Y;
        }
    }
}
