using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace AsisteciaDePersonal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Asistencias> asistencias = new ObservableCollection<Asistencias>();
        public MainWindow()
        {
            InitializeComponent();
            dgAsistencias.ItemsSource = asistencias;
            Prueba();
        }

        private void Prueba()
        {
            double hola = 20.50;
            asistencias.Add(new Asistencias
            {
                Nombre = "Andrea Ramos",
                Edad = 23,
                Cargo = "Hola mundo", 
                SueldoNeto = 20.50
            });
        }
    }

    public class Asistencias
    {
        public string Nombre {  get; set; }
        public int Edad { get; set; }
        public string Cargo { get; set; }
        public double SueldoNeto { get; set; }
    }
}