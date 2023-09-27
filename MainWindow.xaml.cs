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

            DrawGame();

            mainhero = new Player(100,10);
            mainhero.HitBox = new Rectangle();
            mainhero.HitBox.Width = 40;
            mainhero.HitBox.Height = 80;

            mainvillain = new Player(100, 10);
            mainvillain.HitBox= new Rectangle();
            mainvillain.HitBox.Width = 40;
            mainvillain.HitBox.Height = 80;
            
        }
        private void DrawGame()
        {
            DrawTerrain();
            DrawPlayer(mainhero);
            DrawPlayer(mainvillain);
            
        }
        private void DrawPlayer(Player player)
        {

        }
        private void DrawTerrain()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = canvas.ActualWidth; 
            rectangle.Height = canvas.ActualHeight/100*20;
            rectangle.Fill = Brushes.Green;

            canvas.Children.Add(rectangle);
        }
    }
}
