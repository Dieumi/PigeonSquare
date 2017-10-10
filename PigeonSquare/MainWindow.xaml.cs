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

namespace PigeonSquare
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            dt.Tick += Redessine_Tick;
            dt.Interval = new TimeSpan(0, 0, 0, 0, App.env.vitesse);
            initPlateau();
            Dessine();
            dt.Start();

            Thread tt = new Thread(App.env.Avance);
            tt.Start();
            Dessine();
        }
        private void Redessine_Tick(object sender, EventArgs e)
        {

            Dessine();


        }
        public void Dessine()
        {
            initPlateau();
            foreach (Pigeon p in App.env.listp)
            {
                Image obj = new Image();
            
                Uri urib = new Uri("img/pigeon.jpg", UriKind.Relative);
                obj.Source = new BitmapImage(urib);
               
                  
                
                Plateau.Children.Add(obj);
                Grid.SetColumn(obj, p.Y);
                Grid.SetRow(obj, p.X);

            }
            foreach (Nourriture n in App.env.listn)
            {
                if (n.etat)
                {
                    if (!n.avarie)
                    {
                        Image obj = new Image();

                        Uri urib = new Uri("img/cookie.jpg", UriKind.Relative);
                        obj.Source = new BitmapImage(urib);

                        Plateau.Children.Add(obj);
                        Grid.SetColumn(obj, Convert.ToInt32(n.Y));
                        Grid.SetRow(obj, Convert.ToInt32(n.X));
                  
                    }
                    else
                    {
                        Image obj = new Image();

                        Uri urib = new Uri("img/cookieAvarié.jpg", UriKind.Relative);
                        obj.Source = new BitmapImage(urib);

                        Plateau.Children.Add(obj);
                        Grid.SetColumn(obj, Convert.ToInt32(n.Y));
                        Grid.SetRow(obj, Convert.ToInt32(n.X));
                        App.env.notify();//envoi de notification si avarie est a true
                    }
                }
                else
                {
                    App.env.notify();//envoi de notification si etat est a false
                }
            }

            foreach (Human h in App.env.listh)
            {
                if (h.etat == false)
                {
                    App.env.notify();
                }
                else
                {
                    Image obj = new Image();

                    Uri urib = new Uri("img/human.jpg", UriKind.Relative);
                    obj.Source = new BitmapImage(urib);
                    
                    Plateau.Children.Add(obj);
                    Grid.SetColumn(obj, Convert.ToInt32(h.Y));
                    Grid.SetRow(obj, Convert.ToInt32(h.X));
                }
            }
        }
        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                Console.WriteLine("Colonne : " + e.GetPosition(Plateau).Y.ToString());
                Console.WriteLine("ligne : " + e.GetPosition(Plateau).X.ToString());
                Console.WriteLine("Colonne : " + ColumnComputation(Plateau.ColumnDefinitions, e.GetPosition(Plateau).X).ToString());
                Console.WriteLine("ligne : " + RowComputation(Plateau.RowDefinitions, e.GetPosition(Plateau).Y).ToString());
         
            double test1 = ColumnComputation(Plateau.ColumnDefinitions, e.GetPosition(Plateau).X);
            double test2 = RowComputation(Plateau.RowDefinitions, e.GetPosition(Plateau).Y);
            AjouteNourriture(test1,test2);
                

        }
        private void AjouteNourriture(double Y,double X)
        {
            App.env.listn.Add(new Nourriture(X, Y));
            App.env.notify();
        }
        private double ColumnComputation(ColumnDefinitionCollection c, double YPosition)
        {
            var columnLeft = 0.0; var columnCount = 0;
            foreach (ColumnDefinition cd in c)
            {
                double actWidth = cd.ActualWidth;
                if (YPosition >= columnLeft && YPosition < (actWidth + columnLeft)) return columnCount;
                columnCount++;
                columnLeft += cd.ActualWidth;
            }
            return (c.Count + 1);
        }
        private double RowComputation(RowDefinitionCollection r, double XPosition)
        {
            var rowTop = 0.0; var rowCount = 0;
            foreach (RowDefinition rd in r)
            {
                double actHeight = rd.ActualHeight;
                if (XPosition >= rowTop && XPosition < (actHeight + rowTop)) return rowCount;
                rowCount++;
                rowTop += rd.ActualHeight;
            }
            return (r.Count + 1);
        }
        public void initPlateau()
        {
            Plateau.ColumnDefinitions.Clear();
            Plateau.RowDefinitions.Clear();
            Plateau.Children.Clear();
            for (int i = 0; i < App.env.DimensionX; i++)
            {
                Plateau.RowDefinitions.Add(new RowDefinition());

            }
            for (int j = 0; j < App.env.DimensionY; j++)
            {
                Plateau.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}
