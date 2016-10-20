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
    /// Interaction logic for InputKeys.xaml
    /// </summary>
    public partial class InputKeys : Window
    {
        Key[] toetsen = new Key[4];
        public InputKeys(Key[] keys)
        {
            InitializeComponent();
            tbUp.Text = keys[0].ToString();
            tbDown.Text = keys[1].ToString();
            tbLeft.Text = keys[2].ToString();
            tbRight.Text = keys[3].ToString();
            toetsen = keys;
            tbUp.SelectAll();
            tbUp.Focus();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //controle of keys keys zijn
                //is dit het geval komen we ui bij onderstaande code, anders in het catch blok               
                //niet meer nodig denk ik
                this.DialogResult = true;
            }
            catch
            {
                
            }
        }

        public Key[] Answer
        {
            get{this.Close(); return toetsen;}
        }
        
        private void tbUp_KeyUp(object sender, KeyEventArgs e)
        {
            tbUp.Text = e.Key.ToString();
            toetsen[0] = e.Key;
            tbDown.SelectAll();
            tbDown.Focus();
        }
        private void tbDown_KeyDown(object sender, KeyEventArgs e)
        {
            tbDown.Text = e.Key.ToString();
            toetsen[1] = e.Key;
            tbLeft.SelectAll();
            tbLeft.Focus();
        }
        private void tbLeft_KeyLeft(object sender, KeyEventArgs e)
        {
            tbLeft.Text = e.Key.ToString();
            toetsen[2] = e.Key;
            tbRight.SelectAll();
            tbRight.Focus();
        }
        private void tbRight_KeyRight(object sender, KeyEventArgs e)
        {            
            tbRight.Text = e.Key.ToString();
            toetsen[3] = e.Key;
            btnDialogOk.Focus();
        }


    }
}
