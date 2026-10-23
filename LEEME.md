# Proyecto Windows Forms - Segundo Parcial (USSS004525)

Programación Computacional I - Universidad Gerardo Barrios, CRU.

## Cómo ejecutarlo
1. Descomprima el ZIP y abra `UsuariosUSSS004525.csproj` con **Visual Studio 2019/2022** (carga de trabajo "Desarrollo de escritorio con .NET").
2. Revise la cadena de conexión en `App.config` (`Server=.\SQLEXPRESS` por defecto; para LocalDB use `(localdb)\MSSQLLocalDB`).
3. Presione F5. La aplicación crea sola la base de datos `db_proyecto_USSS004525`, la tabla `usuarios_USSS004525` y 3 registros.
   (También se incluye `script_sql_USSS004525.sql` por si prefiere crearlos a mano en SSMS.)

## Usuarios de prueba
| usuario   | clave    |
|-----------|----------|
| usuario01 | Clave123 |
| usuario02 | Clave456 |
| usuario03 | Clave789 |

## Qué cumple cada punto del examen
1. Tabla `usuarios_USSS004525` con idUsuario (int, auto incremento), usuario(35), clave(35), nombre(65), direccion(85), telefono(9) y 3 registros.
2. `frm_usuario`: todos los campos, botones de navegación (|< < > >|) y edición (Nuevo, Agregar, Modificar, Eliminar). Valida clave con confirmación y con letras y números, y usuario de 6 a 16 caracteres; si no cumple, no guarda.
3. `Conexion_base_datos.crearDs()` crea el DataSet de la tabla usuarios.
4. `Conexion_base_datos.mantenimiento_usuarios_USSS004525(...)` llama al método `procesar`.
5. `login`: pide usuario y clave, niega el acceso si no están registrados y es el primer formulario que se abre.

Nota: en SQL Server las columnas se llaman `direccion` y `telefono` (sin tilde) para evitar problemas de codificación; en el formulario se muestran con tilde.
