using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Test
{
    class Stuff
    {
        public void SharkAttack()
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
        public void RandomLocation(Label label, int grootte)
        {
            Random r = new Random();
            label.SetValue(Grid.ColumnProperty, r.Next(grootte));
            label.SetValue(Grid.RowProperty, r.Next(grootte));
        }
        public Image GetImage()
        {
            Image foto = new Image();
            BitmapImage myImageSource = new BitmapImage();
            myImageSource.BeginInit();
            myImageSource.UriSource = new Uri("Images/bold.png", UriKind.Relative);
            myImageSource.EndInit();
            foto.Source = myImageSource;
            return foto;
        }
    }
}
