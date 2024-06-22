using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Final_IGU_3._0
{
    //Clase utilizada como modelo de la vista
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Coches> data;
        public ObservableCollection<Repostajes> repos;

        public float mConsumos;
        public float mCostes;

        //Constructor
        public Model()
        {
            data = new ObservableCollection<Coches>();
        }

        //Getters y Setters
        public float MConsumos { get { return mConsumos; } set { mConsumos = value; OnPropertyChanged("MConsumos"); } }
        public float MCostes { get { return mCostes; } set { mCostes = value; OnPropertyChanged("MCostes"); } }

        public ObservableCollection<Coches> ListaVehiculos { get { return data; }set { data = value; OnPropertyChanged("ListaVehiculos"); } }

        //Funcion para añadir los valores en los atributos de la clase
        public bool Add(Coches c)
        {
            foreach(Coches aux in data)
            {
                if (aux.Matricula.Equals(c.Matricula))
                {
                    return false;
                }
            }
            data.Add(c);
            return true;
        }

        public bool Delete(Coches c)
        {
            foreach (Coches aux in data)
            {
                
               data.Remove(c);
               return true;
               
            }
            return false;
        }

        public void DrawRepos(ObservableCollection<Repostajes> r)
        {
            repos = r;
        }
        //Interfaz para notificar el cambio de las propiedades
        protected void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
