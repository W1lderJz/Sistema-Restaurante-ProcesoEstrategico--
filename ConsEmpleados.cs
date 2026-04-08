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
    public partial class ConsEmpleados : Form
    {
        public ConsEmpleados()
        {
            InitializeComponent();

            toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(recargarbtn, "Recargar");
            toolTip1.SetToolTip(filtro, "Estado");
            toolTip1.SetToolTip(eliminarbtn, "Limpiar filtros");
        }

        public int PersonaID;
        private int EmpleadoID;
        public int EditarEmpleado = 0;
        public int DirActivado = 0;
        public int TelActivado = 0;
        public int EliminarNum = 0;
        public int EliminarDir = 0;

        string conexionString = ConexionBD.ConexionSQL();

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtapellido.Text) ||
            string.IsNullOrEmpty(txtcedula.Text) || string.IsNullOrEmpty(txtsueldo.Text) ||
            string.IsNullOrEmpty(idpuestotxt.Text))
            {
                MessageBox.Show("Error: No deje campos vacíos.");
                return;
            }

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                SqlTransaction trans = conexion.BeginTransaction();

                try
                {
                    if (EditarEmpleado == 0)
                    {
                        string nuevaPersona = @"
                        INSERT INTO Persona (Nombre, Apellido, Email, Activo, CreadoEn)
                        VALUES (@Nombre, @Apellido, @Email, @Activo, GETDATE());
                        SELECT SCOPE_IDENTITY();";

                        using (SqlCommand insertarPersona = new SqlCommand(nuevaPersona, conexion, trans))
                        {
                            insertarPersona.Parameters.AddWithValue("@Nombre", txtnombre.Text);
                            insertarPersona.Parameters.AddWithValue("@Apellido", txtapellido.Text);
                            insertarPersona.Parameters.AddWithValue("@Email", emailtxt.Text);
                            insertarPersona.Parameters.AddWithValue("@Activo", estadochk.Checked ? 1 : 0);

                            PersonaID = Convert.ToInt32(insertarPersona.ExecuteScalar());
                        }

                        string nuevoEmpleado = @"
                        INSERT INTO Empleado (IdPersona, IdPuesto, FechaIngreso, Activo, Sueldo, TipoSueldo, IdRolempleado)
                        VALUES (@IdPersona, @IdPuesto, @FechaIngreso, @Activo, @Sueldo, @TipoSueldo, @IdRol)";

                        using (SqlCommand insertarEmpleado = new SqlCommand(nuevoEmpleado, conexion, trans))
                        {
                            insertarEmpleado.Parameters.AddWithValue("@IdPersona", PersonaID);
                            insertarEmpleado.Parameters.AddWithValue("@IdPuesto", Convert.ToInt32(idpuestotxt.Text));
                            insertarEmpleado.Parameters.AddWithValue("@Sueldo", Convert.ToDecimal(txtsueldo.Text));
                            insertarEmpleado.Parameters.AddWithValue("@FechaIngreso", fechaingreso.Value);
                            insertarEmpleado.Parameters.AddWithValue("@TipoSueldo", Convert.ToInt32(tiposueldocmbx.SelectedValue));
                            insertarEmpleado.Parameters.AddWithValue("@IdRol", Convert.ToInt32(rolcmbx.SelectedValue));
                            insertarEmpleado.Parameters.AddWithValue("@Activo", estadochk.Checked ? 1 : 0);

                            insertarEmpleado.ExecuteNonQuery();
                        }

                        string nuevoDoc = @"
                        INSERT INTO PersonaDocumento (IdPersona, IdTipoDocumento, Numero, EsPrincipal)
                        VALUES (@IdPersona, 1, @Numero, 1)";

                        using (SqlCommand insertarDocumento = new SqlCommand(nuevoDoc, conexion, trans))
                        {
                            insertarDocumento.Parameters.AddWithValue("@IdPersona", PersonaID);
                            insertarDocumento.Parameters.AddWithValue("@Numero", txtcedula.Text);

                            insertarDocumento.ExecuteNonQuery();
                        }

                        foreach (DataGridViewRow fila in numeroEmpleado.Rows)
                        {
                            if (fila.IsNewRow) continue;

                            string nombre = fila.Cells["nombre"].Value?.ToString();
                            string numero = fila.Cells["numero"].Value?.ToString();
                            int esPrincipal = Convert.ToBoolean(fila.Cells["principal"].Value) ? 1 : 0;

                            string queryTelefono = @"
                            INSERT INTO PersonaTelefono (IdPersona, Numero, EsPrincipal, NombreTelefono)
                            VALUES (@IdPersona, @Numero, @EsPrincipal, @NombreTelefono)";

                            using (SqlCommand cmdTelefono = new SqlCommand(queryTelefono, conexion, trans))
                            {
                                cmdTelefono.Parameters.AddWithValue("@IdPersona", PersonaID);
                                cmdTelefono.Parameters.AddWithValue("@Numero", numero);
                                cmdTelefono.Parameters.AddWithValue("@EsPrincipal", esPrincipal);
                                cmdTelefono.Parameters.AddWithValue("@NombreTelefono", nombre);

                                cmdTelefono.ExecuteNonQuery();
                            }
                        }

                        foreach (DataGridViewRow fila in direccionEmpleado.Rows)
                        {
                            if (fila.IsNewRow) continue;

                            string nombre = fila.Cells["nombre"].Value?.ToString();
                            string direccion = fila.Cells["direccion"].Value?.ToString();
                            int esPrincipal = Convert.ToBoolean(fila.Cells["principal"].Value) ? 1 : 0;

                            string queryDireccion = @"
                            INSERT INTO PersonaDireccion (IdPersona, Direccion, EsPrincipal, Nombre)
                            VALUES (@IdPersona, @Direccion, @EsPrincipal, @Nombre)";

                            using (SqlCommand cmdDireccion = new SqlCommand(queryDireccion, conexion, trans))
                            {
                                cmdDireccion.Parameters.AddWithValue("@IdPersona", PersonaID);
                                cmdDireccion.Parameters.AddWithValue("@Nombre", nombre);
                                cmdDireccion.Parameters.AddWithValue("@Direccion", direccion);
                                cmdDireccion.Parameters.AddWithValue("@EsPrincipal", esPrincipal);

                                cmdDireccion.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        MessageBox.Show("Empleado registrado con éxito.");
                    }
                    else if (EditarEmpleado == 1)
                    {
                        string actualizarPersona = @"
                        UPDATE Persona 
                        SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Activo = @Activo 
                        WHERE IdPersona = @IdPersona";

                        using (SqlCommand actualizarCommand = new SqlCommand(actualizarPersona, conexion, trans))
                        {
                            actualizarCommand.Parameters.AddWithValue("@IdPersona", PersonaID);
                            actualizarCommand.Parameters.AddWithValue("@Nombre", txtnombre.Text);
                            actualizarCommand.Parameters.AddWithValue("@Apellido", txtapellido.Text);
                            actualizarCommand.Parameters.AddWithValue("@Email", emailtxt.Text);
                            actualizarCommand.Parameters.AddWithValue("@Activo", estadochk.Checked ? 1 : 0);
                            actualizarCommand.ExecuteNonQuery();
                        }

                        string actualizarEmpleado = @"
                        UPDATE Empleado 
                        SET IdPuesto = @IdPuesto, Sueldo = @Sueldo, FechaIngreso = @FechaIngreso, 
                            TipoSueldo = @TipoSueldo, Activo = @Activo, IdRolempleado = @IdRol 
                        WHERE IdEmpleado = @IdEmpleado";

                        using (SqlCommand actualizarCommand = new SqlCommand(actualizarEmpleado, conexion, trans))
                        {
                            actualizarCommand.Parameters.AddWithValue("@IdEmpleado", EmpleadoID);
                            actualizarCommand.Parameters.AddWithValue("@IdPuesto", Convert.ToInt32(idpuestotxt.Text));
                            actualizarCommand.Parameters.AddWithValue("@Sueldo", Convert.ToDecimal(txtsueldo.Text));
                            actualizarCommand.Parameters.AddWithValue("@FechaIngreso", fechaingreso.Value);
                            actualizarCommand.Parameters.AddWithValue("@TipoSueldo", Convert.ToInt32(tiposueldocmbx.SelectedValue));
                            actualizarCommand.Parameters.AddWithValue("@IdRol", Convert.ToInt32(rolcmbx.SelectedValue));
                            actualizarCommand.Parameters.AddWithValue("@Activo", estadochk.Checked ? 1 : 0);
                            actualizarCommand.ExecuteNonQuery();
                        }

                        string actualizarDoc = @"
                        UPDATE PersonaDocumento
                        SET Numero = @Numero
                        WHERE IdPersona = @IdPersona AND EsPrincipal = 1";

                        using (SqlCommand cmdDoc = new SqlCommand(actualizarDoc, conexion, trans))
                        {
                            cmdDoc.Parameters.AddWithValue("@IdPersona", PersonaID);
                            cmdDoc.Parameters.AddWithValue("@Numero", txtcedula.Text);
                            cmdDoc.ExecuteNonQuery();
                        }

                        foreach (DataGridViewRow fila in numeroEmpleado.Rows)
                        {
                            if (fila.IsNewRow) continue;

                            string nombre = fila.Cells["nombre"].Value?.ToString();
                            string numero = fila.Cells["numero"].Value?.ToString();
                            int esPrincipal = Convert.ToBoolean(fila.Cells["principal"].Value) ? 1 : 0;

                            string queryTelefono = @"
                            IF EXISTS (SELECT 1 FROM PersonaTelefono WHERE IdPersona = @IdPersona AND Numero = @Numero)
                            UPDATE PersonaTelefono
                            SET NombreTelefono = @NombreTelefono, EsPrincipal = @EsPrincipal
                            WHERE IdPersona = @IdPersona AND Numero = @Numero
                            ELSE
                            INSERT INTO PersonaTelefono (IdPersona, Numero, EsPrincipal, NombreTelefono)
                            VALUES (@IdPersona, @Numero, @EsPrincipal, @NombreTelefono)";

                            using (SqlCommand cmdTelefono = new SqlCommand(queryTelefono, conexion, trans))
                            {
                                cmdTelefono.Parameters.AddWithValue("@IdPersona", PersonaID);
                                cmdTelefono.Parameters.AddWithValue("@Numero", numero);
                                cmdTelefono.Parameters.AddWithValue("@EsPrincipal", esPrincipal);
                                cmdTelefono.Parameters.AddWithValue("@NombreTelefono", nombre);

                                cmdTelefono.ExecuteNonQuery();
                            }
                        }

                        foreach (DataGridViewRow fila in direccionEmpleado.Rows)
                        {
                            if (fila.IsNewRow) continue;

                            string nombre = fila.Cells["nombre"].Value?.ToString();
                            string direccion = fila.Cells["direccion"].Value?.ToString();
                            int esPrincipal = Convert.ToBoolean(fila.Cells["principal"].Value) ? 1 : 0;

                            string queryDireccion = @"
                            IF EXISTS (SELECT 1 FROM PersonaDireccion WHERE IdPersona = @IdPersona AND Direccion = @Direccion)
                            UPDATE PersonaDireccion
                            SET Nombre = @Nombre, EsPrincipal = @EsPrincipal
                            WHERE IdPersona = @IdPersona AND Direccion = @Direccion
                            ELSE
                            INSERT INTO PersonaDireccion (IdPersona, Direccion, EsPrincipal, Nombre)
                            VALUES (@IdPersona, @Direccion, @EsPrincipal, @Nombre)";

                            using (SqlCommand cmdDireccion = new SqlCommand(queryDireccion, conexion, trans))
                            {
                                cmdDireccion.Parameters.AddWithValue("@IdPersona", PersonaID);
                                cmdDireccion.Parameters.AddWithValue("@Nombre", nombre);
                                cmdDireccion.Parameters.AddWithValue("@Direccion", direccion);
                                cmdDireccion.Parameters.AddWithValue("@EsPrincipal", esPrincipal);

                                cmdDireccion.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        MessageBox.Show("Empleado actualizado con éxito.");
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
        }

        public int Estadobuscarpuesto = 1;

        private void buscarpuesto_Click(object sender, EventArgs e)
        {
            string conexionString = ConexionBD.ConexionSQL();
            string puesto = "select IdPuesto, Nombre from Puesto";

            SqlDataAdapter adaptador = new SqlDataAdapter(puesto, conexionString);

            DataTable dt = new DataTable();

            adaptador.Fill(dt);

            puestoconsulta.DataSource = dt;

            if (Estadobuscarpuesto == 1)
            {
                buscarpuesto.Image = Proyecto_restaurante.Properties.Resources.cancelar1;
                toolTip1.SetToolTip(buscarpuesto, "Cancelar búsqueda");
                puestopanel.Visible = true;

                Estadobuscarpuesto = 0;
            }
            else
            {
                buscarpuesto.Image = Proyecto_restaurante.Properties.Resources.busqueda1;
                toolTip1.SetToolTip(buscarpuesto, "Buscar departamento");
                puestopanel.Visible = false;

                Estadobuscarpuesto = 1;
            }
        }

        private void ConsEmpleados_Load(object sender, EventArgs e)
        {
            string conexionString = ConexionBD.ConexionSQL();

            try
            {
                string consultaEmpleados = @"
                SELECT 
                    e.IdEmpleado,
                    p.NombreCompleto,
                    pd.Numero AS Cedula
                FROM Empleado e
                LEFT JOIN Persona p ON e.IdPersona = p.IdPersona
                LEFT JOIN PersonaDocumento pd ON p.IdPersona = pd.IdPersona
                WHERE e.Activo = 1 AND p.Activo = 1;";

                using (SqlDataAdapter adaptador = new SqlDataAdapter(consultaEmpleados, conexionString))
                {
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    tabladatos.DataSource = dt;
                }

                string consultaUltimoID = "SELECT ISNULL(MAX(IdEmpleado) + 1, 0) FROM Empleado";

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(consultaUltimoID, conexion))
                    {
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null && resultado != DBNull.Value)
                        {
                            idUltimoEmpleado.Text = resultado.ToString();
                        }
                        else
                        {
                            idUltimoEmpleado.Text = "?";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos: {ex.Message}");
            }
        }

        private void puestoconsulta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            puestoconsulta_CellClick(sender, e);
        }

        private void txtcedula_TextChanged(object sender, EventArgs e)
        {
            string posicion = txtcedula.Text;
            posicion = posicion.Replace("-", "");

            if (posicion.Length > 11)
            {
                posicion = posicion.Substring(0, 11);
            }

            if (posicion.Length > 3)
            {
                posicion = posicion.Insert(3, "-");
            }

            if (posicion.Length > 11)
            {
                posicion = posicion.Insert(11, "-");
            }

            txtcedula.Text = posicion;
            txtcedula.SelectionStart = txtcedula.Text.Length;
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            txtcedula.Focus();
            EmpleadoID = 0;
            PersonaID = 0;

            if (numeroEmpleado.ColumnCount == 0)
            {
                numeroEmpleado.Columns.Add("nombre", "Etiqueta");
                numeroEmpleado.Columns.Add("numero", "Número");
                numeroEmpleado.Columns.Add("principal", "Principal");
            }

            if (direccionEmpleado.ColumnCount == 0)
            {
                direccionEmpleado.Columns.Add("nombre", "Etiqueta");
                direccionEmpleado.Columns.Add("direccion", "Dirección");
                direccionEmpleado.Columns.Add("principal", "Principal");
            }
        }

        private void puestoconsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idconsultatxt.Text = puestoconsulta.SelectedCells[0].Value.ToString();
            puestoconsultatxt.Text = puestoconsulta.SelectedCells[1].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            idpuestotxt.Text = idconsultatxt.Text;
            puestotxt.Text = puestoconsultatxt.Text;
            buscarpuesto_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            limpiarbtn_Click(sender, e);
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            txtcedula.Clear();
            txtnombre.Clear();
            txtapellido.Clear();
            emailtxt.Clear();
            txtsueldo.Clear();
            idpuestotxt.Clear();
            puestotxt.Clear();
            fechaingreso.Value = DateTime.Now;
            tiposueldocmbx.SelectedIndex = -1;
            rolcmbx.SelectedIndex = -1;
            estadochk.Checked = true;
            numeroEmpleado.Rows.Clear();
            direccionEmpleado.Rows.Clear();
        }

        private void seleccionimagenbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Seleccionar imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string idCliente = idUltimoEmpleado.Text;
                    string destinoCarpeta = @"C:\SistemaArchivos\Empleados\";
                    string extension = Path.GetExtension(openFileDialog.FileName);
                    string nuevaRuta = Path.Combine(destinoCarpeta, idCliente + extension);

                    try
                    {
                        imagenempleado.Image = Proyecto_restaurante.Properties.Resources.perfilcliente;

                        if (File.Exists(nuevaRuta))
                        {
                            string tempFileName = Path.Combine(destinoCarpeta, Path.GetRandomFileName());
                            File.Move(nuevaRuta, tempFileName);

                            File.Delete(tempFileName);
                        }

                        File.Copy(openFileDialog.FileName, nuevaRuta, true);

                        imagenempleado.Image = Image.FromFile(nuevaRuta);

                        MessageBox.Show("Imagen asociada al producto con éxito.");
                        limpiarbtn.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al copiar la imagen: " + ex.Message);
                    }
                }
            }
        }

        private void tabladatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tabladatos.Rows[e.RowIndex];
                int idEmpleado = Convert.ToInt32(fila.Cells["IdEmpleado"].Value);

                string rutaImagenes = @"C:\SistemaArchivos\Empleados\";
                string rutaImagenCliente = Path.Combine(rutaImagenes, idEmpleado + ".jpg");

                if (File.Exists(rutaImagenCliente))
                {
                    empleadoimg.Image = Image.FromFile(rutaImagenCliente);
                }
                else
                {
                    empleadoimg.Image = Proyecto_restaurante.Properties.Resources.perfilcliente;
                }
            }
        }

        private void bajarTelefono_Click(object sender, EventArgs e)
        {
            if (nombrenumerotxt.Text == "" || numerotxt.Text == "")
            {
                MessageBox.Show("Campos Vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(numeroEmpleado);

            row.Cells[0].Value = nombrenumerotxt.Text;
            row.Cells[1].Value = numerotxt.Text;
            row.Cells[2].Value = numPrincipalcmbx.Checked;

            numeroEmpleado.Rows.Add(row);

            if (TelActivado == 1)
            {
                numPrincipalcmbx.Checked = false;
                numPrincipalcmbx.Enabled = false;
            }

            nombrenumerotxt.Clear();
            numerotxt.Clear();
            numPrincipalcmbx.Checked = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (numeroEmpleado.SelectedRows.Count > 0)
            {
                int fila = numeroEmpleado.SelectedRows[0].Index;
                numeroEmpleado.Rows.RemoveAt(fila);
                EliminarNum = 0;

                if(numeroEmpleado.Rows.Count == 0)
                {
                    TelActivado = 0;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (direccionEmpleado.SelectedRows.Count > 0)
            {
                int fila = direccionEmpleado.SelectedRows[0].Index;
                direccionEmpleado.Rows.RemoveAt(fila);
                EliminarDir = 0;

                if(direccionEmpleado.Rows.Count == 0)
                {
                    DirActivado = 0;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void numeroEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EliminarNum = 1;
        }

        private void direccionEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EliminarDir = 1;
        }

        private void ConsEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && EliminarNum == 1 && e.KeyCode == Keys.Delete)
            {
                button6.PerformClick();
            }

            if (tabControl1.SelectedIndex == 1 && EliminarDir == 1 && e.KeyCode == Keys.Delete)
            {
                button7.PerformClick();
            }
        }

        private void recargarbtn_Click(object sender, EventArgs e)
        {
            ConsEmpleados_Load(sender, e);
        }

        private void eliminarbtn_Click(object sender, EventArgs e)
        {
            txtbuscador.Clear();
            filtro.Checked = true;
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (tabladatos.SelectedRows.Count > 0)
            {
                int idEmpleado = Convert.ToInt32(tabladatos.SelectedRows[0].Cells["IdEmpleado"].Value);

                EditarEmpleado = 1;

                CargarDatosEmpleado(idEmpleado);

                tabControl1.SelectedIndex = 1;

                txtcedula.Focus();
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarDatosEmpleado(int idEmpleado)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();

                string query = @"
                SELECT 
                    e.IdEmpleado,
                    e.IdPersona,
                    p.Nombre,
                    p.Apellido,
                    p.Email,
                    p.Activo
                FROM Empleado e
                INNER JOIN Persona p ON e.IdPersona = p.IdPersona
                WHERE e.IdEmpleado = @IdEmpleado";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    MessageBox.Show("Empleado no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                EmpleadoID = idEmpleado;
                PersonaID = Convert.ToInt32(dr["IdPersona"]);

                txtnombre.Text = dr["Nombre"].ToString();
                txtapellido.Text = dr["Apellido"].ToString();
                emailtxt.Text = dr["Email"].ToString();
                estadochk.Checked = Convert.ToBoolean(dr["Activo"]);

                dr.Close();

                string queryDoc = @"
                SELECT Numero 
                FROM PersonaDocumento
                WHERE IdPersona = @IdPersona AND EsPrincipal = 1";

                SqlCommand cmdDoc = new SqlCommand(queryDoc, conexion);
                cmdDoc.Parameters.AddWithValue("@IdPersona", PersonaID);

                object numeroDoc = cmdDoc.ExecuteScalar();
                txtcedula.Text = numeroDoc?.ToString() ?? "";

                numeroEmpleado.Rows.Clear();

                string queryTels = @"
                SELECT NombreTelefono, Numero, EsPrincipal
                FROM PersonaTelefono
                WHERE IdPersona = @IdPersona";

                SqlCommand cmdTels = new SqlCommand(queryTels, conexion);
                cmdTels.Parameters.AddWithValue("@IdPersona", PersonaID);

                SqlDataReader drTels = cmdTels.ExecuteReader();

                while (drTels.Read())
                {
                    numeroEmpleado.Rows.Add(
                        drTels["NombreTelefono"].ToString(),
                        drTels["Numero"].ToString(),
                        Convert.ToBoolean(drTels["EsPrincipal"])
                    );
                }

                drTels.Close();

                direccionEmpleado.Rows.Clear();

                string queryDire = @"
                SELECT Nombre, Direccion, EsPrincipal
                FROM PersonaDireccion
                WHERE IdPersona = @IdPersona";

                SqlCommand cmdDire = new SqlCommand(queryDire, conexion);
                cmdDire.Parameters.AddWithValue("@IdPersona", PersonaID);

                SqlDataReader drDir = cmdDire.ExecuteReader();

                while (drDir.Read())
                {
                    direccionEmpleado.Rows.Add(
                        drDir["Nombre"].ToString(),
                        drDir["Direccion"].ToString(),
                        Convert.ToBoolean(drDir["EsPrincipal"])
                    );
                }

                idUltimoEmpleado.Text = idEmpleado.ToString();

                drDir.Close();
            }
        }

        private void bajarDireccion_Click(object sender, EventArgs e)
        {
            if (nombredirecciontxt.Text == "" || direcciontxt.Text == "")
            {
                MessageBox.Show("Campos Vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(direccionEmpleado);

            row.Cells[0].Value = nombredirecciontxt.Text;
            row.Cells[1].Value = direcciontxt.Text;
            row.Cells[2].Value = principalDireccion.Checked;

            direccionEmpleado.Rows.Add(row);

            if (DirActivado == 1)
            {
                principalDireccion.Checked = false;
                principalDireccion.Enabled = false;
            }

            nombredirecciontxt.Clear();
            direcciontxt.Clear();
            principalDireccion.Checked = false;
        }
    }
}
