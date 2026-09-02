namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabMonto = new TabPage();
            label1 = new Label();
            txtMonto = new TextBox();
            btnCalcular = new Button();
            lblRespuesta = new Label();
            tabArea = new TabPage();
            label2 = new Label();
            txtCantidad = new TextBox();
            label3 = new Label();
            cboDe = new ComboBox();
            label4 = new Label();
            cboA = new ComboBox();
            btnConvertir = new Button();
            lblResultadoArea = new Label();
            tabControl1.SuspendLayout();
            tabMonto.SuspendLayout();
            tabArea.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabMonto);
            tabControl1.Controls.Add(tabArea);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(455, 202);
            tabControl1.TabIndex = 0;
            // 
            // tabMonto
            // 
            tabMonto.Controls.Add(label1);
            tabMonto.Controls.Add(txtMonto);
            tabMonto.Controls.Add(btnCalcular);
            tabMonto.Controls.Add(lblRespuesta);
            tabMonto.Location = new Point(4, 24);
            tabMonto.Margin = new Padding(3, 2, 3, 2);
            tabMonto.Name = "tabMonto";
            tabMonto.Padding = new Padding(3, 2, 3, 2);
            tabMonto.Size = new Size(447, 174);
            tabMonto.TabIndex = 0;
            tabMonto.Text = "monto economico";
            tabMonto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 22);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 0;
            label1.Text = "monto de impuesto";
            label1.Click += label1_Click;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(156, 22);
            txtMonto.Margin = new Padding(3, 2, 3, 2);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(132, 23);
            txtMonto.TabIndex = 1;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(9, 102);
            btnCalcular.Margin = new Padding(3, 2, 3, 2);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(121, 47);
            btnCalcular.TabIndex = 2;
            btnCalcular.Text = "calcular impuesto";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblRespuesta
            // 
            lblRespuesta.AutoSize = true;
            lblRespuesta.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblRespuesta.Location = new Point(156, 115);
            lblRespuesta.Name = "lblRespuesta";
            lblRespuesta.Size = new Size(105, 19);
            lblRespuesta.TabIndex = 3;
            lblRespuesta.Text = "total a pagar: ";
            // 
            // tabArea
            // 
            tabArea.Controls.Add(label2);
            tabArea.Controls.Add(txtCantidad);
            tabArea.Controls.Add(label3);
            tabArea.Controls.Add(cboDe);
            tabArea.Controls.Add(label4);
            tabArea.Controls.Add(cboA);
            tabArea.Controls.Add(btnConvertir);
            tabArea.Controls.Add(lblResultadoArea);
            tabArea.Location = new Point(4, 24);
            tabArea.Margin = new Padding(3, 2, 3, 2);
            tabArea.Name = "tabArea";
            tabArea.Padding = new Padding(3, 2, 3, 2);
            tabArea.Size = new Size(447, 174);
            tabArea.TabIndex = 1;
            tabArea.Text = "conversor de Area";
            tabArea.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 19);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 0;
            label2.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(86, 16);
            txtCantidad.Margin = new Padding(3, 2, 3, 2);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(114, 23);
            txtCantidad.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 52);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 2;
            label3.Text = "De:";
            // 
            // cboDe
            // 
            cboDe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDe.FormattingEnabled = true;
            cboDe.Items.AddRange(new object[] { "Pie Cuadrado", "Vara Cuadrada", "Yarda Cuadrada", "Metro Cuadrado", "Tareas", "Manzana", "Hectárea" });
            cboDe.Location = new Point(51, 50);
            cboDe.Margin = new Padding(3, 2, 3, 2);
            cboDe.Name = "cboDe";
            cboDe.Size = new Size(149, 23);
            cboDe.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(223, 52);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 4;
            label4.Text = "A:";
            // 
            // cboA
            // 
            cboA.DropDownStyle = ComboBoxStyle.DropDownList;
            cboA.FormattingEnabled = true;
            cboA.Items.AddRange(new object[] { "Pie Cuadrado", "Vara Cuadrada", "Yarda Cuadrada", "Metro Cuadrado", "Tareas", "Manzana", "Hectárea" });
            cboA.Location = new Point(249, 50);
            cboA.Margin = new Padding(3, 2, 3, 2);
            cboA.Name = "cboA";
            cboA.Size = new Size(149, 23);
            cboA.TabIndex = 5;
            // 
            // btnConvertir
            // 
            btnConvertir.Location = new Point(51, 119);
            btnConvertir.Margin = new Padding(3, 2, 3, 2);
            btnConvertir.Name = "btnConvertir";
            btnConvertir.Size = new Size(105, 28);
            btnConvertir.TabIndex = 6;
            btnConvertir.Text = "Calcular";
            btnConvertir.UseVisualStyleBackColor = true;
            btnConvertir.Click += btnConvertir_Click;
            // 
            // lblResultadoArea
            // 
            lblResultadoArea.AutoSize = true;
            lblResultadoArea.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblResultadoArea.Location = new Point(178, 123);
            lblResultadoArea.Name = "lblResultadoArea";
            lblResultadoArea.Size = new Size(83, 19);
            lblResultadoArea.TabIndex = 7;
            lblResultadoArea.Text = "Resultado: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 202);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Impuesto a Actividades Económicas";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabMonto.ResumeLayout(false);
            tabMonto.PerformLayout();
            tabArea.ResumeLayout(false);
            tabArea.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabMonto;
        private TabPage tabArea;
        private TextBox txtMonto;
        private Label label1;
        private Label lblRespuesta;
        private Button btnCalcular;
        private Label label2;
        private TextBox txtCantidad;
        private Label label3;
        private ComboBox cboDe;
        private Label label4;
        private ComboBox cboA;
        private Button btnConvertir;
        private Label lblResultadoArea;
    }
}
