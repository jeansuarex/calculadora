using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Calculadora
{
    public partial class FormHistorial : Form
    {
        private string connectionString = @"Server=.\sqlexpress;Database=calculadora;TrustServerCertificate=true;Integrated Security=SSPI;";

        public FormHistorial()
        {
            InitializeComponent();
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void CargarDatos()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT operacion, resultado, fecha_operacion FROM [dbo].[Operaciones]";
                    SqlCommand command = new SqlCommand(query, conexion);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos de la consulta
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como la fuente de datos del DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Ajustar el tamaño de las columnas para que ocupen todo el espacio del DataGridView
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Cambiar el color del encabezado
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Brown;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

                    // Color de fondo para filas alternas
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                    // Color de fondo para las celdas seleccionadas
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
                    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

                    // Ajustar el color del borde de las celdas
                    dataGridView1.GridColor = Color.Black;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
        }



    }
}
