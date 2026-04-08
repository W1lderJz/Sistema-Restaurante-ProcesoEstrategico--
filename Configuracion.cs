using PdfSharp.Snippets.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Proyecto_restaurante
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cajaspanel.Location = new Point(221, 4);
            cajaspanel.BringToFront();
            cajaspanel.Visible = true;
        }

        private string IDModificar;
        public int PersonaID;
        public int PermisosUsuarioID;

        string rutaOrigen = @"";

        string rutaDestino = @"C:\SistemaArchivos\DGIITXT\";

        private void guardatbtn_Click(object sender, EventArgs e)
        {
            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();

                    if (string.IsNullOrEmpty(IDModificar))
                    {
                        string queryInsertar = "INSERT INTO Caja (Nombre, Numero, Activo) OUTPUT INSERTED.IdCaja VALUES (@Nombre, @Numero, @Activo)";
                        int nuevoIdCaja = 0;

                        using (SqlCommand insertarCommand = new SqlCommand(queryInsertar, conexion))
                        {
                            insertarCommand.Parameters.AddWithValue("@Nombre", nombrecajatxt.Text);
                            insertarCommand.Parameters.AddWithValue("@Numero", Convert.ToInt32(numerocajatxt.Text));
                            insertarCommand.Parameters.AddWithValue("@Activo", estadocajachk.Checked ? 1 : 0);


                            int rowsAffected = insertarCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Caja creada con exito!.");
                                limpiarbtn_Click(sender, e);
                                recargarbtn_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la configuración de esta PC para actualizar.");
                            }
                        }
                    }
                    else
                    {
                        string queryActualizar = "UPDATE cajas SET nombre_caja = @nuevoNombreCaja, numero_caja = @numeroCaja, estado = @estado, responsable = @responsable where nombre_caja = @nombreCajaActual and id = @idCaja";
                        using (SqlCommand actualizarCommand = new SqlCommand(queryActualizar, conexion))
                        {
                            actualizarCommand.Parameters.AddWithValue("@id", IDModificar.ToString());
                            actualizarCommand.Parameters.AddWithValue("@numeroCaja", numerocajatxt.Text);
                            actualizarCommand.Parameters.AddWithValue("@nombreCaja", nombrecajatxt.Text);
                            actualizarCommand.Parameters.AddWithValue("@estado", estadocajachk.Checked ? 1 : 0);
                            actualizarCommand.Parameters.AddWithValue("@responsable", idPCtxt.Text);

                            int rowsAffected = actualizarCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Caja actualizada con éxito.");
                                limpiarbtn_Click(sender, e);
                                recargarbtn_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar los datos.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            nombrecajatxt.Text = "";
            numerocajatxt.Text = "";
            idPCtxt.Text = "";
            //PCtxt.Text = "";
            pcpanel.Visible = false;
            estadocajachk.Checked = true;
        }

        private void estadochk_CheckedChanged(object sender, EventArgs e)
        {
            if (estadocajachk.Checked == true)
            {
                estadocajachk.Text = "Activo";
                estadocajachk.ForeColor = Color.Lime;
            }
            else if (estadocajachk.Checked == false)
            {

                estadocajachk.Text = "Inactivo";
                estadocajachk.ForeColor = Color.Red;
            }
        }

        private void FiltroDatosBusqueda(string busqueda)
        {
            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conectar = new SqlConnection(conexionString))
            {
                try
                {
                    conectar.Open();

                    string query = @"
                        SELECT * FROM cajas
                        WHERE CAST(id AS VARCHAR) LIKE @buscar OR
                        nombre_caja LIKE @buscar OR
                        numero_caja LIKE @buscar OR
                        responsable LIKE @buscar";

                    using (SqlCommand comando = new SqlCommand(query, conectar))
                    {
                        comando.Parameters.AddWithValue("@buscar", "%" + busqueda + "%");

                        SqlDataAdapter da = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        tabladatos.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void txtbuscador_TextChanged(object sender, EventArgs e)
        {
            FiltroDatosBusqueda(txtbuscador.Text);
            limpiarbtn_Click(sender, e);
        }

        private void eliminarbtn_Click(object sender, EventArgs e)
        {
            txtbuscador.Text = "(ID, Numero, Nombre Caja)";
            limpiarbtn_Click(sender, e);
        }

        private void recargarbtn_Click(object sender, EventArgs e)
        {

        }

        private void Configuracion_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuariospanel.Location = new Point(221, 4);
            usuariospanel.BringToFront();

            string conexionString = ConexionBD.ConexionSQL();
            string consulta = @"
            SELECT 
                u.IdUsuario,
                u.Login,
                p.NombreCompleto,
                e.IdEmpleado
            FROM Usuario u
            LEFT JOIN Persona p ON u.IdPersona = p.IdPersona
            LEFT JOIN Empleado e ON e.IdPersona = p.IdPersona
            WHERE u.Activo = 1 AND p.Activo = 1;
            ";

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexionString);

            DataTable dt = new DataTable();

            adaptador.Fill(dt);

            tablausuarios.DataSource = dt;

            if (tablausuarios.Columns.Contains("IdEmpleado"))
            {
                tablausuarios.Columns["IdEmpleado"].Visible = false;
            }

            usuariospanel.Visible = true;
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idempleadotxt.Text) || string.IsNullOrEmpty(nombreempleadotxt.Text) ||
        string.IsNullOrEmpty(txtRegistroUsuario.Text) || string.IsNullOrEmpty(txtRegistroPass.Text) || string.IsNullOrEmpty(txtconfirmarpass.Text))
            {
                MessageBox.Show("Error: No deje campos vacíos.");
                return;
            }

            if (txtRegistroPass.Text != txtconfirmarpass.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                SqlTransaction trans = conexion.BeginTransaction();

                try
                {
                    string verificarUsuario = "SELECT COUNT(*) FROM Usuario WHERE IdPersona = @IdPersona";
                    using (SqlCommand cmdVerificar = new SqlCommand(verificarUsuario, conexion, trans))
                    {
                        cmdVerificar.Parameters.AddWithValue("@IdPersona", PersonaID);
                        int existe = (int)cmdVerificar.ExecuteScalar();

                        if (existe == 0)
                        {
                            string nuevoUsuario = @"
                            INSERT INTO Usuario (Login, Contrasena, IdPersona, Activo, CreadoEn)
                            VALUES (@Login, @Contrasena, @IdPersona, @Activo, GETDATE());
                            SELECT SCOPE_IDENTITY();";

                            using (SqlCommand insertarUsuario = new SqlCommand(nuevoUsuario, conexion, trans))
                            {
                                insertarUsuario.Parameters.AddWithValue("@Login", txtRegistroUsuario.Text);
                                insertarUsuario.Parameters.AddWithValue("@Contrasena", txtRegistroPass.Text);
                                insertarUsuario.Parameters.AddWithValue("@IdPersona", PersonaID);
                                insertarUsuario.Parameters.AddWithValue("@Activo", estadoempleadochk.Checked ? 1 : 0);

                                insertarUsuario.ExecuteScalar();
                            }

                            trans.Commit();
                            MessageBox.Show("Usuario registrado con éxito.");
                        }
                        else
                        {
                            string actualizarUsuario = @"
                            UPDATE Usuario 
                            SET Login = @Login, Contrasena = @Contrasena, Activo = @Activo
                            WHERE IdPersona = @IdPersona";

                            using (SqlCommand actualizarCommand = new SqlCommand(actualizarUsuario, conexion, trans))
                            {
                                actualizarCommand.Parameters.AddWithValue("@Login", txtRegistroUsuario.Text);
                                actualizarCommand.Parameters.AddWithValue("@Contrasena", txtRegistroPass.Text);
                                actualizarCommand.Parameters.AddWithValue("@Activo", estadoempleadochk.Checked ? 1 : 0);
                                actualizarCommand.Parameters.AddWithValue("@IdPersona", PersonaID);

                                actualizarCommand.ExecuteNonQuery();
                            }

                            trans.Commit();
                            MessageBox.Show("Usuario actualizado con éxito.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
        }

        public int EstadobuscarEmpleado = 1;

        private void buscarempleado_Click(object sender, EventArgs e)
        {
            string conexionString = ConexionBD.ConexionSQL();
            string empleado = @"
                SELECT 
                    e.IdEmpleado,
                    e.IdPersona AS Persona,
                    p.NombreCompleto
                FROM Empleado e
                LEFT JOIN Persona p ON e.IdPersona = p.IdPersona
                LEFT JOIN PersonaDocumento pd ON p.IdPersona = pd.IdPersona
                WHERE e.Activo = 1 AND p.Activo = 1;";

            SqlDataAdapter adaptador = new SqlDataAdapter(empleado, conexionString);

            DataTable dt = new DataTable();

            adaptador.Fill(dt);

            empleadousuariodt.DataSource = dt;

            if (empleadousuariodt.Columns.Contains("Persona"))
                empleadousuariodt.Columns["Persona"].Visible = false;

            if (EstadobuscarEmpleado == 1)
            {
                buscarempleado.Image = Proyecto_restaurante.Properties.Resources.cancelar1;
                toolTip1.SetToolTip(buscarempleado, "Cancelar búsqueda");
                empleadopanel.Visible = true;

                EstadobuscarEmpleado = 0;
            }
            else
            {
                buscarempleado.Image = Proyecto_restaurante.Properties.Resources.busqueda1;
                toolTip1.SetToolTip(buscarempleado, "Buscar Empleado");
                empleadopanel.Visible = false;

                EstadobuscarEmpleado = 1;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            idempleadotxt.Text = idempleadoconsulta.Text;
            nombreempleadotxt.Text = nombreempleadoconsulta.Text;
            buscarempleado_Click(sender, e);
        }

        private void txtRegistroUsuario_TextChanged(object sender, EventArgs e)
        {
            int posicion = txtRegistroUsuario.SelectionStart;

            txtRegistroUsuario.Text.ToUpper();

            txtRegistroUsuario.SelectionStart = posicion;
        }

        private void empleadousuariodt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = empleadousuariodt.Rows[e.RowIndex];

            idempleadoconsulta.Text = fila.Cells["IdEmpleado"].Value.ToString();
            PersonaID = Convert.ToInt32(fila.Cells["Persona"].Value);
            nombreempleadoconsulta.Text = fila.Cells["NombreCompleto"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            IDModificar = "";
        }

        private void tablausuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tablausuarios.Rows[e.RowIndex];

                if (fila.Cells["IdEmpleado"].Value != DBNull.Value)
                {
                    int idEmpleado = Convert.ToInt32(fila.Cells["IdEmpleado"].Value);
                    PermisosUsuarioID = Convert.ToInt32(fila.Cells["IdUsuario"].Value);

                    idusuariopermiso.Text = fila.Cells["IdUsuario"].Value.ToString();
                    usuariologin.Text = fila.Cells["Login"].Value.ToString();

                    string rutaImagenes = @"C:\SistemaArchivos\Empleados\";
                    string rutaImagenEmpleado = Path.Combine(rutaImagenes, idEmpleado + ".jpg");

                    if (usuarioimg.Image != null)
                    {
                        usuarioimg.Image.Dispose();
                        usuarioimg.Image = null;
                    }

                    if (File.Exists(rutaImagenEmpleado))
                    {
                        using (FileStream fs = new FileStream(rutaImagenEmpleado, FileMode.Open, FileAccess.Read))
                        {
                            usuarioimg.Image = Image.FromStream(fs);
                        }
                    }
                    else
                    {
                        usuarioimg.Image = Proyecto_restaurante.Properties.Resources.perfilcliente;
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            colores.Location = new Point(221, 4);
            colores.BringToFront();
            colores.Visible = true;
        }

        public int UsuarioID;

        private void guardarpermisosbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idusuariopermiso.Text))
            {
                MessageBox.Show("Error: No deje campos vacíos.");
                return;
            }

            string conexionString = ConexionBD.ConexionSQL();
            int idUsuario = Convert.ToInt32(idusuariopermiso.Text);

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();

                    string verificarQuery = "SELECT COUNT(*) FROM PermisosUsuario WHERE IdUsuario = @IdUsuario";
                    int existe = 0;

                    using (SqlCommand cmdVerificar = new SqlCommand(verificarQuery, conexion))
                    {
                        cmdVerificar.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());
                    }

                    if (existe == 0)
                    {
                        string queryInsertar = "INSERT INTO PermisosUsuario (IdUsuario, Admin, CrearOrdenReservacion, CancelarDoc, CambiarPrecio, PrecioMinimo) VALUES (@IdUsuario, @Admin, @CrearOrdenReservacion, @Cancelar, @CambiarPrecio, @PrecioMinimo)";
                        using (SqlCommand cmdInsertar = new SqlCommand(queryInsertar, conexion))
                        {
                            cmdInsertar.Parameters.AddWithValue("@IdUsuario", idUsuario);
                            cmdInsertar.Parameters.AddWithValue("@Admin", admin.Checked ? 1 : 0);
                            cmdInsertar.Parameters.AddWithValue("@CrearOrdenReservacion", CrearOrdenReservado.Checked ? 1 : 0);
                            cmdInsertar.Parameters.AddWithValue("@Cancelar", cancelarDoc.Checked ? 1 : 0);
                            cmdInsertar.Parameters.AddWithValue("@CambiarPrecio", cambiarPrecio.Checked ? 1 : 0);
                            cmdInsertar.Parameters.AddWithValue("@PrecioMinimo", cambiarPrecio.Checked ? 1 : 0);
                            cmdInsertar.ExecuteNonQuery();
                        }

                        MessageBox.Show("Permisos asignados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string queryActualizar = @"UPDATE PermisosUsuario SET Admin = @Admin, CrearOrdenReservacion = @CrearOrdenReservacion, 
                        CancelarDoc = @Cancelar, CambiarPrecio = @CambiarPrecio, PrecioMinimo = @PrecioMinimo WHERE IdUsuario = @IdUsuario";

                        using (SqlCommand cmdActualizar = new SqlCommand(queryActualizar, conexion))
                        {
                            cmdActualizar.Parameters.AddWithValue("@IdUsuario", idUsuario);
                            cmdActualizar.Parameters.AddWithValue("@Admin", admin.Checked ? 1 : 0);
                            cmdActualizar.Parameters.AddWithValue("@CrearOrdenReservacion", CrearOrdenReservado.Checked ? 1 : 0);
                            cmdActualizar.Parameters.AddWithValue("@Cancelar", cancelarDoc.Checked ? 1 : 0);
                            cmdActualizar.Parameters.AddWithValue("@CambiarPrecio", cambiarPrecio.Checked ? 1 : 0);
                            cmdActualizar.Parameters.AddWithValue("@PrecioMinimo", precminimo.Checked ? 1 : 0);
                            cmdActualizar.ExecuteNonQuery();
                        }

                        MessageBox.Show("Permisos actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cargarPermisos(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(tablausuarios.SelectedRows[0].Cells["IdUsuario"].Value);

            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();

                string query = @"
                SELECT Admin, CrearOrdenReservacion, CancelarDoc, CambiarPrecio, PrecioMinimo
                FROM PermisosUsuario
                WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            admin.Checked = Convert.ToInt32(dr["Admin"]) == 1;
                            CrearOrdenReservado.Checked = Convert.ToInt32(dr["CrearOrdenReservacion"]) == 1;
                            cancelarDoc.Checked = Convert.ToInt32(dr["CancelarDoc"]) == 1;
                            cambiarPrecio.Checked = Convert.ToInt32(dr["CambiarPrecio"]) == 1;
                            precminimo.Enabled = Convert.ToInt32(dr["PrecioMinimo"]) == 1;
                            precminimo.Checked = Convert.ToInt32(dr["PrecioMinimo"]) == 1;

                            cambiarPrecio_CheckedChanged(sender, e);
                        }
                        else
                        {
                            admin.Checked = false;
                            CrearOrdenReservado.Checked = false;
                            cancelarDoc.Checked = false;
                            cambiarPrecio.Checked = false;
                            precminimo.Enabled = false;
                            precminimo.Checked = false;
                        }
                    }
                }
            }
        }


        private void button29_Click(object sender, EventArgs e)
        {
            if (tablausuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(tablausuarios.SelectedRows[0].Cells["IdUsuario"].Value);
            string login = tablausuarios.SelectedRows[0].Cells["Login"].Value.ToString();

            idusuariopermiso.Text = idUsuario.ToString();
            usuariologin.Text = login;

            permisospanel.Location = new Point(221, 4);
            permisospanel.BringToFront();
            permisospanel.Visible = true;

            usuariospanel.Visible = false;

            cargarPermisos(sender, e);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            usuariospanel.Location = new Point(221, 4);
            usuariospanel.BringToFront();

            permisospanel.Visible = false;

            usuariospanel.Visible = true;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            cajaspanel.Visible = false;
            usuariospanel.Visible = false;
            colores.Visible = false;
            permisospanel.Visible = false;
            sistemaconfiguracion.Visible = false;
            DGIIPanel.Visible = false;
            datosPanel.Visible = false;
        }

        private void agregar_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            numerocajatxt.Focus();
        }

        private string colorRGB = "";
        private string nombrePC = Environment.MachineName;
        private string conexionString = ConexionBD.ConexionSQL();

        private void guardarcolorbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(colorRGB))
            {
                MessageBox.Show("Debe seleccionar un color antes de guardar.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();

                string query = @"
                IF EXISTS (SELECT 1 FROM Configuracion WHERE NombrePC = @NombrePC)
                    UPDATE Configuracion SET ColorPanel = @ColorPanel WHERE NombrePC = @NombrePC
                ELSE
                    INSERT INTO Configuracion (NombrePC, ColorPanel) VALUES (@NombrePC, @ColorPanel);";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@NombrePC", nombrePC);
                    cmd.Parameters.AddWithValue("@ColorPanel", colorRGB);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Exito, reinicie el sistema para que se apliquen los cambios!.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buscarcolor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color colorSeleccionado = colorDialog.Color;

                    vistaprevia.BackColor = colorSeleccionado;

                    colorRGB = $"{colorSeleccionado.R},{colorSeleccionado.G},{colorSeleccionado.B}";
                }
            }
        }

        private void defaultcolor_Click(object sender, EventArgs e)
        {
            Color colorDefault = Color.Silver;

            vistaprevia.BackColor = colorDefault;

            colorRGB = $"{colorDefault.R},{colorDefault.G},{colorDefault.B}";
        }

        private void numerocajatxt_TextChanged(object sender, EventArgs e)
        {
            nombrecajatxt.Text = "Caja #" + numerocajatxt.Text;
        }

        public int EstadobuscarPC = 1;

        private void buscarPC_Click(object sender, EventArgs e)
        {
            string conexionString = ConexionBD.ConexionSQL();
            string puesto = "select Id, NombrePC from Configuracion";

            SqlDataAdapter adaptador = new SqlDataAdapter(puesto, conexionString);

            DataTable dt = new DataTable();

            adaptador.Fill(dt);

            pcDT.DataSource = dt;

            if (EstadobuscarPC == 1)
            {
                buscarPC.Image = Proyecto_restaurante.Properties.Resources.cancelar1;
                toolTip1.SetToolTip(buscarPC, "Cancelar búsqueda");
                pcpanel.Visible = true;

                EstadobuscarPC = 0;
            }
            else
            {
                buscarPC.Image = Proyecto_restaurante.Properties.Resources.busqueda1;
                toolTip1.SetToolTip(buscarPC, "Buscar PC");
                pcpanel.Visible = false;

                EstadobuscarPC = 1;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            idPCtxt.Text = idpcconsultatxt.Text;
            nombrepctxt.Text = nombrepcconsultatxt.Text;
            buscarPC_Click(sender, e);
        }

        private void pcDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idpcconsultatxt.Text = pcDT.SelectedCells[0].Value.ToString();
            nombrepcconsultatxt.Text = pcDT.SelectedCells[1].Value.ToString();
        }

        public int EstadobuscarCaja = 1;

        private void buscarCaja_Click(object sender, EventArgs e)
        {
            string conexionString = ConexionBD.ConexionSQL();
            string puesto = "select IdCaja, Nombre from Caja";

            SqlDataAdapter adaptador = new SqlDataAdapter(puesto, conexionString);

            DataTable dt = new DataTable();

            adaptador.Fill(dt);

            cajaDT.DataSource = dt;

            if (EstadobuscarCaja == 1)
            {
                buscarCaja.Image = Proyecto_restaurante.Properties.Resources.cancelar1;
                toolTip1.SetToolTip(buscarCaja, "Cancelar búsqueda");
                cajapanel.Visible = true;

                EstadobuscarCaja = 0;
            }
            else
            {
                buscarCaja.Image = Proyecto_restaurante.Properties.Resources.busqueda1;
                toolTip1.SetToolTip(buscarCaja, "Buscar caja");
                cajapanel.Visible = false;

                EstadobuscarCaja = 1;
            }
        }

        private void guardarasigpc_Click(object sender, EventArgs e)
        {
            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();

                    if (string.IsNullOrEmpty(IDModificar))
                    {
                        string queryInsertar = "Update Configuracion set IdCaja = @IdCaja where Id= @IdPC";

                        using (SqlCommand insertarCommand = new SqlCommand(queryInsertar, conexion))
                        {
                            insertarCommand.Parameters.AddWithValue("@IdCaja", idCajatxt.Text);
                            insertarCommand.Parameters.AddWithValue("@IdPC", idPCtxt.Text);

                            int rowsAffected = insertarCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Caja asignada con exito!.");
                                limpiarbtn_Click(sender, e);
                                recargarbtn_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la configuración de esta PC para actualizar.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
        }

        private void asignarcaja_Click(object sender, EventArgs e)
        {
            asignarPCPanel.Location = new Point(221, 4);
            asignarPCPanel.BringToFront();
            asignarPCPanel.Visible = true;
        }

        private void cajaDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idconsultacajatxt.Text = cajaDT.SelectedCells[0].Value.ToString();
            nombreconsultacajatxt.Text = cajaDT.SelectedCells[1].Value.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            idCajatxt.Text = idconsultacajatxt.Text;
            nombrecajaPCtxt.Text = nombreconsultacajatxt.Text;
            buscarCaja_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sistemaconfiguracion.Location = new Point(221, 4);
            sistemaconfiguracion.BringToFront();
            sistemaconfiguracion.Visible = true;

            CargarConfiguracion();
        }

        private void CargarConfiguracion()
        {
            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();

                string query = @"
                SELECT TOP 1 PorcentajeGanancia 
                FROM ConfiguracionSistema";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        porcGanancia.Text = result.ToString();
                    }
                    else
                    {
                        porcGanancia.Text = "0";
                    }
                }
            }
        }

        private void buscarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Seleccionar archivo DGII";
            ofd.Filter = "Archivos TXT (*.txt)|*.txt";
            ofd.InitialDirectory = @"C:\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaOrigentxt.Text = "Ruta Origen: " + ofd.FileName;
                rutaOrigen = ofd.FileName;
            }
        }

        private void archivoDGII_Click(object sender, EventArgs e)
        {
            DGIIPanel.Location = new Point(221, 4);
            DGIIPanel.BringToFront();
            DGIIPanel.Visible = true;
        }

        private void ImportarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                string origen = rutaOrigen;

                string destinoCarpeta = rutaDestino;

                if (string.IsNullOrWhiteSpace(origen) || !File.Exists(origen))
                {
                    MessageBox.Show("Debe seleccionar un archivo válido.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Directory.Exists(destinoCarpeta))
                    Directory.CreateDirectory(destinoCarpeta);

                string nombreArchivo = Path.GetFileName(origen);
                string destinoCompleto = Path.Combine(destinoCarpeta, nombreArchivo);

                File.Copy(origen, destinoCompleto, true);

                MessageBox.Show("Archivo copiado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al copiar el archivo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datosRestaurante_Click(object sender, EventArgs e)
        {
            datosPanel.Location = new Point(221, 4);
            datosPanel.BringToFront();
            datosPanel.Visible = true;
        }

        private void procesarConfig_Click(object sender, EventArgs e)
        {
            string conexionString = ConexionBD.ConexionSQL();

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();

                    if (string.IsNullOrEmpty(IDModificar))
                    {
                        string queryInsertar = "Update ConfiguracionSistema set PorcentajeGanancia = @PorcGanancia where IdConfiguracion = 1";

                        using (SqlCommand insertarConfig = new SqlCommand(queryInsertar, conexion))
                        {
                            insertarConfig.Parameters.AddWithValue("@PorcGanancia", porcGanancia.Text);

                            int rowsAffected = insertarConfig.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Configuracion aplicada!.");
                                recargarbtn_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo aplicar la configuracion");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
        }

        private void admin_CheckedChanged(object sender, EventArgs e)
        {
            if (admin.Checked == true)
            {
                CrearOrdenReservado.Checked = true;
                cancelarDoc.Checked = true;
                cambiarPrecio.Checked = true;
                precminimo.Enabled = true;
            }
            else
            {
                CrearOrdenReservado.Checked = false;
                cancelarDoc.Checked = false;
                cambiarPrecio.Checked = false;
                precminimo.Enabled = false;
            }
        }

        private void empleadousuariodt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button10_Click(sender, e);
        }

        private void pcDT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button15_Click(sender, e);
        }

        private void cajaDT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button11_Click(sender, e);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            asignarPCPanel.Visible = false;

            cajaspanel.BringToFront();
            cajaspanel.Visible = true;
        }

        private void cambiarPrecio_CheckedChanged(object sender, EventArgs e)
        {
            if (cambiarPrecio.Checked == false)
            {
                precminimo.Enabled = false;
                precminimo.Checked = false;
            }
            else
            {
                precminimo.Enabled = true;
            }
        }
    }
}