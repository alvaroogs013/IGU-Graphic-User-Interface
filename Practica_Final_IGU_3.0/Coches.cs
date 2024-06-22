using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Practica_Final_IGU_3._0
{
    public class Coches : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Atributos 
        private string matricula;
        private string marca;
        private string modelo;
        private int km;
        private int cv;
        private string combustible;
        private string cambio;
        private string categoria;
        private int numAsientos;
        private double mediaConsumo;
        private double mediaCoste;
        private ObservableCollection<Repostajes> r;

        //Constructor
        public Coches()
        {
            matricula = "";
            marca = "";
            modelo = "";
            cv = 0;
            combustible = "";
            cambio = "";
            numAsientos = 0;
            categoria = "";
            km = 0;
            mediaConsumo = 0;
            mediaCoste = 0;
            r = new ObservableCollection<Repostajes>();
        }

        //Getters y setters
        public string Matricula { get { return matricula; } set { matricula = value; OnpropertyChanged("Matricula"); } }
        public string Marca { get { return marca; } set { marca = value; OnpropertyChanged("Marca"); } }
        public string Modelo { get { return modelo; } set { modelo = value; OnpropertyChanged("Modelo"); } }
        public string Combustible { get { return combustible; } set { combustible = value; OnpropertyChanged("Combustible"); } }
        public string Cambio { get { return cambio; } set { cambio = value; OnpropertyChanged("Cambio"); } }
        public int Cv { get { return cv; } set { cv = value; OnpropertyChanged("Cv"); } }
        public int NumAsientos { get { return numAsientos; } set { numAsientos = value; OnpropertyChanged("NumAsientos"); } }
        public string Categoria { get { return categoria; } set { categoria = value; OnpropertyChanged("Categoria"); } }
        public int Km { get { return km; } set { km = value; OnpropertyChanged("km"); } }
        public double MediaConsumos { get { return mediaConsumo; } set { mediaConsumo = value; OnpropertyChanged("MediaConsumos"); } }
        public double MediaCostes { get { return mediaCoste; } set { mediaCoste = value; OnpropertyChanged("MediaCostes"); } }

        public ObservableCollection<Repostajes> Repos { get { return r; } set { r = value; OnpropertyChanged("r"); } }

        //Mirar si se puede meter aqui lo de calcular las medias


        // Método que lanza el evento PropertyChanged cuando se cambia el valor de cualquier propiedad
        void OnpropertyChanged(String propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

    }

    public class Repostajes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string fecha;
        private int kmParciales;
        private float litros;
        private float euros;

        //Constructor
        public Repostajes()
        {
            fecha = "";
            kmParciales = 0;  
            litros = 0;
            euros = 0;
        }

        //Getter y setter
        public string Fecha { get { return fecha; } set { fecha = value; OnPropertyChanged("Fecha"); } }
        public int KmParciales { get { return kmParciales; } set { kmParciales = value; OnPropertyChanged("KmParciales"); } }
        public float Litros { get { return litros; } set { litros = value; OnPropertyChanged("Litros"); } }
        public float Euros { get { return euros; } set { euros= value; OnPropertyChanged("Euros"); } }

        protected void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
