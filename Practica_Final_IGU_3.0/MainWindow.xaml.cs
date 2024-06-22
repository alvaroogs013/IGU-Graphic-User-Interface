using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Practica_Final_IGU_3._0
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Line ejeX, ejeY;
        private Ventana2 secundaria;
        private Model modelo;
        private bool flag = false;



        //Constructor 
        public MainWindow()
        {
            InitializeComponent();
            secundaria = new Ventana2();
            modelo = new Model();



        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            secundaria = null;
            modelo = null;
            e.Cancel = false;
        }



        private void secundaria_Click(object sender, RoutedEventArgs e)
        {
            secundaria.Owner = this;
            secundaria.ChangeDataHandler += cd_ChangeData;
            secundaria.SwipeHandler += Tabla_SwipeHandler;
            secundaria.AddDataHandler += cd_AddData;
            secundaria.DeleteDataHandler += cd_DeleteDataHandler;

            secundaria.Show();
        }



        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!flag)
            {
                reDibuja();
            }
            else
            {
                dibujaUsos(modelo.repos);
            }
        }

        private void dibujaUsos(ObservableCollection<Repostajes> r)
        {
            Lienzo.Children.Clear();
            DrawEjes();
            double max = 0, max2 = 0, max3 = 0;
            double div, step;
            double per1, per2;
            double per3, per4;
            double per5, per6;
            Polyline p, p2, p3;
            Point punto, punto2, punto3;
            Ellipse el, el2, el3;

            foreach (Repostajes repos in r)
            {
                if (repos.KmParciales > max)
                {
                    max = repos.KmParciales;
                }
                if (repos.Litros > max2)
                {
                    max2 = repos.Litros;
                }
                if (repos.Euros > max3)
                {
                    max3 = repos.Euros;
                }

            }

            div = Lienzo.ActualWidth / r.Count();
            step = 0;
            for (int i = 0; i < 3; i++)
            {
                p = new Polyline();
                p2 = new Polyline();
                p3 = new Polyline();

                foreach (Repostajes repos in r)
                {
                    el = new Ellipse();
                    el2 = new Ellipse();
                    el3 = new Ellipse();

                    per1 = repos.KmParciales / max;
                    per3 = repos.Litros / max2;
                    per5 = repos.Euros / max3;
                    if (per1 <= 0.05)
                    {
                        per1 = 0;
                    }
                    if (per3 <= 0.05)
                    {
                        per3 = 0;
                    }
                    if (per5 <= 0.05)
                    {
                        per5 = 0;
                    }
                    per2 = Lienzo.ActualHeight * (1 - per1);
                    per4 = Lienzo.ActualHeight * (1 - per3);
                    per6 = Lienzo.ActualHeight * (1 - per5);

                    if (per2 == Lienzo.ActualHeight)
                    {
                        per2 = Lienzo.ActualHeight - 10;
                    }

                    if (per4 == Lienzo.ActualHeight)
                    {
                        per4 = Lienzo.ActualHeight - 10;
                    }

                    if (per6 == Lienzo.ActualHeight)
                    {
                        per6 = Lienzo.ActualHeight - 10;
                    }

                    punto = new Point(step, per2);
                    punto2 = new Point(step, per4);
                    punto3 = new Point(step, per6);

                    el.Width = 10;
                    el2.Width = 10;
                    el3.Width = 10;

                    el.Height = 10;
                    el2.Height = 10;
                    el3.Height = 10;

                    el.Fill = Brushes.Red;
                    el2.Fill = Brushes.Purple;
                    el3.Fill = Brushes.Green;

                    el.StrokeThickness = 2;
                    el2.StrokeThickness = 2;
                    el3.StrokeThickness = 2;

                    Canvas.SetLeft(el, step);
                    Canvas.SetLeft(el2, step);
                    Canvas.SetLeft(el3, step);

                    Canvas.SetTop(el, per2 - 3);
                    Canvas.SetTop(el2, per4 - 3);
                    Canvas.SetTop(el3, per6 - 3);

                    p.Points.Add(punto);
                    p2.Points.Add(punto2);
                    p3.Points.Add(punto3);

                    step += div;
                    Lienzo.Children.Add(el);
                    Lienzo.Children.Add(el2);
                    Lienzo.Children.Add(el3);
                }
                p.StrokeThickness = 2;
                p2.StrokeThickness = 2;
                p3.StrokeThickness = 2;

                p.Stroke = Brushes.Red;
                p2.Stroke = Brushes.Purple;
                p3.Stroke = Brushes.Green;

                Lienzo.Children.Add(p);
                Lienzo.Children.Add(p2);
                Lienzo.Children.Add(p3);
                step += div;
            }
        }


        //Funcion para pintar todos los coches guardados con 3 barras para cada coche (probar)
        private void dibujaCoches(ObservableCollection<Coches> data)
        {
            float aux = 0;
            double maxCanvas, per, tam, per2, tam2, per3, tam3;
            Line l1, l2, l3;


            double x1 = 40f, x2 = 40f;

            foreach (Coches c in data)
            {
                if (c.Km > aux)
                {
                    aux = c.Km;
                }
            }

            foreach (Coches c in data)
            {
                maxCanvas = Lienzo.ActualHeight;
                per = c.Km / 1000;
                per2 = c.MediaConsumos;
                per3 = c.MediaCostes;
                tam = maxCanvas * per / 100;
                tam2 = maxCanvas * per2 / 10;
                tam3 = maxCanvas * per3 / 10;


                if (tam > maxCanvas)
                {
                    tam = maxCanvas * per / 1000;

                }

                l1 = new Line();
                l1.StrokeThickness = 20;
                l1.Stroke = Brushes.Red;
                l1.Y1 = Lienzo.ActualHeight - tam;
                l1.X1 = x1;
                l1.X2 = x2;
                l1.Y2 = Lienzo.ActualHeight;

                l2 = new Line();
                l2.StrokeThickness = 20;
                l2.Stroke = Brushes.Purple;
                l2.Y1 = Lienzo.ActualHeight - tam2;
                l2.X1 = l1.X1 + 30;
                l2.X2 = l1.X2 + 30;
                l2.Y2 = Lienzo.ActualHeight;

                l3 = new Line();
                l3.StrokeThickness = 20;
                l3.Stroke = Brushes.Green;
                l3.Y1 = Lienzo.ActualHeight - tam3;
                l3.X1 = l2.X1 + 30;
                l3.X2 = l2.X2 + 30;
                l3.Y2 = Lienzo.ActualHeight;

                Lienzo.Children.Add(l1);
                Lienzo.Children.Add(l2);
                Lienzo.Children.Add(l3);

                TextBlock tb = new TextBlock();
                tb.Text = c.Km.ToString();
                RotateTransform rt = new RotateTransform();
                rt.CenterX = 0.5;
                rt.CenterY = 0.5;
                rt.Angle += -20;
                tb.RenderTransform = rt;
                Canvas.SetBottom(tb, maxCanvas);
                Canvas.SetLeft(tb, l1.X1 - l1.StrokeThickness / 2);
                Lienzo.Children.Add(tb);
                x1 = l1.X1 + Lienzo.ActualWidth / data.Count;
                x2 = l1.X2 + Lienzo.ActualWidth / data.Count;

            }

        }

        private void DrawEjes()
        {
            ejeX = new Line();
            ejeY = new Line();

            ejeX.Stroke = Brushes.Black;
            ejeX.StrokeThickness = 2;
            ejeX.X1 = 0;
            ejeX.X2 = Lienzo.ActualWidth;
            ejeX.Y1 = Lienzo.ActualHeight;
            ejeX.Y2 = ejeX.Y1;
            Lienzo.Children.Add(ejeX);


            ejeY.Stroke = Brushes.Black;
            ejeY.StrokeThickness = 2;
            ejeY.X1 = 0;
            ejeY.X2 = 0;
            ejeY.Y1 = 0;
            ejeY.Y2 = Lienzo.ActualHeight;
            Lienzo.Children.Add(ejeY);

        }

        private void reDibuja()
        {
            Lienzo.Children.Clear();
            dibujaCoches(modelo.data);
            DrawEjes();
        }

        void cd_AddData(object sender, AddDataEventArgs e)
        {
            if (modelo.Add(e.c) && !flag)
                reDibuja();
        }
        void cd_ChangeData(object sender, ChangeDataEventArgs e)
        {
            modelo.DrawRepos(e.repos);
            flag = true;
            //Vuelta.IsEnabled = true;
            dibujaUsos(modelo.repos);
        }

        private void Tabla_SwipeHandler(object sender, SwipeDiagramsEventArgs e)
        {
            flag = e.flag;
            reDibuja();
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cd_DeleteDataHandler(object sender, DeleteDataEventArgs e)
        {
            if (modelo.Delete(e.c))
            {
                flag = false;
                reDibuja();
            }
            else
            {
                return;
            }
        }
    }
}

    
