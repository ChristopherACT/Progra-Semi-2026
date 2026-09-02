using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private readonly double[] _factoresArea = { 0.09290304, 0.698896, 0.83612736, 1.0, 437.5, 6988.96, 10000.0 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboDe.SelectedIndex = 0;
            cboA.SelectedIndex = 3;
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtMonto.Text, out double monto) || monto <= 0)
            {
                lblRespuesta.Text = "valor a pagar: Ingrese un monto válido";
                return;
            }

            (double desde, double hasta, double precio, double adicional)[] tabla =
            {
                (0.01, 500, 1.5, 0),
                (500.01, 1000, 1.5, 3),
                (1000.01, 2000, 3, 3),
                (2000.01, 3000, 6, 3),
                (3000.01, 6000, 9, 2),
                (8000.01, 18000, 15, 2),
                (18000.01, 30000, 39, 2),
                (30000.01, 60000, 63, 1),
                (60000.01, 100000, 93, 0.8),
                (100000.01, 200000, 125, 0.7),
                (200000.01, 300000, 195, 0.6),
                (300000.01, 400000, 255, 0.45),
                (400000.01, 500000, 300, 0.4),
                (500000.01, 1000000, 340, 0.30),
                (1000000.01, 99999999, 490, 0.18)
            };

            foreach (var t in tabla)
            {
                if (monto >= t.desde && monto <= t.hasta)
                {
                    double impuesto = ((monto - t.desde) / 1000.0) * t.adicional + t.precio;
                    lblRespuesta.Text = $"valor a pagar: ${impuesto:0.00}";
                    return;
                }
            }

            lblRespuesta.Text = "valor a pagar: Monto fuera de rango";
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtCantidad.Text, out double cantidad) || cantidad < 0)
            {
                lblResultadoArea.Text = "Resultado: Ingrese una cantidad válida";
                return;
            }

            if (cboDe.SelectedIndex < 0 || cboA.SelectedIndex < 0)
            {
                lblResultadoArea.Text = "Resultado: Seleccione las unidades";
                return;
            }

            double enMetros = cantidad * _factoresArea[cboDe.SelectedIndex];
            double resultado = enMetros / _factoresArea[cboA.SelectedIndex];

            lblResultadoArea.Text = $"Resultado: {resultado:0.####} {cboA.SelectedItem}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}