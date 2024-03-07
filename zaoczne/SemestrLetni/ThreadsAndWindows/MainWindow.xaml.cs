using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ThreadsAndWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(animacja));
            t.Start();
        }
        private void animacja()
        {
            double y=0.0, x=0.0;
            Dispatcher.Invoke(() =>
            {
                y = Canvas.GetTop(Ball);
                x = Canvas.GetLeft(Ball);
            });
            for (int i=0; i<10; i++)
            {
                x = x + 1;
                y = y - 1;
                Dispatcher.Invoke(() =>
                {
                    Canvas.SetLeft(Ball, x);
                    Canvas.SetTop(Ball, y);
                });
            }

        }
    }
}
