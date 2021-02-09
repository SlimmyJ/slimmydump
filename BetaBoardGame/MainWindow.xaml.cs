using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace BetaBoardGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Locationy = 0;
        public int Locationx = 0;

        public int Enemylocationx = 4;
        public int Enemylocationy = 4;

        public MainWindow()
        {
            InitializeComponent();
            Grid.SetRow(EllipsePlayer, Locationy);
            Grid.SetColumn(EllipsePlayer, Locationx);

            Grid.SetRow(EllipseRnd, Enemylocationy);
            Grid.SetColumn(EllipseRnd, Enemylocationx);

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += Timer;
            timer.Start();
        }

        private void Timer(object sender, EventArgs e)
        {
            var rand = new Random();
            var enemymovement = rand.Next(1, 5);

            if (Enemylocationx == Locationx && Enemylocationy == Locationy)
            {
                MessageBox.Show("Hit");
            }

            switch (enemymovement)
            {
                case 1:
                    if (Enemylocationx == 9)
                    {
                        Enemylocationx = 8;
                    }
                    else
                    {
                        Enemylocationx++;
                    }
                    Grid.SetColumn(EllipseRnd, Enemylocationx);
                    break;

                case 2:
                    if (Enemylocationx == 0)
                    {
                        Enemylocationx = 1;
                    }
                    else
                    {
                        Enemylocationx--;
                    }

                    Grid.SetColumn(EllipseRnd, Enemylocationx);
                    break;

                case 3:
                    if (Enemylocationy == 0)
                    {
                        Enemylocationy = 1;
                    }
                    else
                    {
                        Enemylocationy--;
                    }
                    Grid.SetRow(EllipseRnd, Enemylocationy);
                    break;

                case 4:
                    if (Enemylocationy == 9)
                    {
                        Enemylocationy = 8;
                    }
                    else
                    {
                        Enemylocationy++;
                    }
                    Grid.SetRow(EllipseRnd, Enemylocationy);

                    break;
            }
        }

        private void ButtonUp_OnClick(object sender, RoutedEventArgs e)
        {
            if (Locationy == 0)
            {
                Locationy = 0;
            }
            else
            {
                Locationy--;
            }
            Grid.SetRow(EllipsePlayer, Locationy);
        }

        private void ButtonDown_OnClick(object sender, RoutedEventArgs e)
        {
            if (Locationy == 9)
            {
                Locationy = 9;
            }
            else
            {
                Locationy++;
            }
            Grid.SetRow(EllipsePlayer, Locationy);
        }

        private void ButtonLeft_OnClick(object sender, RoutedEventArgs e)
        {
            if (Locationx == 0)
            {
                Locationx = 0;
            }
            else
            {
                Locationx--;
            }
            Grid.SetColumn(EllipsePlayer, Locationx);
        }

        private void ButtonRight_OnClick(object sender, RoutedEventArgs e)
        {
            if (Locationx == 9)
            {
                Locationx = 9;
            }
            else
            {
                Locationx++;
            }
            Grid.SetColumn(EllipsePlayer, Locationx);
        }
    }
}