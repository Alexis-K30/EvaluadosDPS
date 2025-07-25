using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AsisteciaDePersonal
{
    public partial class MainWindow : Window
    {
        // Lista observable para enlazar con DataGrid
        private ObservableCollection<Asistencias> asistencias = new ObservableCollection<Asistencias>();

        // Salario mínimo único para todos los puestos
        private const double SalarioMinimo = 450.00;

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
                //Validar que el nombre empiece con mayuscula por cada espacio que haya
                if(!ValidarNombre(nombre))
                {
                    MessageBox.Show("El nombre ingresado no esta completo o el nombre es muy largo. Por favor ingrese su nombre completo o acorte su nombre", "Advertencia", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                //Formateamos el nombre para que este con las iniciales en mayuscula
                nombre = CapitalizarNombre(nombre);

                DateTime nacimiento = dpFechaNac.SelectedDate.Value;
                string cargo = (cmbCargo.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Calcular edad
                int edad = DateTime.Now.Year - nacimiento.Year;
                if (nacimiento > DateTime.Now.AddYears(-edad)) edad--;
                //Validar que la edad sea mayor a 18
                if (edad < 18)
                {
                    MessageBox.Show("Usted es menor de 18 años. No puede registrarse", "Advertencia", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validar y convertir sueldo bruto
                if (!double.TryParse(txtSueldo.Text, out double sueldoBruto) || sueldoBruto <= 0)
                {
                    MessageBox.Show("Ingrese un sueldo válido (solo números positivos).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validar salario mínimo
                if (sueldoBruto < SalarioMinimo)
                {
                    MessageBox.Show($"El sueldo debe ser igual o mayor al salario mínimo (${SalarioMinimo}).",
                                  "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

                MessageBox.Show("¡Empleado registrado exitosamente!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar empleado: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarNombre(string nombre)
        {
            string patron = @"^([A-Za-zÁÉÍÓÚÑáéíóúñ]+)(\s[A-Za-zÁÉÍÓÚÑáéíóúñ]+){1,6}$";
            return Regex.IsMatch(nombre, patron);
        }

        public static string CapitalizarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return nombre;

            string[] palabras = nombre.ToLower().Split(' ');

            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i].Length > 0)
                {
                    palabras[i] = char.ToUpper(palabras[i][0]) + palabras[i].Substring(1);
                }
            }

            return string.Join(" ", palabras);
        }


        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            dpFechaNac.SelectedDate = null;
            cmbCargo.SelectedIndex = -1;
            txtSueldo.Clear();
            txtNombre.Focus(); // Coloca el foco en el primer campo
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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