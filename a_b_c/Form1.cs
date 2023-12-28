using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace a_b_c
{
    public partial class Form1 : Form
    {
        private int n = 0;// ESTA VAR ES PARA LA SELECCION DE UN CUADRO DE LA TABLA
        public double sumatoria = 0;
        public double control = 0;
        public Form1()
        {
            InitializeComponent();
            /*Bloqueamos la tabla para posibles manipulaciones*/
            data.AllowUserToAddRows = false;
            data.AllowUserToDeleteRows = false;
            data.ReadOnly = true;
            button3.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("iNGRESA NUMERO", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //Adicionar renglon
                int n = data.Rows.Add();

                //Colocamos la informacion 
                data.Rows[n].Cells[0].Value = n + 1;//
                data.Rows[n].Cells[1].Value = textBox2.Text;//Utilizacion
                data.Rows[n].Cells[2].Value = textBox3.Text;//Costo

                int c = Convert.ToInt32(textBox3.Text);
                int u = Convert.ToInt32(textBox2.Text);
                int v = u * c;

                sumatoria = sumatoria + v;

                suma.Text = ("Total:" + sumatoria);

                //OPERACIONES
                data.Rows[n].Cells[3].Value = v;//Valor

                //Limpiamos los texbox
                textBox2.Text = "";
                textBox3.Text = "";
                control++;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button3.Enabled = true;

            //iniciamos nuevamente nuestra primera celda
            /*En el ciclo for iremos haciendo la regla de 3 para el porcentaje
             del valor total, es decir que vamos a tomar el valor anual que es
            de la celda 3 multiplicarlo por 100 y dividirlo con el total que 
            esta en el label*/

            for (int i = 0; i < control; i++)
            {
                double anual = Convert.ToDouble(data.Rows[i].Cells[3].Value); // Valor anual
                double por = (anual * 100) / sumatoria;

                data.Rows[i].Cells[4].Value = por;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Llamamos al formulario 2
            Form2 formulario = new Form2();

            // Obtener los datos de la columna Cells[4] (Val_acu) y Cells[0] (Nun_Art) del DataGridView del formulario 1
            Dictionary<double, string> valoresOrdenados = new Dictionary<double, string>();

            foreach (DataGridViewRow row in data.Rows)
            {
                double valorOrdenado = Convert.ToDouble(row.Cells[4].Value);
                string valorNunArt = row.Cells[0].Value?.ToString() ?? ""; // Utilizar un valor predeterminado en caso de ser nulo

                valoresOrdenados.TryAdd(valorOrdenado, valorNunArt);
            }

            // Ordenar los valores de mayor a menor
            var valoresOrdenadosOrdenados = valoresOrdenados.OrderByDescending(x => x.Key);

            // Pasar los valores ordenados y los valores de Nun_Art al formulario 2
            formulario.ValoresOrdenados = valoresOrdenadosOrdenados.Select(x => x.Key).ToList();
            formulario.ValoresNunArt = valoresOrdenadosOrdenados.Select(x => x.Value).ToList();

            /*Paso de datos como el porcentaje*/
            formulario.ControlValue = Convert.ToInt32(control);

            // Mostrar el formulario 2
            formulario.Show();

        }

        /*Borra toda la informacion*/
        private void button4_Click(object sender, EventArgs e)
        {
            data.Rows.Clear();
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //En el diseño le damos en el rayo 
        //Buscamos el que dice KeyPress
        /*ESTE VA VALIDA LO QUE SE INGRESE CON EL TECLADO PERMITIENDO
         SOLO NUMEROS*/
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /*ESTE ES PARA SELECCIONAR UNA EN ESPECIFICO
         Se encuentra en el rayo y viene como celclick*/
        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            //Obtener informacion del renglon y celda 
            if (n! == -1)
            {
                label1.Text = (string)data.Rows[n].Cells[1].Value;
            }
        }

        /*BORRAR SOLO UNA CELDA*/
        private void button2_Click(object sender, EventArgs e)
        {

            if (n != -1)
            {
                data.Rows.RemoveAt(n);
                control--;
            }
        }


    }
}