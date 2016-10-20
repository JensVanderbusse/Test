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
    /// Interaction logic for ScoreBox.xaml
    /// </summary>
    public partial class ScoreBox : Window
    {
        public ScoreBox()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource eenScoreViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("eenScoreViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // eenScoreViewSource.Source = [generic data source]
            using (var ent = new ScoresEntities())
            {
                List<EenScore> aap = new List<EenScore>();
                var leeuw = ent.Scores.OrderByDescending(x=>x.Score).OrderByDescending(x=>x.Lengte);
                foreach (var item in leeuw)
                {
                    aap.Add(new EenScore { Naam = item.Naam, ID = item.ID, Score = item.Score, Datum = item.Datum, Lengte = item.Lengte });
                }
                eenScoreViewSource.Source = aap;
            }
        }
    }
}
