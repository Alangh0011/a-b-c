using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace a_b_c
{
    public partial class Form2 : Form
    {
        public List<double> ValoresOrdenados { get; set; }
        public List<string> ValoresNunArt { get; set; }
        public int ControlValue { get; set; }

        public Form2()
        {
            InitializeComponent();
            data_b.AllowUserToAddRows = false;
            data_b.AllowUserToDeleteRows = false;
            data_b.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void data_b_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (ValoresOrdenados != null && ValoresNunArt != null)
            {
                for (int i = 0; i < ValoresOrdenados.Count; i++)
                {
                    double valorOrdenado = ValoresOrdenados[i];
                    string valorNunArt = ValoresNunArt.FirstOrDefault(x => ValoresOrdenados[ValoresNunArt.IndexOf(x)] == valorOrdenado);
                    if (valorNunArt != null)
                    {
                        data_b.Rows.Add(valorNunArt, "", "", valorOrdenado, "", "");
                    }
                }
            }

            double val = 0;
            double secuencia = 0;
            double total = 0;
            double par = (100 / ControlValue);

            for (int i = 0; i < ControlValue && i < data_b.Rows.Count; i++)
            {
                if (double.TryParse(data_b.Rows[i].Cells[3].Value?.ToString(), out val))
                {
                    secuencia = secuencia + val;
                    total = total + par;

                    data_b.Rows[i].Cells[4].Value = secuencia;
                    data_b.Rows[i].Cells[1].Value = par;
                    data_b.Rows[i].Cells[2].Value = total;

                    // Asignar categoría A, B o C
                    if (total <= 80)
                        data_b.Rows[i].Cells[5].Value = "A";
                    else if (total <= 95)
                        data_b.Rows[i].Cells[5].Value = "B";
                    else
                        data_b.Rows[i].Cells[5].Value = "C";
                }
            }
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia de Form para la ventana de la gráfica
            Form chartForm = new Form();
            chartForm.Size = new Size(800, 600); // Establecer el tamaño de la ventana de la gráfica

            // Crear la gráfica
            Chart chart = new Chart();
            chart.Parent = chartForm; // Establecer el formulario de la gráfica como el contenedor de la gráfica
            chart.Dock = DockStyle.Fill; // Rellenar todo el espacio disponible en la ventana de la gráfica

            // Configurar el tipo de gráfica
            chart.ChartAreas.Add("area");
            chart.Series.Add("series");
            chart.Series["series"].ChartType = SeriesChartType.Line;

            // Agregar los valores de las columnas al gráfico
            for (int i = 0; i < data_b.Rows.Count; i++)
            {
                string valorNunArt = data_b.Rows[i].Cells[0].Value.ToString();
                double valorValAcu = Convert.ToDouble(data_b.Rows[i].Cells[4].Value);

                chart.Series["series"].Points.AddXY(valorNunArt, valorValAcu);
            }

            // Mostrar la ventana emergente en una nueva pestaña
            chartForm.Show();
        }
    }
}