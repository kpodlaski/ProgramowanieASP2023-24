using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPFAndThread
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
            Thread t = new Thread(new ThreadStart(animate));
            t.Start();
        }
        private void animate()
        {

            Debug.WriteLine("Kliknięto klawisz th.ID:{0}",
                           Thread.CurrentThread.ManagedThreadId);
            double x = 110;
            double y = 73;
            while (x < 800 && y < 480)
            {
                x += 1;
                y += 1;
                Dispatcher.Invoke((Action)(() =>
                {
                    Canvas.SetLeft(Ball, x);
                    Canvas.SetTop(Ball, y);
                    if (x < 200 && x > 199.98)
                    {
                        Debug.WriteLine("z invoke th.ID:{0}",
                            Thread.CurrentThread.ManagedThreadId
                            );
                    }
                }));
                Thread.Sleep(10);
            }
            Debug.WriteLine("Koniec animacji th.ID:{0}",
                           Thread.CurrentThread.ManagedThreadId
                           );
        }
    }
}
