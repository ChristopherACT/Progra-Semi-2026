using System;
using System.Drawing;
using System.Windows.Forms;

namespace UsuariosUSSS004525
{
    public class login : Form
    {
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Button btnIngresar;
        private Button btnSalir;
        private readonly Conexion_base_datos db = new Conexion_base_datos();

        public login()
        {
            Text = "Login";
            ClientSize = new Size(340, 190);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var titulo = new Label
            {
                Text = "Acceso al sistema",
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            var lblU = new Label { Text = "Usuario:", AutoSize = true, Location = new Point(20, 62) };
            var lblC = new Label { Text = "Clave:", AutoSize = true, Location = new Point(20, 97) };
            txtUsuario = new TextBox { Location = new Point(100, 58), Width = 210, MaxLength = 35 };
            txtClave = new TextBox { Location = new Point(100, 93), Width = 210, MaxLength = 35, UseSystemPasswordChar = true };
            btnIngresar = new Button { Text = "Ingresar", Location = new Point(100, 135), Width = 100 };
            btnSalir = new Button { Text = "Salir", Location = new Point(210, 135), Width = 100 };

            btnIngresar.Click += btnIngresar_Click;
            btnSalir.Click += (s, e) => Close();

            Controls.AddRange(new Control[] { titulo, lblU, lblC, txtUsuario, txtClave, btnIngresar, btnSalir });
            AcceptButton = btnIngresar;
            CancelButton = btnSalir;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario.Length == 0 || clave.Length == 0)
            {
                MessageBox.Show("Ingrese usuario y clave.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (db.validarLogin(usuario, clave))
                {
                    // Acceso concedido: abrir el formulario de usuarios
                    Hide();
                    var f = new frm_usuario();
                    f.FormClosed += (s2, e2) => Close();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Acceso denegado: el usuario o la clave no estan registrados.",
                        "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                    txtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar el acceso:\n" + ex.Message, "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
