using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace AsisteciaDePersonal
{
    public partial class MainWindow : Window
    {
        // Lista observable para enlazar con DataGrid
        private ObservableCollection<Asistencias> asistencias = new ObservableCollection<Asistencias>();

        public MainWindow()
        {
            InitializeComponent();
            dgAsistencias.ItemsSource = asistencias;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    dpFechaNac.SelectedDate == null ||
                    cmbCargo.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtSueldo.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string nombre = txtNombre.Text;
                DateTime nacimiento = dpFechaNac.SelectedDate.Value;
                string cargo = (cmbCargo.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Calcular edad
                int edad = DateTime.Now.Year - nacimiento.Year;
                if (nacimiento > DateTime.Now.AddYears(-edad)) edad--;

                // Validar y convertir sueldo bruto
                if (!double.TryParse(txtSueldo.Text, out double sueldoBruto))
                {
                    MessageBox.Show("Ingrese un sueldo válido (solo números).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Calcular sueldo neto con descuentos
                double sueldoNeto = sueldoBruto;
                sueldoNeto -= sueldoBruto * 0.035; // ISSS 3.5%
                sueldoNeto -= sueldoBruto * 0.075; // AFP 7.5%
                sueldoNeto -= sueldoBruto * 0.10;  // Renta 10%

                // Agregar registro a la lista
                asistencias.Add(new Asistencias
                {
                    Nombre = nombre,
                    Edad = edad,
                    Cargo = cargo,
                    SueldoNeto = sueldoNeto
                });

                // Limpiar formulario después de agregar
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar empleado: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            dpFechaNac.SelectedDate = null;
            cmbCargo.SelectedIndex = -1;
            txtSueldo.Clear();
        }
    }

    // Clase para almacenar datos de asistencia
    public class Asistencias
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Cargo { get; set; }
        public double SueldoNeto { get; set; }
    }
}
