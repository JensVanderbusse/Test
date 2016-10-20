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
using System.Windows.Threading;
using Microsoft.VisualBasic;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Mario : Window
    {
        private int velocity;
        private int jumpCounter = 0;   

        public Mario()
        {
            InitializeComponent();
            velocity = 0;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer.Start();
        }

        private void SharkAttack(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("_/\\_____________\\o/__");
            MessageBox.Show("__/\\____________\\o/__");
            MessageBox.Show("___/\\___________\\o/__");
            MessageBox.Show("____/\\__________\\o/__");
            MessageBox.Show("_____/\\_________\\o/__");
            MessageBox.Show("______/\\________\\o/__");
            MessageBox.Show("_______/\\_______\\o/__");
            MessageBox.Show("________/\\______\\o/__");
            MessageBox.Show("_________/\\_____\\o/__");
            MessageBox.Show("__________/\\____\\o/__");
            MessageBox.Show("___________/\\___\\o/__");
            MessageBox.Show("____________/\\__\\o/__");
            MessageBox.Show("_____________/\\_\\o/__");
            MessageBox.Show("______________/\\\\o/__");
            MessageBox.Show("________________/\\o/__");
            MessageBox.Show("__________________/\\__");
            MessageBox.Show("______________________");
            MessageBox.Show("______________________");
            MessageBox.Show("______________________");
            MessageBox.Show("______________________");
            MessageBox.Show("______________________");
            MessageBox.Show("______________________");
        }

        private void jump_Click(object sender, RoutedEventArgs e)
        {
            if (jumpCounter < 2)
            {
                velocity = -10;
                jumpCounter++;
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

        //private void right_Click(object sender, RoutedEventArgs e)
        //{
        //    RightMethod();
        //}

        private void RightMethod()
        {
            mario.Margin = new Thickness(mario.Margin.Left + 5, mario.Margin.Top, 0, 0);
        }
        public void JumpMethod(Object sender, ExecutedRoutedEventArgs e)
        {
            jump_Click(sender, e);
        }
        public void RightMethod(Object sender, ExecutedRoutedEventArgs e)       //Vervangen door Beweeg()
        {
            //mario.Margin = new Thickness(mario.Margin.Left + 5, mario.Margin.Top, 0, 0);
            ////right_Click(sender, e);
        }
        public void LeftMethod(Object sender, ExecutedRoutedEventArgs e)
        {
            //mario.Margin = new Thickness(mario.Margin.Left - 5, mario.Margin.Top, 0, 0);
        }

        public void TimerTick(object sender, EventArgs e)
        {
            Beweeg();

            if (mario.Margin.Top + velocity >= 260)
            {
                mario.Margin = new Thickness(mario.Margin.Left, 260, 0, 0);
                jumpCounter = 0;
            }
            else
            {
                mario.Margin = new Thickness(mario.Margin.Left, mario.Margin.Top + velocity, 0, 0);
            }
            if (mario.Margin.Top < 260)
            {
                velocity++;
            }
            else
            {
                velocity = 0;
            }
        }
        private void Beweeg()
        {
            if (Keyboard.IsKeyDown(Key.Right))
            {
                mario.Margin = new Thickness(mario.Margin.Left + 5, mario.Margin.Top, 0, 0);
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                mario.Margin = new Thickness(mario.Margin.Left - 5, mario.Margin.Top, 0, 0);
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {            
            MainWindow o = new MainWindow();
            o.Show();
        }
    }
}
    

