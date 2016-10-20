using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Snake.xaml
    /// </summary>
    public partial class Snake : Window
    {   
        //P.S. veel code tussen commentaar is oude code uit de tijd dat de slang niet langer kon worden.
        //eten kan in de slang verschijnen. Niet te moeilijk aan te passen, maar heb nog geen moeite gedaan.

        //opgelost:
        //je kan 180° draaien wat resulteerd in je dood. 
            //een simpele controle als geen left als right is niet goed:
                //je kan onder en left gan tussen 1 timer tick waardoor je toch sterft
            //Oplossing nieuwe bool maken die aangeeft ofdat er deze tick al veranderd is.
            //Deze springt op false bij idere tick.
        //nieuw probleem je kan geen 180° draaien als je maar 1 lang bent
        bool blnMoveLeft, blnMoveRight, blnMoveUp, blnMoveDown, dynamic, veranderd = false;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        int aantalGames, score, highscore, difficulty, spelGroote;  //score = aantal targets opgegeten
        int[,] slangArray = new int[255, 2];     //array die bijhoud waar de slang zit / [i,0] geeft x-pos, [i,1] geeft y-pos op i-de plaats / Slang is i lang en kan niet groter worden dan 255(misschien beter doen met een list)
        Label[,] veldArray = new Label[40, 40];  //array die elk stukje veld een label geeft, door de labels een kleur te geven krijgt de slang een plaats
        Label target = new Label();
        Stuff m = new Stuff();
        int score2;                             // score aangepast zodat het iets leuker is dan aantal opgegeten//score aanpassen zodat bijkomende score2 = score2+ score*300/intervaltijd
        //Image foto;


        public Snake()
        {
            spelGroote = 20;
            InitializeComponent();
            InitialiseerVeld();
            aantalGames = 0;
            highscore = 0;
            difficulty = 2;
            rb2.IsChecked = true;
            gemiddeld.IsChecked = true;
            this.highscore = Properties.Settings.Default.highscore; // ◄--oorspronkelijke versie(haalt geen score uit database)
            lblHighScore.Content = highscore;   
        }
        public void StartGame(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < spelGroote; i++)
            {
                for (int j = 0; j < spelGroote; j++)
                {
                    veldArray[i, j].Background = new SolidColorBrush(Color.FromArgb(100, 0, 100, 0));
                }
            }
            score = 0;
            score2 = 0;
            //snake.SetValue(Grid.ColumnProperty, 10);
            //snake.SetValue(Grid.RowProperty, 10);
            slangArray[0, 0] = spelGroote/2-1;
            slangArray[0, 1] = spelGroote/2-1; 
            if (aantalGames > 0)
            {
                removeEvent(TimerTick);
            }
            addEvent(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300/difficulty);
            timer.Start();
            aantalGames++;
            lblGespeeld.Content = aantalGames;
            m.RandomLocation(target, spelGroote);
            target.Visibility = Visibility.Visible;
            blnMoveDown = blnMoveLeft = blnMoveRight = blnMoveUp = false;   //als we niet alles op false zetten krijgen we soms problemen bij de start: 
                                                                            //vb: als je dood ging tewijl je naar beneden ging kan je het volgende spel niet naar boven starten.
            //blnMoveRight = true;      //zo start hij met naar rechts te bewegen


        }
        private void TimerTick(object sender, EventArgs e)
        {
            veranderd = false;     
            if (blnMoveRight)
            {                
                TMBeweegSlang();
                slangArray[0, 0] = slangArray[0, 0] + 1;                     //dit misschien in een aparte method proppen?
                if (slangArray[0, 0] == spelGroote || ControleSlang())
                    GameOver("Game Over   score= ");
                //else
                //{
                //    snake.SetValue(Grid.ColumnProperty, (int)snake.GetValue(Grid.ColumnProperty) + 1);   
                //}
            }
            else if (blnMoveLeft)
            {
                TMBeweegSlang();
                slangArray[0, 0] = slangArray[0, 0] - 1;
                if (slangArray[0, 0] == -1 || ControleSlang())
                    GameOver("Game Over   score= ");
                //else
                //{
                //    snake.SetValue(Grid.ColumnProperty, (int)snake.GetValue(Grid.ColumnProperty) - 1);                    
                //}            
            }
            else if (blnMoveUp)
            {
                TMBeweegSlang();
                slangArray[0, 1] = slangArray[0, 1] - 1;
                if (slangArray[0, 1] == -1 || ControleSlang())
                    GameOver("Game Over   score= ");
                //else
                //{
                //    snake.SetValue(Grid.RowProperty, (int)snake.GetValue(Grid.RowProperty) - 1);                    
                //}
            }
            else if (blnMoveDown)
            {
                TMBeweegSlang();
                slangArray[0, 1] = slangArray[0, 1] + 1;
                if (slangArray[0, 1] == spelGroote || ControleSlang())
                    GameOver("Game Over   score= ");
                //else
                //{
                //    snake.SetValue(Grid.RowProperty, (int)snake.GetValue(Grid.RowProperty) + 1);
                //}
            }
            //if (((int)snake.GetValue(Grid.RowProperty) == (int)target.GetValue(Grid.RowProperty)) && ((int)snake.GetValue(Grid.ColumnProperty) == (int)target.GetValue(Grid.ColumnProperty)))
            if(slangArray[0,1]== (int)target.GetValue(Grid.RowProperty) && slangArray[0,0]== (int)target.GetValue(Grid.ColumnProperty))
            {
                score++;
                try
                {
                    score2 = score2 + score * 300 / Int32.Parse(timer.Interval.Milliseconds.ToString());
                }
                catch
                {
                    MessageBox.Show("iets ging mis bij berekenen score " + timer.Interval.Milliseconds.ToString());
                }
                lblScore.Content = score2;
                lblLengte.Content = score + 1;
                m.RandomLocation(target, spelGroote);
                if (dynamic && score < 195) 
                {
                    timer.Interval = new TimeSpan(0, 0, 0, 0, 300 - score*10);
                }
            }
            TM2();
        }

        //oorspronkelijk kon je 180° draaien en zelfmoord plegen
        //veranderd door een controle toe te voegen
        //als we deze niet doen kan je alles met //* na de ode weglaten
        //reden is ergens tussen code uitgelegd        
        private void UpMethod(object sender, RoutedEventArgs e)
        {
            //de bedoeling van de volgende code was te maken dat je geen 180° kan draaien.
            //het gaf wat problemen: je kan meerdere controls gebruiken voordat de timer tikt zodat je toch 180° kon draaien
            //
            //if (!blnMoveDown)
            //{
            //    blnMoveDown = false;
            //    blnMoveLeft = false;
            //    blnMoveRight = false;
            //    blnMoveUp = true;
            //}
            if (!veranderd && !blnMoveDown)
            {
                veranderd = true;
                blnMoveLeft = false;
                blnMoveRight = false;
                blnMoveUp = true;
                blnMoveDown = false;//*
            }
        }
        private void DownMethod(object sender, RoutedEventArgs e)
        {
            if (!veranderd && !blnMoveUp)
            {
                veranderd = true;
                blnMoveDown = true;
                blnMoveLeft = false;
                blnMoveRight = false;
                blnMoveUp = false;
            }
        }
        private void LeftMethod(object sender, RoutedEventArgs e)
        {
            if (!veranderd && !blnMoveRight)
            {
                veranderd = true;
                blnMoveLeft = true;
                blnMoveRight = false;
                blnMoveDown = false;//*
                blnMoveUp = false;//*
            }
        }
        private void RightMethod(object sender, RoutedEventArgs e)
        {
            if (!veranderd && !blnMoveLeft)
            {
                veranderd = true;
                blnMoveRight = true;              // de reden waarom we andere richtingen niet op false zetten is is omdat rechts eerst gecontroleerd wordt in TimerTick()
                blnMoveUp = false;//*
                blnMoveLeft = false;//*
                blnMoveDown = false;//*
            }
        }

        public void addEvent(EventHandler ev)
        {
            timer.Tick += ev;
        }
        public void removeEvent(EventHandler ev)
        {
            timer.Tick -= ev;
        }
        public void GameOver(string tekst)
        {
            MessageBox.Show(tekst + score2);
            target.Visibility = Visibility.Hidden;
            timer.Stop();
            if (score2 > highscore)
            {
                highscore = score2;
                lblHighScore.Content = highscore;
                MessageBox.Show("proficiat u hebt de hoogste score");
            }
            try
            {
                InputBox inputDialog = new InputBox("Please enter your name:");
                string machamp = "";
                if (inputDialog.ShowDialog() == true)
                    machamp = inputDialog.Answer;
                else              //als inputbox gesloten wordt zonder naam in te geven wordt de naam anonymous
                    machamp = "anonymous";
                using (var ent = new ScoresEntities())
                {
                    ent.Scores.Add(new EenScore { Naam = machamp, Datum = DateTime.Today, Lengte = score + 1, Score = score2 });
                    ent.SaveChanges();
                }
            }
            catch (Exception hitmonlee)
            {
                MessageBox.Show(hitmonlee.Message);
            }
        }
        //public void RandomLocation()             //verwijderd: eens in een apparte klasse gestoken
        //{
        //    Random r = new Random();
        //    target.SetValue(Grid.ColumnProperty, r.Next(spelGroote));
        //    target.SetValue(Grid.RowProperty, r.Next(spelGroote));
        //}
        public void RadioDifficulty(object sender, RoutedEventArgs e)
        {
            RadioButton knop = (RadioButton)sender;
            try
            {
                difficulty = Int32.Parse(knop.Content.ToString());
                lblDifficulty.Content = difficulty;
                dynamic = false;
            }
            catch
            {
                dynamic = true;
                difficulty = 1;
                lblDifficulty.Content = "dynamic";
            }
        }        
        private void Window_Closing(object sender, CancelEventArgs e)
        {            
            Properties.Settings.Default.highscore = this.highscore;
            Properties.Settings.Default.Save();                      
            MainWindow o = new MainWindow();
            o.Show();        
        }
        public void ResetHighscore(object sender, RoutedEventArgs e)
        {
            highscore = 0;
            lblHighScore.Content = highscore;
        }
        public void TMBeweegSlang()
        {
            for (int i = score+1; i > 0; i--)
            {
                try
                {
                    slangArray[i, 0] = slangArray[i - 1, 0];
                    slangArray[i, 1] = slangArray[i - 1, 1];
                }
                catch          //zal normaal komen bij een IndexOutOfRange exeption (misschien beter met if score>255)
                {
                    GameOver("proficiat, u hebt het spel uitgespeeld.");
                }
            }                     
        }
        public void TM2() //(TickMethod2)
        {
            try
            {                
                //foto = m.GetImage();
                veldArray[slangArray[0, 0], slangArray[0, 1]].Background = new ImageBrush(new BitmapImage(new Uri("C:/Users/user/Documents/Oefeningen Jens/VS/WPF/Test/Test/Images/bold.png", UriKind.Relative)));
                veldArray[slangArray[score + 1, 0], slangArray[score + 1, 1]].Background = new SolidColorBrush(Color.FromArgb(100, 0, 100, 0));
            }
            catch  //vangt de index out of range exeption op de we krijgen na een verloren spel(de locatie vande slang zit buiten veld)
            {
                for (int i = 0; i < spelGroote; i++)
                {
                    for (int j = 0; j < spelGroote; j++)
                    {                        
                        veldArray[i, j].Background = new SolidColorBrush(Color.FromArgb(100, 0, 100, 0));
                    }
                }
            }

        }
        public bool ControleSlang()
        {
            for (int i = 1; i < score+2; i++)
            {
                if (slangArray[i, 0] == slangArray[0, 0] && slangArray[i, 1] == slangArray[0, 1])
                    return true;
            }
            return false;
        }
        private void InitialiseerVeld()
        {
            speelveld.Children.Clear(); // !!! heel belangrijk om gehuegen te sparen !!!   --► zie windows task manager (als we de grootte van het veld enkele keren aanpassen wordt het geheugen steeds meer belast) 
            speelveld.RowDefinitions.Clear();
            speelveld.ColumnDefinitions.Clear();                       
            target.Background = new SolidColorBrush(Colors.Red);

            //Grid.SetColumn(target, 5);
            //Grid.SetRow(target, 5);
            target.Visibility = Visibility.Hidden;
            speelveld.Children.Add(target);
            

            for (int i = 0; i < spelGroote; i++)
            {
                speelveld.ColumnDefinitions.Add(new ColumnDefinition());
                speelveld.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < spelGroote; i++)
            {
                for (int j = 0; j < spelGroote; j++)
                {
                    veldArray[i, j] = new Label();
                    veldArray[i, j].Background = new SolidColorBrush(Color.FromArgb(100,0,100,0));

                    Grid.SetColumn(veldArray[i, j], i);
                    Grid.SetRow(veldArray[i, j], j);
                    speelveld.Children.Add(veldArray[i, j]);
                }
            }
        }
        public void RadioGroot(object sender, RoutedEventArgs e)
        {
            RadioButton knop = (RadioButton)sender;
            if (knop.Content.ToString() == "small")
                spelGroote = 10;
            else if (knop.Content.ToString() == "average")
                spelGroote = 20;
            else
                spelGroote = 40;
            InitialiseerVeld();
        }
        public void Controls(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Working on this one");   //bedoeling is dat je de controls kan instellen voor mensen met qwerty toetsenbord.
                                                      //iets in de aard van:
            //messagebox.Show("Up?")
            //Key keyUp = inputBox()              //maak een inputBox ding
            //messagebox.Show("Down?")
            //Key keyDown = inputBox()
            //messagebox.Show("Left?")
            //Key keyLeft = inputBox()
            //messagebox.Show("Right?")
            //Key keyRight = inputBox()
        }
        public void GetHighscores(object sender, RoutedEventArgs e)
        {
            ScoreBox p = new ScoreBox();
            p.Show();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //---------------------
            //probleem waar lange tijd op gezocht werd:
            //((Panel)Application.Current.MainWindow.Content).ActualHeight
            //denk dat dit de groote van het oorspronkelijke window zoekt, dit bestaat niet meer.
            //MainWindow in die code heeft niets te maken met de naam van het oorspronkelijke wat ook main window is,
            //want als we in app.xaml snake als opstart gebruiken werkt dit wel.
            //---------------------
            double? min = 200;
            try
            {
                //    MessageBox.Show(((Panel)Application.Current.MainWindow.Content).ActualHeight + "");
                //min = (double?)((Panel)Application.Current.MainWindow.Content).ActualHeight;
                min = (double?)e.NewSize.Height;
                //    MessageBox.Show(((Panel)Application.Current.MainWindow.Content).ActualHeight + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if ((double?)e.NewSize.Width < (double?)e.NewSize.Height)
                {
                    try
                    {
                        min = (double?)e.NewSize.Width;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            min -= 111;
            if (min < 200)
            {
                min = 200;
            }
            speelveld.Height = (double)min;
            speelveld.Width = (double)min;
            //double? min = 200;
            //try
            //{
            //    MessageBox.Show(((Panel)Application.Current.MainWindow.Content).ActualHeight + "");
            //    min = (double?)((Panel)Application.Current.MainWindow.Content).ActualHeight;
            //    MessageBox.Show(((Panel)Application.Current.MainWindow.Content).ActualHeight + "");
            //}catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //try
            //{
            //    if ((double?)((Panel)Application.Current.MainWindow.Content).ActualHeight < (double?)((Panel)Application.Current.MainWindow.Content).ActualWidth)
            //    {
            //        try
            //        {
            //            min = (double?)((Panel)Application.Current.MainWindow.Content).ActualWidth;
            //        }
            //        catch
            //        {

            //        }
            //    }
            //}
            //catch
            //{

            //}
            //min -= 111;
            //if (min < 200)
            //{
            //    min = 200;
            //}
            //speelveld.Height = (double)min;
            //speelveld.Width = (double)min;
            //MessageBox.Show(((Panel)Application.Current.MainWindow.Content).ActualHeight + "");
            //aanpassen
            //speelveld.Width = 
        }
        
    }
}
