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
    /// Interaction logic for BSS.xaml
    /// </summary>
    public partial class BSS : Window
    {
        public BSS()
        {
            InitializeComponent();
        }
        private Rectangle sleeprechthoek = new Rectangle();
        private void MM(object sender, MouseEventArgs e)
        {
            sleeprechthoek = (Rectangle)sender;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject sleepKleur = new DataObject(typeof(Brush), sleeprechthoek.Fill);
                DragDrop.DoDragDrop(sleeprechthoek, sleepKleur, DragDropEffects.Move);
            }
        }
        private void Rectangle_DragEnter(object sender, DragEventArgs e)
        {
            Rectangle kader = (Rectangle)sender;
            kader.StrokeThickness = 5;
        }
        private void Rectangle_DragLeave(object sender, DragEventArgs e)
        {
            Rectangle kader = (Rectangle)sender;
            kader.StrokeThickness = 3;
        }
        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            Rectangle rechthoek = (Rectangle)sender;
            if (e.Data.GetDataPresent(typeof(Brush)))
            {
                Brush gesleepteKleur = (Brush)e.Data.GetData(typeof(Brush));
                if (true) //controle voor wit veranderd om te testen
                {
                    zet1.Fill = gesleepteKleur;             //aanpassen zodat rechthoek niet enkel gevuld wordt met zwart maar ook met vijand zet + score aanpassen           
                    rctField.Visibility = Visibility.Hidden;
                    Random R = new Random();
                    int k = R.Next(3);
                    if (k == 0){
                        zet2.Fill = Brushes.Green;
                    }else if(k==1){
                        zet2.Fill = Brushes.Red;
                    }else{
                        zet2.Fill = Brushes.DarkGray;// #FF008000 (Green)      #FFA9A9A9 (DarkGrey)    #FFFF0000 (Red)
                    }
                    //lblScore2.Content = zet2.Fill.ToString();            // geen idee wat er fout is aan code in commentaar(krijg fout als er 2 verschillende waarden zijn)
                    //if (zet1.Fill.ToString() == "#FF008000")
                    //{
                    //    if (zet2.Fill.ToString() == "#FFFF0000")
                    //    {
                    //        lblScore2.Content = (int)lblScore2.Content + 1;
                    //    }
                    //    if (zet2.Fill.ToString() == "#FF090909")
                    //    {
                    //        lblScore1.Content = (int)lblScore1.Content + 1;
                    //    }
                    //}
                    //else if (zet1.Fill == Brushes.Red)
                    //{
                    //    if (zet2.Fill == Brushes.Green)
                    //    {
                    //        lblScore1.Content = (int)lblScore1.Content + 1;
                    //    }
                    //    if (zet2.Fill == Brushes.DarkGray)
                    //    {
                    //        lblScore2.Content = (int)lblScore2.Content + 1;
                    //    }
                    //}
                    //else
                    //{
                    //    if (zet2.Fill == Brushes.Red)
                    //    {
                    //        lblScore1.Content = (int)lblScore1.Content + 1;
                    //    }
                    //    if (zet2.Fill == Brushes.Green)
                    //    {
                    //        lblScore2.Content = (int)lblScore2.Content + 1;
                    //    }
                    //}
                }
            }
            rechthoek.StrokeThickness = 3;
        }

        private ListBoxItem VindListBoxItem(Object sleepitem)
        {
            DependencyObject keuze = (DependencyObject)sleepitem;
            while (keuze != null)
            {
                if (keuze is ListBoxItem)
                    return (ListBoxItem)keuze;
                keuze = VisualTreeHelper.GetParent(keuze);
            }
            return null;
        }

        ListBox draglijst;
        private void DragListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                draglijst = (ListBox)sender;
                ListBoxItem programmaitem = VindListBoxItem(e.OriginalSource);
                if (draglijst.SelectedIndex >= 0 && programmaitem != null)
                {
                    DataObject sleepdata =
                    new DataObject(typeof(object), programmaitem.Content);
                    DragDrop.DoDragDrop(programmaitem, sleepdata,
                    DragDropEffects.Move);
                }
            }
        }

        private void btnOpnieuw_Click(object sender, RoutedEventArgs e)
        {
            rctField.Visibility = Visibility.Visible;
        }

    }
}
