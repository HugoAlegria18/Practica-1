using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LlenarDataGridView();
            this.llenarComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*int num1 = Convert.ToInt32(txtnum1.Text);
            int num2 = Convert.ToInt32(txtnum2.Text);
            int suma = num1 + num2;

            
            MessageBox.Show(suma.ToString());*/
            int num1 = Convert.ToInt32(txtnum1.Text);
            int num2 = Convert.ToInt32(txtnum2.Text);
            this.suma(num1, num2);
        }
        private int suma(int uno,int dos)
        {
            int suma = uno + dos;

            return suma;

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            this.grabar();
            this.LlenarDataGridView();
        }
        public void grabar()
        {
            string nombre = txtnombre.Text;
            string apellido = txtapellido.Text;
            string dni = txtdni.Text;

            txtnombre.BackColor = Color.White;
            txtapellido.BackColor = Color.White;
            txtdni.BackColor = Color.White;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, ingresa tu nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnombre.Focus();
                txtnombre.BackColor = Color.Red;
                return;
            }
            txtapellido.BackColor = Color.White;
            if (string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Por favor, ingrese tu apellido.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtapellido.Focus();
                txtapellido.BackColor = Color.Red;
                return;
            }
            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Por favor, ingrese tu dni.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdni.Focus();
                txtdni.BackColor = Color.Red;
                return;
            }
            if ((dni.Length!=8))
            {
                MessageBox.Show("la cantidad tiene que ser de 8 digitos.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdni.Focus();
                txtdni.BackColor = Color.Red;
                return;
        }


            inquilino oinquilino = new inquilino();
            oinquilino.nombre = nombre;
            oinquilino.apellido = apellido;
            oinquilino.dni = dni;
            this.grabarbasededatos(oinquilino);

        }
        public void grabarbasededatos(inquilino oinquilino)
        {
            string connectionString = "Data Source=lphp;Initial Catalog=Alquiler;User ID=admin;Password=123456";


            // Definir la consulta SQL para la inserción
            string query = "INSERT INTO INQUILINO (nombre, apellido, dni) VALUES (@Valornombre, @Valorapellido, @Valordni)";

            // Puedes agregar más valores según la estructura de tu tabla

            // Crear y abrir la conexión con la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Crear un comando SQL con parámetros
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros y sus valores
                    command.Parameters.AddWithValue("@Valornombre", oinquilino.nombre);
                    command.Parameters.AddWithValue("@Valorapellido", oinquilino.apellido);
                    command.Parameters.AddWithValue("@Valordni", oinquilino.dni);
                    // Puedes agregar más parámetros según la estructura de tu tabla

                    // Ejecutar el comando SQL
                    int rowsAffected = command.ExecuteNonQuery();

                    // Comprobar si la inserción fue exitosa
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro insertado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el registro.");
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
            private void LlenarDataGridView()
            {
            string connectionString = "Data Source=lphp;Initial Catalog=Alquiler;User ID=admin;Password=123456";
            try
            {
                    // Crear una nueva conexión a la base de datos
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Consulta SQL para seleccionar todos los datos de la tabla
                        string query = "SELECT * FROM INQUILINO";

                        // Crear un adaptador de datos para ejecutar la consulta y llenar un DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();

                        // Abrir la conexión y llenar el DataTable con los datos
                        connection.Open();
                        adapter.Fill(dataTable);

                        // Asignar el DataTable como origen de datos del DataGridView
                        dataGridView1.DataSource = dataTable;

                        // Opcional: si quieres que el DataGridView se ajuste automáticamente a las columnas
                        dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al llenar el DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void txtapellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdni_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(txtnum1.Text);
            int num2 = Convert.ToInt32(txtnum2.Text);
            
            int suma = this.suma(num1, num2);
            MessageBox.Show(suma.ToString());
        }

        private void txtdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancelar la entrada de cualquier carácter que no sea un dígito o una tecla de control
                e.Handled = true;
            }

            // Verificar si la longitud actual del texto supera los 8 dígitos
            if (txtdni.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                // Si es así, cancelar la entrada del carácter y mostrar un mensaje de error
                e.Handled = true;
                MessageBox.Show("Solo se permiten 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llenarComboBox()
        {
            string connectionString = "Data Source=lphp;Initial Catalog=Alquiler;User ID=admin;Password=123456";

            try
            { 
                string query = "SELECT Id, Nombre+' '+apellido as nombre FROM INQUILINO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    connection.Open();
                    adapter.Fill(dataTable);

                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "nombre"; 
                    comboBox1.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}







