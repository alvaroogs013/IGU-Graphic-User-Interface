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
using System.Windows.Shapes;

namespace Practica_Final_IGU_3._0
{
    /// <summary>
    /// Lógica de interacción para Ventana2.xaml
    /// </summary>
    public class AddDataEventArgs : EventArgs { public Coches c; }
    public class SwipeDiagramsEventArgs : EventArgs { public bool flag; }
    public class ChangeDataEventArgs : EventArgs { public ObservableCollection<Repostajes> repos;}
    public class DeleteDataEventArgs : EventArgs { public Coches c; }

    public partial class Ventana2 : Window
    {
        public event EventHandler<AddDataEventArgs> AddDataHandler;
        public event EventHandler<SwipeDiagramsEventArgs> SwipeHandler;
        public event EventHandler<DeleteDataEventArgs> DeleteDataHandler;
        public event EventHandler<ChangeDataEventArgs> ChangeDataHandler;


        private ObservableCollection<Coches> myData;
        public Ventana2()
        {
            InitializeComponent();
            myData = new ObservableCollection<Coches>();
            Tabla1.ItemsSource = myData;
            Id.IsEnabled = false;


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }


        private void Tabla1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tabla1.SelectedIndex < 0)
            {
                Tabla2.ItemsSource = null;
                gridReposajes.IsEnabled = false;
                gridCoches.IsEnabled = true;
                Eliminar.IsEnabled = false;
                Id.Text = "";
                Añadir.IsEnabled = false;
                datos.Header = "Entrada de Datos";
                SwipeDiagramsEventArgs args = new SwipeDiagramsEventArgs();
                args.flag = false;
                OnSwipe(args);

            }
            else
            {
                Eliminar.IsEnabled = true;
                gridReposajes.IsEnabled = true;
                gridCoches.IsEnabled = false;
                datos.Header = "Entrada de Usos";
                Id.Text = myData[Tabla1.SelectedIndex].Matricula;
                Coches c = myData[Tabla1.SelectedIndex];
                Tabla2.ItemsSource = c.Repos;
                ChangeDataEventArgs args = new ChangeDataEventArgs();
                args.repos = c.Repos;
                OnChangeData(args);
                

            }
        }

        private void Añadir_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Coches> c = new ObservableCollection<Coches>();
            Coches aux = new Coches();
            AddDataEventArgs args;
            bool flag = true;
            if (EntradaMatricula.Text.Length > 0)
            {
                aux.Matricula = EntradaMatricula.Text;
                if (EntradaMarca.Text.Length > 0)
                {
                    aux.Marca = EntradaMarca.Text;
                    if (EntradaModelo.Text.Length > 0)
                    {
                        aux.Modelo = EntradaModelo.Text;
                        if (EntradaKm.Text.Length > 0)
                        {
                            aux.Km = int.Parse(EntradaKm.Text);
                            if (EntradaCv.Text.Length > 0)
                            {
                                aux.Cv = int.Parse(EntradaCv.Text);
                                if (EntradaCombustible.Text.Length > 0)
                                {
                                    aux.Combustible = EntradaCombustible.Text;
                                    if (EntradaCambio.Text.Length > 0)
                                    {
                                        aux.Cambio = EntradaCambio.Text;
                                        if (EntradaAsientos.Text.Length > 0)
                                        {
                                            aux.NumAsientos = int.Parse(EntradaAsientos.Text);
                                            if (Categoria != null)
                                            {
                                                aux.Categoria = Categoria.Text;
                                                myData.Add(aux);
                                                Añadir.IsEnabled = false;
                                                lista.Focus();
                                                args = new AddDataEventArgs();
                                                args.c = aux;
                                                OnAddData(args);
                                                EntradaMatricula.Text = "";
                                                EntradaMarca.Text = "";
                                                EntradaModelo.Text = "";
                                                EntradaKm.Text = "";
                                                EntradaCv.Text = "";
                                                EntradaCombustible.Text = "";
                                                EntradaCambio.Text = "";
                                                EntradaAsientos.Text = "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            EntradaMatricula.Text = "";
            EntradaMarca.Text = "";
            EntradaModelo.Text = "";
            EntradaKm.Text = "";
            EntradaCv.Text = "";
            EntradaCombustible.Text = "";
            EntradaCambio.Text = "";
            EntradaAsientos.Text = "";

            Calendario.SelectedDate = DateTime.Now;
            EntradaKmParciales.Text = "";
            EntradaLitros.Text = "";
            EntradaCoste.Text = "";

            Añadir.IsEnabled = false;
            lista.Focus();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            int index = Tabla1.SelectedIndex;
            if(index >= 0)
            {
                DeleteDataEventArgs args = new DeleteDataEventArgs();
                args.c = myData[index];
                OnDeleteData(args);

            } else
            {
                return;
            }
        }

       
        private void AñadirUso_Click(object sender, RoutedEventArgs e)
        {
            Repostajes r = new Repostajes();
            
            if(gridReposajes.IsEnabled == true)
            {
                if (Calendario.SelectedDate.HasValue)
                {
                    r.Fecha = Calendario.SelectedDate.ToString().Substring(0,10);
                    if(EntradaKmParciales.Text.Length > 0)
                    {
                        r.KmParciales = int.Parse(EntradaKmParciales.Text);
                        if (EntradaLitros.Text.Length > 0)
                        {
                            r.Litros = float.Parse(EntradaLitros.Text);
                            if (EntradaCoste.Text.Length > 0)
                            {
                                r.Euros = float.Parse(EntradaCoste.Text);
                                myData[Tabla1.SelectedIndex].Repos.Add(r);
                                calcularMedias();
                                lista.Focus();
                                Calendario.SelectedDate = null;
                                EntradaKmParciales.Text = "";
                                EntradaLitros.Text = "";
                                EntradaCoste.Text = "";
                            }
                        }
                    }
                }
            }

            
        }

        private void calcularMedias()
        {

            int totalKm = 0;
            float totalLitros = 0;
            float totalEuros = 0;
            if (myData[Tabla1.SelectedIndex].Repos != null)
            {
                for (int i = 0; i < myData[Tabla1.SelectedIndex].Repos.Count(); i++)
                {
                    totalKm += myData[Tabla1.SelectedIndex].Repos[i].KmParciales;
                    totalLitros += myData[Tabla1.SelectedIndex].Repos[i].Litros;
                    totalEuros += myData[Tabla1.SelectedIndex].Repos[i].Euros;
                }

                myData[Tabla1.SelectedIndex].Km += totalKm;
                myData[Tabla1.SelectedIndex].MediaConsumos = (totalLitros * 100) / totalKm;
                myData[Tabla1.SelectedIndex].MediaCostes = myData[Tabla1.SelectedIndex].MediaConsumos * (totalEuros / totalLitros);
            }
        }

        private void EntradaMatricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            Añadir.IsEnabled = true;
        }

        protected virtual void OnAddData(AddDataEventArgs e)
        {
            AddDataHandler?.Invoke(this, e);
        }
        protected virtual void OnChangeData(ChangeDataEventArgs e)
        {
            ChangeDataHandler?.Invoke(this, e);
        }
        protected virtual void OnSwipe(SwipeDiagramsEventArgs e)
        {
            SwipeHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteData(DeleteDataEventArgs e)
        {
            DeleteDataHandler?.Invoke(this, e);
        }
    }
}
