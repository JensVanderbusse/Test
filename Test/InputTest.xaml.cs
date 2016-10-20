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

namespace Test
{
    /// <summary>
    /// Interaction logic for InputTest.xaml
    /// </summary>
    public partial class InputTest : Window
    {
        KeyConverter kc = new KeyConverter();
        Key k1;
        Key k2;
        Key k3;
        Key k4;
        Key[] keys = new Key[4];
        public InputTest()
        {
            InitializeComponent();
            k1 = (Key)kc.ConvertFromString("Up");
            k2 = Key.Down;
            k3 = Key.Left;
            k4 = Key.Right;
            keys[0] = k1;
            keys[1] = k2;
            keys[2] = k3;
            keys[3] = k4;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputKeys p = new InputKeys(keys);
            if (p.ShowDialog() == true)
                keys = p.Answer;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == keys[0])
            {
                btn.Margin = new Thickness(btn.Margin.Left, btn.Margin.Top - 5, 0, 0);
            }
            else if (e.Key == keys[1])
            {
                btn.Margin = new Thickness(btn.Margin.Left, btn.Margin.Top + 5, 0, 0);

            }
            else if (e.Key == keys[2])
            {
                btn.Margin = new Thickness(btn.Margin.Left - 5, btn.Margin.Top, 0, 0);

            }
            else if (e.Key == keys[3])
            {
                btn.Margin = new Thickness(btn.Margin.Left + 5, btn.Margin.Top, 0, 0);

            }
        }
        
    }
}
