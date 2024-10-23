using System;
using System.Data;
using System.Data.SqlClient;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Server=.\sqlexpress;Database=calculadora;TrustServerCertificate=true;Integrated Security=SSPI;";


        public Form1()
        {
            InitializeComponent();
            show_calc.Text = "0";
            show_calc.TextAlign = HorizontalAlignment.Right;
            show_calc.Font = new Font(show_calc.Font.FontFamily, 27);
        }

        private double currentTotal = 0; // Almacena el resultado acumulado
        private string previousSign = string.Empty; // Almacena el último signo
        private string operacion_str = "";


        private void btn_one_Click(object sender, EventArgs e)
        {
            operacion_str += "1";
            if (show_calc.Text == "0")
            {
                show_calc.Text = "1";
            }
            else
            {
                show_calc.Text += "1";
            }
        }

        private void btn_two_Click(object sender, EventArgs e)
        {
            operacion_str += "2";
            if (show_calc.Text == "0")
            {
                show_calc.Text = "2";
            }
            else
            {
                show_calc.Text += "2";
            }
        }

        private void btn_three_Click(object sender, EventArgs e)
        {
            operacion_str += "3";

            if (show_calc.Text == "0")
            {
                show_calc.Text = "3";
            }
            else
            {
                show_calc.Text += "3";
            }
        }

        private void btn_four_Click(object sender, EventArgs e)
        {
            operacion_str += "4";

            if (show_calc.Text == "0")
            {
                show_calc.Text = "4";
            }
            else
            {
                show_calc.Text += "4";
            }
        }

        private void btn_five_Click(object sender, EventArgs e)
        {
            operacion_str += "5";
            if (show_calc.Text == "0")
            {
                show_calc.Text = "5";
            }
            else
            {
                show_calc.Text += "5";
            }
        }

        private void btn_six_Click(object sender, EventArgs e)
        {
            operacion_str += "6";
            if (show_calc.Text == "0")
            {
                show_calc.Text = "6";
            }
            else
            {
                show_calc.Text += "6";
            }
        }

        private void btn_seven_Click(object sender, EventArgs e)
        {
            if (show_calc.Text == "0")
            {
                show_calc.Text = "7";
            }
            else
            {
                show_calc.Text += "7";
            }
        }

        private void btn_eight_Click(object sender, EventArgs e)
        {
            operacion_str += "8";
            if (show_calc.Text == "0")
            {
                show_calc.Text = "8";
            }
            else
            {
                show_calc.Text += "8";
            }
        }

        private void btn_nine_Click(object sender, EventArgs e)
        {
            operacion_str += "9";

            if (show_calc.Text == "0")
            {
                show_calc.Text = "9";
            }
            else
            {
                show_calc.Text += "9";

            }
        }

        private void btn_zero_Click(object sender, EventArgs e)
        {
            operacion_str += "0";
            if (show_calc.Text == "0")
            {
                show_calc.Text = "0";
            }
            else
            {
                show_calc.Text += "0";
            }
        }

        private void btn_dot_Click(object sender, EventArgs e)
        {
            if (show_calc.Text == "0")
            {
                show_calc.Text = "."; // Reemplaza "0" con "."
                operacion_str += ".";
            }
            else
            {
                string[] parts = show_calc.Text.Split(new char[] { '+', '-', '*', '/' });

                string lastPart = parts[parts.Length - 1];

                if (lastPart.Contains("."))
                {
                    return; // Sale del método
                }
                else
                {
                    operacion_str += ".";
                    // Si no hay un punto, agregar "." al final del último número
                    show_calc.Text += ".";
                }
            }
        }

        private void btn_time_Click(object sender, EventArgs e)
        {
            // Verifica si hay texto en show_calc
            if (!string.IsNullOrEmpty(show_calc.Text))
            {
                operacion_str += "x";
                // Verifica si ya hay un signo anterior
                if (!string.IsNullOrEmpty(txt_sign.Text))
                {
                    // Llama a la función para realizar la operación
                    PerformOperation(double.Parse(show_calc.Text));
                }
                else // Si no hay signo anterior
                {
                    current_result.Text = show_calc.Text;
                    currentTotal = double.Parse(current_result.Text); // Almacena el total
                }

                // Establece el signo en txt_sign
                txt_sign.Text = "*";
                previousSign = "*"; // Actualiza el signo anterior
                show_calc.Text = string.Empty; // Vacia show_calc
            }
        }



        private void btn_plus_Click(object sender, EventArgs e)
        {
            operacion_str += "+";
            // Verifica si hay texto en show_calc
            if (!string.IsNullOrEmpty(show_calc.Text))
            {
                // Verifica si ya hay un signo anterior
                if (!string.IsNullOrEmpty(txt_sign.Text))
                {
                    // Llama a la función para realizar la operación
                    PerformOperation(double.Parse(show_calc.Text));
                }
                else // Si no hay signo anterior
                {
                    current_result.Text = show_calc.Text;
                    currentTotal = double.Parse(current_result.Text); // Almacena el total
                }

                // Establece el signo en txt_sign
                txt_sign.Text = "+";
                previousSign = "+"; // Actualiza el signo anterior
                show_calc.Text = string.Empty; // Vacia show_calc
            }
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            // Verifica si hay texto en show_calc
            if (!string.IsNullOrEmpty(show_calc.Text))
            {
                operacion_str += "-";
                // Verifica si ya hay un signo anterior
                if (!string.IsNullOrEmpty(txt_sign.Text))
                {
                    // Llama a la función para realizar la operación
                    PerformOperation(double.Parse(show_calc.Text));
                }
                else // Si no hay signo anterior
                {
                    current_result.Text = show_calc.Text;
                    currentTotal = double.Parse(current_result.Text); // Almacena el total
                }

                txt_sign.Text = "-";
                previousSign = "-"; // Actualiza el signo anterior
                show_calc.Text = string.Empty; // Vacia show_calc
            }
        }
        private void PerformOperation(double newValue)
        {
            // Realiza la operación basada en el signo anterior
            if (previousSign == "+")
            {
                currentTotal += newValue; // Suma
            }
            else if (previousSign == "-")
            {
                currentTotal -= newValue; // Resta
            }
            else if (previousSign == "*")
            {
                currentTotal *= newValue; // Multiplicación
            }
            else if (previousSign == "/")
            {
                // Verifica que no se divida por cero
                if (newValue != 0)
                {
                    currentTotal /= newValue; // División
                }
                else
                {
                    MessageBox.Show("Error: No se puede dividir por cero.");
                    return;
                }
            }
            else if (previousSign == "^")
            {
                // Calcula la potencia
                currentTotal = Math.Pow(currentTotal, newValue); // Eleva el número almacenado a la potencia ingresada
            }

            current_result.Text = currentTotal.ToString(); // Muestra el resultado
        }



        private void btn_raiz_Click(object sender, EventArgs e)
        {
            // Intentar obtener el valor del TextBox y convertirlo en número
            if (double.TryParse(show_calc.Text, out double number) && show_calc.Text != "0")
            {
                // Calcular la raíz cuadrada del número ingresado en el TextBox
                double raiz = Math.Sqrt(number);

                // Mostrar el resultado en el TextBox
                show_calc.Text = raiz.ToString();
                operacion_str += $"sqrt({raiz})";
            }
            else
            {
                // Si el valor ingresado no es un número válido, mostrar un mensaje de error
                MessageBox.Show("Error, ingrese un valor.");
            }
        }




        private void btn_pot_Click(object sender, EventArgs e)
        {
            // Verifica si hay texto en show_calc
            if (!string.IsNullOrEmpty(show_calc.Text))
            {
                operacion_str += "^";
                // Verifica si ya hay un signo anterior
                if (!string.IsNullOrEmpty(txt_sign.Text))
                {
                    // Llama a la función para realizar la operación con el número actual
                    PerformOperation(double.Parse(show_calc.Text));
                }
                else // Si no hay signo anterior
                {
                    current_result.Text = show_calc.Text; // Almacena el número base
                    currentTotal = double.Parse(current_result.Text); // Almacena el total
                }

                txt_sign.Text = "^"; // Indica que la operación actual es potencia
                previousSign = "^"; // Actualiza el signo a "potencia"
                show_calc.Text = string.Empty; // Limpia el TextBox para que se ingrese el exponente
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            show_calc.Text = string.Empty;
            current_result.Text = string.Empty;
            txt_sign.Text = string.Empty;
        }


        private void btn_result_Click(object sender, EventArgs e)
        {
            // Verifica si hay texto en show_calc
            if (!string.IsNullOrEmpty(show_calc.Text))
            {
                // Llama a la función para realizar la operación
                PerformOperation(double.Parse(show_calc.Text));

                // Obtenemos el resultado
                string resultado = current_result.Text;

                // Limpiar el texto en show_calc y actualizar txt_sign
                show_calc.Text = string.Empty;
                txt_sign.Text = string.Empty; // Opcional: limpiar el signo después de mostrar el resultado

                // Llamar a la función que guarda los datos en la tabla operaciones
                GuardarOperacionEnBaseDeDatos(operacion_str, resultado, DateTime.Now);

                // Limpiar la operación para futuras operaciones
                operacion_str = string.Empty;
            }
        }

        private void GuardarOperacionEnBaseDeDatos(string operacion, string resultado, DateTime fecha)
        {
            // Establecer la conexión con la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el comando SQL para insertar la operación
                string query = "INSERT INTO operaciones (operacion, resultado, fecha_operacion) VALUES (@operacion, @resultado, @fecha)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Añadir los parámetros al comando
                    command.Parameters.AddWithValue("@operacion", operacion);
                    command.Parameters.AddWithValue("@resultado", resultado);
                    command.Parameters.AddWithValue("@fecha", fecha);

                    // Abrir la conexión
                    connection.Open();

                    // Ejecutar el comando
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Operación guardada correctamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar la operación: " + ex.Message);
                    }
                }
            }
        }

        private void btn_dividir_Click(object sender, EventArgs e)
        {
            // Verifica si hay texto en show_calc
            if (!string.IsNullOrEmpty(show_calc.Text))
            {

                operacion_str += "/";
                // Verifica si ya hay un signo anterior
                if (!string.IsNullOrEmpty(txt_sign.Text))
                {
                    // Llama a la función para realizar la operación
                    PerformOperation(double.Parse(show_calc.Text));
                }
                else // Si no hay signo anterior
                {
                    current_result.Text = show_calc.Text;
                    currentTotal = double.Parse(current_result.Text); // Almacena el total
                }

                // Establece el signo en txt_sign
                txt_sign.Text = "/";
                previousSign = "/"; // Actualiza el signo anterior
                show_calc.Text = string.Empty; // Vacia show_calc
            }
        }

        private void historialbtn_Click(object sender, EventArgs e)
        {
            FormHistorial formHistorial = new FormHistorial();

            // Muestra el formulario. Puedes usar Show() o ShowDialog() dependiendo de tu necesidad.
            formHistorial.Show(); // Abre la ventana de manera no modal
                                  // formHistorial.ShowDialog(); // Abre la ventana de manera modal (bloquea la ventana anterior hasta que cierres esta)
        }

    }
}
