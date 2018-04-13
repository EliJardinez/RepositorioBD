using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BasedeDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=PracticaVisual; uid=root; pwd= ;");
            try
            {
                comboBox1.Text = "Nombres "; //poner etiqueta al combo box
                comboBox1.Items.Clear();
                conectar.Open();

                MySqlCommand comando = new MySqlCommand("Select Nombre from alumno", conectar);
                MySqlDataReader almacena = comando.ExecuteReader();

                while (almacena.Read()) //mientras exista algo que leer
                {
                    comboBox1.Refresh();
                    comboBox1.Items.Add(almacena.GetValue(0).ToString()); //se agregan los items al combobox
                }
                conectar.Close();
               
            }
            catch(MySqlException r)
            {
                MessageBox.Show(r.Message);
            }
        }
    }
}
