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
using System.Windows.Shapes;
using System.Net.NetworkInformation;
using System.Net;
using System.Diagnostics;
using System.Windows.Threading;
using System.Threading;

namespace Test
{
    /// <summary>
    /// Interaction logic for PacMan.xaml
    /// </summary>
    public partial class PacMan : Window
    {
       
        public PacMan()
        {           
            InitializeComponent();           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            test.Margin = new Thickness(test.Margin.Left, test.Margin.Top + 5, 0, 0);
        }
        private void DownGo(object sender, RoutedEventArgs e)
        {
            if (test.Margin.Top<429)
            {
                test.Margin = new Thickness(test.Margin.Left, test.Margin.Top + 5, 0, 0);
            }
        }
        private void UpGo(object sender, RoutedEventArgs e)
        {
            if (test.Margin.Top >20)
            {
                test.Margin = new Thickness(test.Margin.Left, test.Margin.Top - 5, 0, 0);
            }
        }
        private void LeftGo(object sender, RoutedEventArgs e) 
        {
            if (test.Margin.Left >20)
            {
                test.Margin = new Thickness(test.Margin.Left - 5, test.Margin.Top, 0, 0);
            }
        }
        private void RightGo(object sender, RoutedEventArgs e) 
        {
            if (test.Margin.Left<552)
            {
                test.Margin = new Thickness(test.Margin.Left + 5, test.Margin.Top, 0, 0);                
            }
        }

        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame(true);
            Dispatcher.CurrentDispatcher.BeginInvoke
            (
            DispatcherPriority.Background,
            (SendOrPostCallback)delegate(object arg)
            {
                var f = arg as DispatcherFrame;
                f.Continue = false;
            },
            frame
            );
            Dispatcher.PushFrame(frame);
        }
    }
}
