namespace a_b_c
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonChart = new Button();
            button2 = new Button();
            data_b = new DataGridView();
            Num_Art = new DataGridViewTextBoxColumn();
            Participacion = new DataGridViewTextBoxColumn();
            Acumulada = new DataGridViewTextBoxColumn();
            valoracion = new DataGridViewTextBoxColumn();
            Val_acu = new DataGridViewTextBoxColumn();
            Clase = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)data_b).BeginInit();
            SuspendLayout();
            // 
            // buttonChart
            // 
            buttonChart.Location = new Point(46, 12);
            buttonChart.Name = "buttonChart";
            buttonChart.Size = new Size(114, 43);
            buttonChart.TabIndex = 0;
            buttonChart.Text = "Grafica";
            buttonChart.UseVisualStyleBackColor = true;
            buttonChart.Click += buttonChart_Click;
            // 
            // button2
            // 
            button2.Location = new Point(225, 12);
            button2.Name = "button2";
            button2.Size = new Size(126, 43);
            button2.TabIndex = 1;
            button2.Text = "Regresar";
            button2.UseVisualStyleBackColor = true;
            // 
            // data_b
            // 
            data_b.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_b.Columns.AddRange(new DataGridViewColumn[] { Num_Art, Participacion, Acumulada, valoracion, Val_acu, Clase });
            data_b.Location = new Point(4, 80);
            data_b.Name = "data_b";
            data_b.RowTemplate.Height = 25;
            data_b.Size = new Size(625, 212);
            data_b.TabIndex = 2;
            data_b.CellContentClick += data_b_CellContentClick;
            // 
            // Num_Art
            // 
            Num_Art.HeaderText = "Numero de articulo";
            Num_Art.Name = "Num_Art";
            // 
            // Participacion
            // 
            Participacion.HeaderText = "% de participacion";
            Participacion.Name = "Participacion";
            // 
            // Acumulada
            // 
            Acumulada.HeaderText = "% de participacion acumulada";
            Acumulada.Name = "Acumulada";
            // 
            // valoracion
            // 
            valoracion.HeaderText = "% de valorizacion";
            valoracion.Name = "valoracion";
            // 
            // Val_acu
            // 
            Val_acu.HeaderText = "% de valoracion acumulada";
            Val_acu.Name = "Val_acu";
            // 
            // Clase
            // 
            Clase.HeaderText = "Clase";
            Clase.Name = "Clase";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 309);
            Controls.Add(data_b);
            Controls.Add(button2);
            Controls.Add(buttonChart);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)data_b).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonChart;
        private Button button2;
        private DataGridView data_b;
        private DataGridViewTextBoxColumn Num_Art;
        private DataGridViewTextBoxColumn Participacion;
        private DataGridViewTextBoxColumn Acumulada;
        private DataGridViewTextBoxColumn valoracion;
        private DataGridViewTextBoxColumn Val_acu;
        private DataGridViewTextBoxColumn Clase;
    }
}