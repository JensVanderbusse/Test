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
    /// Interaction logic for Zac.xaml
    /// </summary>
    public partial class Zac : Window
    {       
        public Zac()
        {
            InitializeComponent();
            zacy.Height = healthSlider.Value + 10;
            zacy.Width = healthSlider.Value / 1.5 + 6;
        }

        private void healthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            zacy.Height = healthSlider.Value+10;
            zacy.Width = healthSlider.Value / 1.5 + 6;
            //zacy.Width = healthSlider.Value + 10;
            zacy.Margin = new Thickness(219 - zacy.Width / 2, 75 - zacy.Height/2, 0, 0);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow p = new MainWindow();
            p.Show();
            this.Close();
        }
    }
}
