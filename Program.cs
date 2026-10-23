using System;
using System.Windows.Forms;

namespace UsuariosUSSS004525
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                new Conexion_base_datos().asegurarBaseDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo conectar con SQL Server.\n\n" + ex.Message +
                    "\n\nRevise la cadena de conexion en App.config (UsuariosUSSS004525.exe.config).",
                    "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // El login es el primer formulario que aparece al ejecutar la aplicacion
            Application.Run(new login());
        }
    }
}
