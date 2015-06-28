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

namespace Drawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //this.Loaded += MainWindow_Loaded;
            //this.MouseDown += MainWindow_MouseDown;

            this.MouseUp += Window_MouseUp;

        }

        

        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);

            SolidColorBrush newColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            Color newCol = Color.FromRgb(255, 255, 0);
            Color newCol2 = Color.FromRgb(255, 255, 255);

            Ellipse el1 = new Ellipse();
            el1.Height = 40;
            el1.Width = 40;
            RadialGradientBrush rgb = new RadialGradientBrush();
            GradientStop gsa = new GradientStop();
            el1.StrokeThickness = 3;
            el1.Stroke = newColor;
            el1.StrokeDashArray = new DoubleCollection() { 6, 6 };
            gsa.Color = newCol;
            gsa.Offset = 0;
            rgb.GradientStops.Add(gsa);
            GradientStop gsb = new GradientStop();
            gsb.Color = newCol2;
            gsb.Offset = 1;
            rgb.GradientStops.Add(gsb);
            el1.Fill = rgb;

            
            

            Ellipse el2 = new Ellipse();
            el2.Height = 40;
            el2.Width = 40;
            el2.StrokeThickness = 3;
            el2.Stroke = newColor;

            //el2.Fill = new SolidColorBrush(Colors.Transparent);
            Canvas.SetLeft(el1, p.X);
            Canvas.SetTop(el1, p.Y);
            //Canvas canvas = new Canvas();
            canvas.Children.Add(el1);
            //canvas.Children.Add(el2);
            TextBlock txt = new TextBlock();
            txt.Text = "\n  sdsdsdd ";
            txt.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            txt.Height = 60;
            txt.Width = 60;
            txt.HorizontalAlignment = HorizontalAlignment.Center;
            //txt.VerticalAlignment = VerticalAlignment.Bottom;
            txt.FontSize = 12;
            canvas.Children.Add(txt);

            
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //SolidColorBrush newColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //Color newCol = Color.FromRgb(255, 255, 0);
            //Color newCol2 = Color.FromRgb(255, 255, 255);

            //Ellipse el1 = new Ellipse();
            //el1.Height = 40;
            //el1.Width = 40;
            //RadialGradientBrush rgb = new RadialGradientBrush();
            //GradientStop gsa = new GradientStop();
            //el1.StrokeThickness = 3;
            //el1.Stroke = newColor;
            //el1.StrokeDashArray = new DoubleCollection() { 6, 6 };
            //gsa.Color = newCol;
            //gsa.Offset = 0;
            //rgb.GradientStops.Add(gsa);
            //GradientStop gsb = new GradientStop();
            //gsb.Color = newCol2;
            //gsb.Offset = 1;
            //rgb.GradientStops.Add(gsb);
            //el1.Fill = rgb;

            //Ellipse el2 = new Ellipse();
            //el2.Height = 40;
            //el2.Width = 40;
            //el2.StrokeThickness = 3;
            //el2.Stroke = newColor;

            ////el2.Fill = new SolidColorBrush(Colors.Transparent);

            ////Canvas canvas = new Canvas();
            //canvas.Children.Add(el1);
            ////canvas.Children.Add(el2);
            //TextBlock txt = new TextBlock();
            //txt.Text = "\n  sdsdsdd ";
            //txt.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            //txt.Height = 60;
            //txt.Width = 60;
            //txt.HorizontalAlignment = HorizontalAlignment.Center;
            ////txt.VerticalAlignment = VerticalAlignment.Bottom;

            //txt.FontSize = 12;
            //canvas.Children.Add(txt);
            ////Border border = new Border();
            ////border.BorderBrush = newColor;
            ////border.BorderThickness = new Thickness(2);
            ////border.Child = canvas;
            ////LocationRect lr = new LocationRect(North, West, South, East);
            ////HotspotLayer.AddChild(ele, lr);
        }

        bool boolean = false;

        Point? p = null;
        
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            double x = p.X;
            double y = p.Y;

            if (boolean == false)
            {
                Ellipse elps = new Ellipse();
                elps.Width = 20;
                elps.Height = 20;
                elps.Fill = Brushes.Aqua;

                elps.MouseDown += lineBetweenElipses;

                Canvas.SetLeft(elps, x);
                Canvas.SetTop(elps, y);

                canvas.Children.Add(elps);
            }
            boolean = false;
                 
           
            

            

            
        }
        Point? _lineStart = null;
        Point? _lineEnd = null;
        void lineBetweenElipses(object sender, MouseButtonEventArgs e) 
        {

            boolean = true;
            if (_lineStart == null)
            {
                _lineStart = e.GetPosition(this);

            }
            else
            {
                _lineEnd = e.GetPosition(this);

                Line lne = new Line();
                lne.X1 = _lineStart.Value.X;
                lne.X2 = _lineEnd.Value.X;
                lne.Y1 = _lineStart.Value.Y;
                lne.Y2 = _lineEnd.Value.Y;
                lne.Stroke = Brushes.Red;
                lne.StrokeThickness = 2;
                Canvas.SetLeft(lne, 0);
                Canvas.SetTop(lne, 0);
                canvas.Children.Add(lne);
                _lineStart = null;
            }
            


            //    bool isSecondElipse = false;
            //    if (isSecondElipse == false)
            //    { 
            //}
                    
        }
        //void rect_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    _wasMouseDownRemoveRectCalled = true;
        //    canvas.Children.Remove((Ellipse)sender);
        //}

        

        
    }

    
}
