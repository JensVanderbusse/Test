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

namespace Test
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
        private int jumpCounter = 0;

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            knop.Content = fred.Value;
        }

        private void knop_Click(object sender, RoutedEventArgs e)
        {
            Placeholder p = new Placeholder();
            p.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stuff s = new Stuff();
            s.SharkAttack();
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            fred.Value++;
        }
        private void jump_Click(object sender, RoutedEventArgs e)
        {
            if (jumpCounter < 2)
            {
                jumpCounter++;
                for (int i = -10; i < 11; i++)
                {
                    mario.Margin = new Thickness(mario.Margin.Left, mario.Margin.Top + i, 0, 0);
                    System.Threading.Thread.Sleep(25);
                    DoEvents();
                }
                jumpCounter--;
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

        private void right_Click(object sender, RoutedEventArgs e)
        {
            mario.Margin = new Thickness(mario.Margin.Left + 5, mario.Margin.Top, 0, 0);
        }

      
        public void FirstMethod(Object sender, ExecutedRoutedEventArgs e)
    {
        jump_Click(sender,e);
    }

        public void SecondMethod(Object sender, ExecutedRoutedEventArgs e)
    {
        right_Click(sender, e);
    }
        public void ThirdMethod(Object sender, ExecutedRoutedEventArgs e)
    {
        mario.Margin = new Thickness(mario.Margin.Left - 5, mario.Margin.Top, 0, 0);
    }

        private void pac_Click(object sender, RoutedEventArgs e)
        {
            PacMan p = new PacMan();
            p.Show();
            this.Close();
        }
        private void btnZac_Click(object sender, RoutedEventArgs e)
        {
            Zac p = new Zac();
            p.Show();
            this.Close();
        }
        private void btnBSS_Click(object sender, RoutedEventArgs e)
        {
            BSS p = new BSS();
            p.Show();
            this.Close();
        }
        private void btnMario_Click(object sender, RoutedEventArgs e)
        {
            Mario p = new Mario();
            p.Show();
            this.Close();
        }
        private void snake_Click(object sender, RoutedEventArgs e)
        {
            Snake p = new Snake();
            p.Show();
            this.Close();
        }
        private void puipui_Click(object sender, RoutedEventArgs e)        {
            TestGrid p = new TestGrid();
            p.Show();
            this.Close();
        }

        private void inputbutton_Click(object sender, RoutedEventArgs e)
        {
            InputBox inputDialog = new InputBox(DateTime.Now+" Please enter your name:");
            if (inputDialog.ShowDialog() == true)
                inputbutton.Content = inputDialog.Answer;
            
            

        }

        private void jump_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            jump.Content = "double";
        }

    }




}

