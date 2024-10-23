namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            show_calc.Text = "0";
            show_calc.TextAlign = HorizontalAlignment.Right;
            show_calc.Font = new Font(show_calc.Font.FontFamily, 27);
        }

        private double currentTotal = 0; // Almacena el resultado acumulado
        private string previousSign = string.Empty; // Almacena el último signo


        private void btn_one_Click(object sender, EventArgs e)
        {
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
                currentTotal = 0;
                // Limpiar el texto en show_calc y actualizar txt_sign
                show_calc.Text = string.Empty;
                txt_sign.Text = string.Empty; // Opcional: limpiar el signo después de mostrar el resultado
            }
        }
        private void btn_dividir_Click(object sender, EventArgs e)
        {
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
                txt_sign.Text = "/";
                previousSign = "/"; // Actualiza el signo anterior
                show_calc.Text = string.Empty; // Vacia show_calc
            }
        }



    }
}
