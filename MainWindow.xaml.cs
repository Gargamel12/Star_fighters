﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        private Player movingPlayer;
        private Player player1;
        private Player player2;
        private ShotTrajectory trajectory;

        public MainWindow()
        {
            InitializeComponent();

            trajectory = new ShotTrajectory();

            player1 = new Player(500, 20);
            player1.HitBox = new Rectangle();
            player1.HitBox.Width = 110;
            player1.HitBox.Height = 160;

            player2 = new Player(500, 20);
            player2.HitBox = new Rectangle() { Width = 110, Height = 160 };

            Random random = new Random();
            int value = random.Next(0, 2);
            if (value == 0)
            {
                movingPlayer = player1;
            }
            else
            {
                movingPlayer = player2;
            }

            this.Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawGame();
        }

        private void DrawGame()
        {
            canvas.Children.Clear();
            DrawTerrain();
            DrawPlayer(player1, true);
            DrawPlayer(player2, false);
        }
        private void DrawTerrain()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = canvas.ActualWidth;
            rectangle.Height = canvas.ActualHeight * 0.1;
            rectangle.Fill = Brushes.Green;

            Canvas.SetLeft(rectangle, 0);
            Canvas.SetBottom(rectangle, 0);

            canvas.Children.Add(rectangle);
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (movingPlayer == player1)
            {
                movingPlayer = player2;
            }
            else
            {
                movingPlayer = player1;
            }
            DrawGame();
        }

        private void DrawPlayer(Player player, bool left)
        {
            Image image = new Image();
            image.Height = player.HitBox.Height;
            image.Width = player.HitBox.Width;
            image.Stretch = Stretch.Fill;
            image.Source = new BitmapImage(new Uri("obr/Wormonleft.png", UriKind.Relative));

            Polygon? polygon = null;
            if (movingPlayer == player)
            {
                polygon = new Polygon();
                polygon.Points.Add(new Point(0, 0));
                polygon.Points.Add(new Point(20, 0));
                polygon.Points.Add(new Point(10, 30));
                polygon.Fill = Brushes.Red;
            }

            if (polygon != null)
            {
                Canvas.SetBottom(polygon, canvas.ActualHeight * 0.05 + image.Height + 20);
            }
            Canvas.SetBottom(image, canvas.ActualHeight * 0.05);
            if (left)
            {
                if (polygon != null)
                {
                    Canvas.SetLeft(polygon, image.Width / 2);
                }
                Canvas.SetLeft(image, 20);
            }
            else
            {
                if (polygon != null)
                {
                    Canvas.SetRight(polygon, image.Width / 2);
                }
                Canvas.SetRight(image, 20);
                image.LayoutTransform = new ScaleTransform(-1, 1);
            }

            canvas.Children.Add(image);
            if (polygon != null)
            {
                canvas.Children.Add(polygon);
            }

            if (movingPlayer == player)
            {
                DrawTrajectory();
            }

        }

        
        private void DrawTrajectory()
        {
            foreach (UIElement element in canvas.Children.OfType<Line>().ToList())
            {
                canvas.Children.Remove(element);
            }

            // Create a line representing the trajectory
            Line trajectoryLine = new Line();
            trajectoryLine.Stroke = Brushes.Blue;
            trajectoryLine.StrokeThickness = 2;

            // Set the starting point (e.g., the player's gun position)
            double startX = movingPlayer == player1 ? 110 : canvas.ActualWidth - 70;
            double startY = canvas.ActualHeight * 0.8 + player1.HitBox.Height / 2;

            trajectoryLine.X1 = startX;
            trajectoryLine.Y1 = startY;

            // Calculate the angle in degrees (assuming trajectory.Angle is in degrees)
            double angleInDegrees = trajectory.Angle;

            // Calculate the length of the trajectory line
            double length = trajectory.Length;

            // Calculate the ending point based on the angle and length of the shot
            double endX = startX + length * Math.Cos(Math.PI * angleInDegrees / 180.0);

            double endY;

            // Zajistěte, aby endY bylo vždy v rámci viditelné oblasti plátna
            if (movingPlayer == player1)
            {
                endY = startY - length * Math.Sin(Math.PI * angleInDegrees / 180.0);
            }
            else
            {
                endY = Math.Max(0, Math.Min(canvas.ActualHeight, startY + length * Math.Sin(Math.PI * angleInDegrees / 180.0)));
            }

            trajectoryLine.X2 = endX;
            trajectoryLine.Y2 = endY;

            if (movingPlayer != player1)
            {
                // Vertikální otočení čáry trajektorie
                ScaleTransform scaleTransform = new ScaleTransform(1, -1);
                trajectoryLine.RenderTransform = scaleTransform;
            }

            canvas.Children.Add(trajectoryLine);
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (movingPlayer != null)
            {
                if (e.Key == Key.Up)
                {
                    // Increase the angle
                    trajectory.Angle += 1;
                    DrawGame();
                }
                else if (e.Key == Key.Down)
                {
                    // Decrease the angle
                    trajectory.Angle -= 1;
                    DrawGame();
                }
                else if (e.Key == Key.Right)
                {
                    // Increase the length
                    trajectory.Length += 10;
                    DrawGame();
                }
                else if (e.Key == Key.Left)
                {
                    // Decrease the length
                    if (trajectory.Length > 10)
                    {
                        trajectory.Length -= 10;
                        DrawGame();
                    }
                }
            }
        }
    }
}
