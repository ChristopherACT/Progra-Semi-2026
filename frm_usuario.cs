using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UsuariosUSSS004525
{
    public class frm_usuario : Form
    {
        private readonly Conexion_base_datos db = new Conexion_base_datos();
        private DataSet ds;
        private DataTable dt;
        private int pos = 0;

        private TextBox txtId, txtUsuario, txtClave, txtConfirmar, txtNombre, txtDireccion, txtTelefono;
        private Button btnPrimero, btnAnterior, btnSiguiente, btnUltimo;
        private Button btnNuevo, btnAgregar, btnModificar, btnEliminar;
        private Label lblPos;

        public frm_usuario()
        {
            Text = "frm_usuario - Registro de usuarios";
            ClientSize = new Size(470, 420);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            int y = 20;
            txtId = campo("idUsuario:", ref y, 35, true);
            txtUsuario = campo("Usuario:", ref y, 16, false);
            txtClave = campo("Clave:", ref y, 35, false);
            txtConfirmar = campo("Confirmar clave:", ref y, 35, false);
            txtNombre = campo("Nombre:", ref y, 65, false);
            txtDireccion = campo("Dirección:", ref y, 85, false);
            txtTelefono = campo("Teléfono:", ref y, 9, false);
            txtClave.UseSystemPasswordChar = true;
            txtConfirmar.UseSystemPasswordChar = true;
            txtUsuario.MaxLength = 35; // la validacion de 6-16 se hace al guardar

            // Navegacion
            btnPrimero = boton("|<", 130, y + 10, 50);
            btnAnterior = boton("<", 185, y + 10, 50);
            lblPos = new Label { Location = new Point(240, y + 15), Size = new Size(70, 20), TextAlign = ContentAlignment.MiddleCenter };
            btnSiguiente = boton(">", 315, y + 10, 50);
            btnUltimo = boton(">|", 370, y + 10, 50);
            Controls.Add(lblPos);

            // Edicion
            int y2 = y + 60;
            btnNuevo = boton("Nuevo", 20, y2, 100);
            btnAgregar = boton("Agregar", 130, y2, 100);
            btnModificar = boton("Modificar", 240, y2, 100);
            btnEliminar = boton("Eliminar", 350, y2, 100);

            btnPrimero.Click += (s, e) => { pos = 0; mostrar(); };
            btnAnterior.Click += (s, e) => { if (pos > 0) pos--; mostrar(); };
            btnSiguiente.Click += (s, e) => { if (pos < dt.Rows.Count - 1) pos++; mostrar(); };
            btnUltimo.Click += (s, e) => { pos = dt.Rows.Count - 1; mostrar(); };
            btnNuevo.Click += (s, e) => nuevo();
            btnAgregar.Click += btnAgregar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;

            Load += (s, e) => cargarDatos(0);
        }

        // ---------- construccion de controles ----------
        private TextBox campo(string etiqueta, ref int y, int max, bool soloLectura)
        {
            Controls.Add(new Label { Text = etiqueta, AutoSize = true, Location = new Point(20, y + 4) });
            var t = new TextBox { Location = new Point(130, y), Width = 310, MaxLength = max, ReadOnly = soloLectura };
            Controls.Add(t);
            y += 34;
            return t;
        }

        private Button boton(string texto, int x, int y, int ancho)
        {
            var b = new Button { Text = texto, Location = new Point(x, y), Width = ancho, Height = 28 };
            Controls.Add(b);
            return b;
        }

        // ---------- datos ----------
        private void cargarDatos(int posicion)
        {
            ds = db.crearDs();
            dt = ds.Tables[Conexion_base_datos.TABLA];
            pos = Math.Max(0, Math.Min(posicion, dt.Rows.Count - 1));
            mostrar();
        }

        private void mostrar()
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                limpiar();
                lblPos.Text = "0 / 0";
                return;
            }
            if (pos < 0) pos = 0;
            if (pos > dt.Rows.Count - 1) pos = dt.Rows.Count - 1;

            DataRow r = dt.Rows[pos];
            txtId.Text = r["idUsuario"].ToString();
            txtUsuario.Text = r["usuario"].ToString();
            txtClave.Text = r["clave"].ToString();
            txtConfirmar.Text = r["clave"].ToString();
            txtNombre.Text = r["nombre"].ToString();
            txtDireccion.Text = r["direccion"].ToString();
            txtTelefono.Text = r["telefono"].ToString();
            lblPos.Text = (pos + 1) + " / " + dt.Rows.Count;
        }

        private void limpiar()
        {
            foreach (var t in new[] { txtId, txtUsuario, txtClave, txtConfirmar, txtNombre, txtDireccion, txtTelefono })
                t.Clear();
        }

        private void nuevo()
        {
            limpiar();
            txtUsuario.Focus();
        }

        // ---------- validaciones ----------
        private bool validar(int idActual)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            // El usuario: minimo 6 y maximo 16 caracteres
            if (usuario.Length < 6 || usuario.Length > 16)
            {
                aviso("El usuario debe tener como mínimo 6 y como máximo 16 caracteres.");
                txtUsuario.Focus();
                return false;
            }

            // La clave: confirmacion
            if (clave != txtConfirmar.Text)
            {
                aviso("La clave y su confirmación no son iguales.");
                txtConfirmar.Focus();
                return false;
            }

            // La clave: letras y numeros
            bool tieneLetra = clave.Any(char.IsLetter);
            bool tieneNumero = clave.Any(char.IsDigit);
            if (!tieneLetra || !tieneNumero)
            {
                aviso("La clave debe llevar letras y números.");
                txtClave.Focus();
                return false;
            }

            if (txtNombre.Text.Trim().Length == 0)
            {
                aviso("Ingrese el nombre.");
                txtNombre.Focus();
                return false;
            }

            if (db.existeUsuario(usuario, idActual))
            {
                aviso("Ya existe un usuario con ese nombre.");
                txtUsuario.Focus();
                return false;
            }
            return true;
        }

        private void aviso(string msg)
        {
            MessageBox.Show(msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ---------- botones de edicion ----------
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                aviso("Presione \"Nuevo\" para registrar un usuario nuevo.");
                return;
            }
            if (!validar(0)) return;

            try
            {
                db.mantenimiento_usuarios_USSS004525("agregar", 0, txtUsuario.Text.Trim(), txtClave.Text,
                    txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim());
                cargarDatos(int.MaxValue); // posicionarse en el ultimo registro
                MessageBox.Show("Usuario agregado correctamente.", "Usuarios");
            }
            catch (Exception ex) { error(ex); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length == 0)
            {
                aviso("Seleccione un registro para modificar.");
                return;
            }
            int id = int.Parse(txtId.Text);
            if (!validar(id)) return;

            try
            {
                db.mantenimiento_usuarios_USSS004525("modificar", id, txtUsuario.Text.Trim(), txtClave.Text,
                    txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim());
                cargarDatos(pos);
                MessageBox.Show("Usuario modificado correctamente.", "Usuarios");
            }
            catch (Exception ex) { error(ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length == 0)
            {
                aviso("Seleccione un registro para eliminar.");
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el usuario seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                db.mantenimiento_usuarios_USSS004525("eliminar", int.Parse(txtId.Text), null, null, null, null, null);
                cargarDatos(pos);
            }
            catch (Exception ex) { error(ex); }
        }

        private void error(Exception ex)
        {
            MessageBox.Show("Ocurrió un error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
