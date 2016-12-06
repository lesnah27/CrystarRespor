using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace TareaIIIB
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=empleado;Integrated Security=True");
        int id = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            SqlCommand cmd = new SqlCommand("Select * from empleados", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }
        private void btCrear_Click(object sender, EventArgs e)
        {

            Form2 frm = new Form2();
            frm.Show();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            if (id != 0)
            {
                SqlCommand cmd = new SqlCommand("delete from empleados where id=@id", cn);
                /*cmd = new SqlCommand*/
                cn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Registro eliminado con exito!");
                cargar();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
           
        }

        private void editarButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from empleados where nombre='"+textBox1.Text+"'", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }
        public  string nombre;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show(this);
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reportes frm = new Reportes();
            frm.Show();
        }
    }
    }




    
        



   

