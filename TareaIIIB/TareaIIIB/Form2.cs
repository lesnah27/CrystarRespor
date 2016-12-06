using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TareaIIIB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)

        {
            // Se crea el OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            // Se muestra al usuario esperando una acción
            DialogResult result = dialog.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btGuardarBD_Click(object sender, System.EventArgs e)

        {
            try
            {
                // Objetos de conexión y comando
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=.;Initial Catalog=empleado;Integrated Security=True");
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                // Estableciento propiedades
                cmd.Connection = conn;

                //esta es la original
                cmd.CommandText = "INSERT INTO empleados VALUES (/*@id,*/ @nombre, @apellidos,@sexo,@salario, @imagen,@fecha_de_nacimiento,@fecha_de_ingreso)";

                // Creando los parámetros necesarios
                //cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@apellidos", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@sexo", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@salario", System.Data.SqlDbType.SmallMoney);
                cmd.Parameters.Add("@imagen", System.Data.SqlDbType.Image);
                cmd.Parameters.Add("@fecha_de_nacimiento", System.Data.SqlDbType.NVarChar);
                cmd.Parameters.Add("@fecha_de_ingreso", System.Data.SqlDbType.NVarChar);


                // Asignando los valores a los atributos
                //cmd.Parameters["@id"].Value = int.Parse(idBox.Text);
                cmd.Parameters["@nombre"].Value = nombreBox.Text;
                cmd.Parameters["@sexo"].Value = txtSexo.Text;
                cmd.Parameters["@apellidos"].Value = apeBox.Text;
                cmd.Parameters["@salario"].Value = float.Parse(txtSalario.Text);
                cmd.Parameters["@fecha_de_nacimiento"].Value = dateTimePicker1.Text;
                cmd.Parameters["@fecha_de_ingreso"].Value = dateTimePicker2.Text;

                // Asignando el valor de la imagen

                // Stream usado como buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                // Se guarda la imagen en el buffer
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Se extraen los bytes del buffer para asignarlos como valor para el 
                // parámetro.
                cmd.Parameters["@imagen"].Value = ms.GetBuffer();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    




        private void button2_Click(object sender, EventArgs e)
        {
            TimeSpan Diferencia = DateTime.Today.Subtract(dateTimePicker1.Value.Date);
            int Edad = (int)(Diferencia.TotalDays / 365.25);
            textBox1.Text = Edad.ToString();
            textBox3.Text = dateTimePicker1.Value.Month.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimeSpan Diferencia1 = DateTime.Today.Subtract(dateTimePicker2.Value.Date);
            int Edad = (int)(Diferencia1.TotalDays / 365.25);
            textBox2.Text = Edad.ToString();
            textBox4.Text = dateTimePicker2.Value.Month.ToString();
          
            
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}

