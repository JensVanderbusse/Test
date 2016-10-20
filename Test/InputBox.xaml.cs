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
    /// Interaction logic for InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {
        public InputBox(string question)
        {
            InitializeComponent();
            lblQuestion.Content = question;
        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtAnswer.Text.Length == 0)
            {
                MessageBox.Show("geef uw naam");
            }
            else if (txtAnswer.Text.Length > 50)
            {
                MessageBox.Show("te lange naam");
            }
            else
            {
                this.DialogResult = true;
            }
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }
        public string Answer
        {
            get { this.Close(); return txtAnswer.Text; }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
