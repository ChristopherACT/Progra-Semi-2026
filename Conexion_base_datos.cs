using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UsuariosUSSS004525
{
    public class Conexion_base_datos
    {
        public const string TABLA = "usuarios_USSS004525";

        private readonly string cadena;
        private readonly string baseDatos;
        private readonly string cadenaMaster;

        public Conexion_base_datos()
        {
            cadena = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
            var b = new SqlConnectionStringBuilder(cadena);
            baseDatos = b.InitialCatalog;
            b.InitialCatalog = "master";
            cadenaMaster = b.ConnectionString;
        }

        // ------------------------------------------------------------------
        // Crea la base de datos, la tabla usuarios_USSS004525 y 3 registros
        // (solo si no existen todavia).
        // ------------------------------------------------------------------
        public void asegurarBaseDatos()
        {
            using (var cn = new SqlConnection(cadenaMaster))
            {
                cn.Open();
                string sqlDb = "IF DB_ID(@db) IS NULL EXEC('CREATE DATABASE [' + @db + ']')";
                using (var cmd = new SqlCommand(sqlDb, cn))
                {
                    cmd.Parameters.AddWithValue("@db", baseDatos);
                    cmd.ExecuteNonQuery();
                }
            }

            string sqlTabla =
                "IF OBJECT_ID('" + TABLA + "', 'U') IS NULL " +
                "CREATE TABLE " + TABLA + " (" +
                "  idUsuario INT IDENTITY(1,1) PRIMARY KEY," +
                "  usuario   VARCHAR(35) NOT NULL," +
                "  clave     VARCHAR(35) NOT NULL," +
                "  nombre    VARCHAR(65) NOT NULL," +
                "  direccion VARCHAR(85) NULL," +
                "  telefono  VARCHAR(9)  NULL)";
            procesar(sqlTabla);

            // 3 registros iniciales
            int total = Convert.ToInt32(ejecutarEscalar("SELECT COUNT(*) FROM " + TABLA));
            if (total == 0)
            {
                mantenimiento_usuarios_USSS004525("agregar", 0, "usuario01", "Clave123", "Maria Lopez", "Usulutan, El Salvador", "7777-0001");
                mantenimiento_usuarios_USSS004525("agregar", 0, "usuario02", "Clave456", "Carlos Martinez", "San Miguel, El Salvador", "7777-0002");
                mantenimiento_usuarios_USSS004525("agregar", 0, "usuario03", "Clave789", "Ana Hernandez", "Santiago de Maria, Usulutan", "7777-0003");
            }
        }

        // ------------------------------------------------------------------
        // Crea el DataSet para la tabla usuarios
        // ------------------------------------------------------------------
        public DataSet crearDs()
        {
            return crearDs("SELECT idUsuario, usuario, clave, nombre, direccion, telefono " +
                           "FROM " + TABLA + " ORDER BY idUsuario", TABLA);
        }

        public DataSet crearDs(string sql, string nombreTabla)
        {
            var ds = new DataSet();
            using (var cn = new SqlConnection(cadena))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.Fill(ds, nombreTabla);
            }
            return ds;
        }

        // ------------------------------------------------------------------
        // Metodo procesar: ejecuta INSERT / UPDATE / DELETE
        // ------------------------------------------------------------------
        public bool procesar(string sql, params SqlParameter[] parametros)
        {
            using (var cn = new SqlConnection(cadena))
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (parametros != null && parametros.Length > 0)
                    cmd.Parameters.AddRange(parametros);
                cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        // ------------------------------------------------------------------
        // Mantenimiento de usuarios: agregar / modificar / eliminar.
        // Este metodo llama al metodo procesar.
        // ------------------------------------------------------------------
        public bool mantenimiento_usuarios_USSS004525(string accion, int idUsuario, string usuario,
            string clave, string nombre, string direccion, string telefono)
        {
            string sql;
            SqlParameter[] p;

            switch ((accion ?? "").ToLowerInvariant())
            {
                case "agregar":
                    sql = "INSERT INTO " + TABLA + " (usuario, clave, nombre, direccion, telefono) " +
                          "VALUES (@usuario, @clave, @nombre, @direccion, @telefono)";
                    p = new[]
                    {
                        new SqlParameter("@usuario", usuario),
                        new SqlParameter("@clave", clave),
                        new SqlParameter("@nombre", nombre),
                        new SqlParameter("@direccion", (object)direccion ?? DBNull.Value),
                        new SqlParameter("@telefono", (object)telefono ?? DBNull.Value)
                    };
                    break;

                case "modificar":
                    sql = "UPDATE " + TABLA + " SET usuario=@usuario, clave=@clave, nombre=@nombre, " +
                          "direccion=@direccion, telefono=@telefono WHERE idUsuario=@id";
                    p = new[]
                    {
                        new SqlParameter("@usuario", usuario),
                        new SqlParameter("@clave", clave),
                        new SqlParameter("@nombre", nombre),
                        new SqlParameter("@direccion", (object)direccion ?? DBNull.Value),
                        new SqlParameter("@telefono", (object)telefono ?? DBNull.Value),
                        new SqlParameter("@id", idUsuario)
                    };
                    break;

                case "eliminar":
                    sql = "DELETE FROM " + TABLA + " WHERE idUsuario=@id";
                    p = new[] { new SqlParameter("@id", idUsuario) };
                    break;

                default:
                    throw new ArgumentException("Accion no valida: " + accion);
            }

            return procesar(sql, p);
        }

        // ------------------------------------------------------------------
        // Utilidades
        // ------------------------------------------------------------------
        public bool existeUsuario(string usuario, int idExcluir)
        {
            using (var cn = new SqlConnection(cadena))
            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM " + TABLA + " WHERE usuario=@u AND idUsuario<>@id", cn))
            {
                cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@id", idExcluir);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool validarLogin(string usuario, string clave)
        {
            using (var cn = new SqlConnection(cadena))
            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM " + TABLA + " WHERE usuario=@u AND clave=@c", cn))
            {
                cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@c", clave);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private object ejecutarEscalar(string sql)
        {
            using (var cn = new SqlConnection(cadena))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
