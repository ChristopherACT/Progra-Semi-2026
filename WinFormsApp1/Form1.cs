using System;
using System.Data;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Conexion conexion = new Conexion();
        private DataSet conjuntoDatos = new DataSet();
        private DataTable tablaAlumnos = new DataTable();
        private string modoAccion = "nuevo";
        private int indiceActual = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            conjuntoDatos.Clear();
            conjuntoDatos = conexion.obtenerDatos();
            tablaAlumnos = conjuntoDatos.Tables["alumnos"];
            tablaAlumnos.PrimaryKey = new[] { tablaAlumnos.Columns["idAlumno"] };

            MostrarRegistro();
        }
        private void MostrarRegistro()
        {
            if (tablaAlumnos.Rows.Count > 0)
            {
                var fila = tablaAlumnos.Rows[indiceActual];
                txtCodigoAlumno.Text = fila["codigo"].ToString();
                txtNombreAlumno.Text = fila["nombre"].ToString();
                txtDireccionAlumno.Text = fila["direccion"].ToString();
                txtTelefonoAlumno.Text = fila["telefono"].ToString();
                txtEmailAlumno.Text = fila["email"].ToString();

                lblRegistrosAlumnos.Text = $"{indiceActual + 1} de {tablaAlumnos.Rows.Count}";
            }
        }
        private void CambiarEstadoControles(bool habilitar)
        {
            grbDatos.Enabled = habilitar;
            grbNavegacion.Enabled = !habilitar;
        }
        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            if (btnAgregarAlumno.Text == "Agregar")
            {
                btnAgregarAlumno.Text = "Guardar";
                btnModificarALumno.Text = "Cancelar";
                CambiarEstadoControles(true);
            }
            else
            {
                CambiarEstadoControles(false);
                btnAgregarAlumno.Text = "Agregar";
                btnModificarALumno.Text = "Modificar";
            }
        }
        private void btnModificarALumno_Click(object sender, EventArgs e)
        {
            if (btnModificarALumno.Text == "Modificar")
            {
                btnAgregarAlumno.Text = "Guardar";
                btnModificarALumno.Text = "Cancelar";
                CambiarEstadoControles(true);
            }
            else
            {
                CambiarEstadoControles(false);
                btnAgregarAlumno.Text = "Agregar";
                btnModificarALumno.Text = "Modificar";
            }
        }
        private void btnSiguienteAlumno_Click(object sender, EventArgs e)
        {
            indiceActual++;
            MostrarRegistro();
        }
        private void btnAnteriorAlumno_Click(object sender, EventArgs e)
        {
            indiceActual--;
            MostrarRegistro();
        }
        private void btnUltimoAlumno_Click(object sender, EventArgs e)
        {
            indiceActual = tablaAlumnos.Rows.Count - 1;
            MostrarRegistro();
        }
        private void btnPrimeroAlumno_Click(object sender, EventArgs e)
        {
            indiceActual = 0;
            MostrarRegistro();
        }
    }
}
