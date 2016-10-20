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
    /// Interaction logic for TestGrid.xaml
    /// </summary>
    public partial class TestGrid : Window
    {
        Label[,] arry = new Label[10, 10];
        public TestGrid()

        {
                      
            //Image foto = new Image();
            //BitmapImage myImageSource = new BitmapImage();
            //myImageSource.BeginInit();
            //myImageSource.UriSource = new Uri("Images/bold.png", UriKind.Relative );
            //myImageSource.EndInit();
            //foto.Source = myImageSource;
            Stuff s = new Stuff();
            Image foto = s.GetImage();
            ImageBrush b = new ImageBrush();
            b.ImageSource = new BitmapImage(new Uri("C:/Users/user/Documents/Oefeningen Jens/VS/WPF/Test/Test/Images/bold.png", UriKind.Relative));



            InitializeComponent();
            puipui.ShowGridLines = true;
            for (int i = 0; i < 10; i++)
            {
                puipui.ColumnDefinitions.Add(new ColumnDefinition());
                puipui.RowDefinitions.Add(new RowDefinition());                
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <10; j++)
                {
                    arry[i, j] = new Label();
                    arry[i, j].Content = "test";

                    Grid.SetColumn(arry[i,j], i);
                    Grid.SetRow(arry[i, j], j);
                    puipui.Children.Add(arry[i, j]);
                }
            }

            arry[4, 5].Background = b;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow o = new MainWindow();
            o.Show();     
        }
        
       
    }
}
