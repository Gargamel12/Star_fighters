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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Star_fighters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player mainhero;
        Player mainvillain;
        public MainWindow()
        {
            InitializeComponent();

            
            

            mainhero = new Player(100,10);
            mainhero.HitBox = new Rectangle();
            mainhero.HitBox.Width = 80;
            mainhero.HitBox.Height = 160;

            mainvillain = new Player(100, 10);
            mainvillain.HitBox= new Rectangle();
            mainvillain.HitBox.Width = 40;
            mainvillain.HitBox.Height = 80;
            
           
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawGame();
        }

        private void DrawGame()
        {
            DrawTerrain();
            DrawPlayer(mainhero);
            
            
        }
        private void DrawPlayer(Player player)
        {
            Image mainhero = new Image();
            mainhero.Height = player.HitBox.Height;
            mainhero.Width = player.HitBox.Width;
            mainhero.Source = new BitmapImage(new Uri("obr/Wormonleft.png", UriKind.Relative));
            Canvas.SetBottom(mainhero, canvas.ActualHeight*0.13);
            Canvas.SetLeft(mainhero, 200);
            canvas.Children.Add(mainhero);

            Image mainvillain = new Image();
            mainvillain.Height = player.HitBox.Height;
            mainvillain.Width = player.HitBox.Width;
            mainvillain.Source = new BitmapImage(new Uri("obr/Wormonright.png", UriKind.Relative));
            Canvas.SetBottom(mainvillain, canvas.ActualHeight * 0.13);
            Canvas.SetRight(mainvillain, 200);
            canvas.Children.Add(mainvillain);
        }
        private void DrawTerrain()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = canvas.ActualWidth; 
            rectangle.Height = canvas.ActualHeight*0.2;
            rectangle.Fill = Brushes.Green;
            Canvas.SetBottom(rectangle,0);

            canvas.Children.Add(rectangle);
        }

        
    }
}
