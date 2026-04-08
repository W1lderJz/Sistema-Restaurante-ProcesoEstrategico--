using PdfSharp.Pdf.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_restaurante
{
    public partial class ConsClientes : Form
    {
        public ConsClientes()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        public int ClienteID;
        public int PersonaID;
        public int EditarCliente = 0;
        public int DirActivado = 0;
        public int TelActivado = 0;
        public int EliminarNum = 0;
        public int EliminarDir = 0;

        string conexionString = ConexionBD.ConexionSQL();

        private System.Windows.Forms.ToolTip toolTip1;

        private void ConsultaClientes_Load(object sender, EventArgs e)
        {
            toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(recargarbtn, "Recargar");
            toolTip1.SetToolTip(filtrochk, "Estado");
            toolTip1.SetToolTip(eliminarbtn, "Limpiar filtros");

            string consultaId = "SELECT ISNULL(MAX(IdCliente), 0) + 1 FROM Cliente";

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(consultaId, con))
                {
                    idclientetxt.Text = cmd.ExecuteScalar()?.ToString() ?? "1";
                }
            }

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();

                string consultaTipoDoc = "SELECT IdTipoDocumento, Nombre FROM TipoDocumento";

                SqlDataAdapter da = new SqlDataAdapter(consultaTipoDoc, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                tipodoccmbx.DataSource = null;
                tipodoccmbx.DataSource = dt;
                tipodoccmbx.DisplayMember = "Nombre";
                tipodoccmbx.ValueMember = "IdTipoDocumento";

                if (dt.Rows.Count > 0)
                    tipodoccmbx.SelectedIndex = 0;
            }

            try
            {
                string consultaCliente = @"
                SELECT 
                    e.IdCliente,
                    p.NombreCompleto,
                    pd.Numero AS Cedula
                FROM Cliente e
                LEFT JOIN Persona p ON e.IdPersona = p.IdPersona
                LEFT JOIN PersonaDocumento pd ON p.IdPersona = pd.IdPersona
                WHERE e.Activo = 1 AND p.Activo = 1 and IdCliente > 1;";

                using (SqlDataAdapter adaptador = new SqlDataAdapter(consultaCliente, conexionString))
                {
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    tabladatos.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los datos: {ex.Message}");
            }

            if (telefonocliente.ColumnCount == 0)
            {
                telefonocliente.Columns.Add("nombre", "Etiqueta");
                telefonocliente.Columns.Add("numero", "Número");
                telefonocliente.Columns.Add("principal", "Principal");
            }

            if (direccioncliente.ColumnCount == 0)
            {
                direccioncliente.Columns.Add("nombre", "Etiqueta");
                direccioncliente.Columns.Add("direccion", "Dirección");
                direccioncliente.Columns.Add("principal", "Principal");
            }
        }

        private void eliminarbtn_Click(object sender, EventArgs e)
        {
            txtbuscador.Text = string.Empty;
            ConsultaClientes_Load(sender, e);
        }

        private void txtbuscador_TextChanged(object sender, EventArgs e)
        {
            //FiltroDatosBusqueda(txtbuscador.Text);
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            EditarCliente = 0;
            tabControl1.SelectedIndex = 1;
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            Regex letrasRegex = new Regex(@"^[a-zA-Z\s]+$");
            Regex numerosRegex = new Regex(@"^[\d-]+$");

            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("Nombre Obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!letrasRegex.IsMatch(txtnombre.Text))
            {
                MessageBox.Show("El nombre solo debe contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!letrasRegex.IsMatch(txtapellido.Text))
            {
                MessageBox.Show("El apellido solo debe contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                SqlTransaction trans = conexion.BeginTransaction();

                try
                {
                    if (EditarCliente == 0)
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

                        string nuevoCliente = @"
                        INSERT INTO Cliente (IdPersona, IdTipoDoc)
                        VALUES (@IdPersona, @IdTipoDoc);
                        SELECT SCOPE_IDENTITY();";

                        using (SqlCommand insertarCliente = new SqlCommand(nuevoCliente, conexion, trans))
                        {
                            insertarCliente.Parameters.AddWithValue("@IdPersona", PersonaID);
                            insertarCliente.Parameters.AddWithValue("@IdTipoDoc", Convert.ToInt32(tipodoccmbx.SelectedValue));

                            ClienteID = Convert.ToInt32(insertarCliente.ExecuteScalar());
                        }

                        string nuevoDoc = @"
                        INSERT INTO PersonaDocumento (IdPersona, IdTipoDocumento, Numero, EsPrincipal)
                        VALUES (@IdPersona, @IdTipoDoc, @Numero, 1)";

                        using (SqlCommand insertarDocumento = new SqlCommand(nuevoDoc, conexion, trans))
                        {
                            insertarDocumento.Parameters.AddWithValue("@IdPersona", PersonaID);
                            insertarDocumento.Parameters.AddWithValue("@IdTipoDoc", Convert.ToInt32(tipodoccmbx.SelectedValue));
                            insertarDocumento.Parameters.AddWithValue("@Numero", identtxt.Text);

                            insertarDocumento.ExecuteNonQuery();
                        }

                        foreach (DataGridViewRow fila in telefonocliente.Rows)
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

                        foreach (DataGridViewRow fila in direccioncliente.Rows)
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
                        MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (EditarCliente == 1)
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

                        string actualizarCliente = @"
                        UPDATE Cliente
                        SET IdTipoDoc = @IdTipoDoc
                        WHERE IdCliente = @IdCliente";

                        using (SqlCommand actualizarClienteCmd = new SqlCommand(actualizarCliente, conexion, trans))
                        {
                            actualizarClienteCmd.Parameters.AddWithValue("@IdCliente", ClienteID);
                            actualizarClienteCmd.Parameters.AddWithValue("@IdTipoDoc", Convert.ToInt32(tipodoccmbx.SelectedValue));
                            actualizarClienteCmd.ExecuteNonQuery();
                        }

                        string actualizarDoc = @"
                        UPDATE PersonaDocumento
                        SET Numero = @Numero
                        WHERE IdPersona = @IdPersona AND EsPrincipal = 1";

                        using (SqlCommand cmdDoc = new SqlCommand(actualizarDoc, conexion, trans))
                        {
                            cmdDoc.Parameters.AddWithValue("@IdPersona", PersonaID);
                            cmdDoc.Parameters.AddWithValue("@Numero", identtxt.Text);
                            cmdDoc.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Cliente actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    RestablecerFormulario();
                    ConsultaClientes_Load(sender, e);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RestablecerFormulario()
        {
            imagencliente.Image = Proyecto_restaurante.Properties.Resources.perfilcliente;
            txtnombre.Clear();
            identtxt.Clear();
            tipodoccmbx.SelectedIndex = -1;

            txtapellido.Clear();

            ClienteID = 0;
            PersonaID = 0;

            emailtxt.Text = "";
            telefonocliente.Rows.Clear();
            direccioncliente.Rows.Clear();

            numerotxt.Clear();
            nombredirecciontxt.Clear();
            direcciontxt.Clear();
            nombrenumerotxt.Clear();

            estadochk.Checked = true;
            identtxt.Focus();
            direccioncliente.Rows.Clear();
            telefonocliente.Rows.Clear();
        }

        private void limpiarbtn_Click(object sender, EventArgs e)
        {
            RestablecerFormulario();
            ConsultaClientes_Load(sender, e);
        }

        private void txtnumero_TextChanged(object sender, EventArgs e)
        {
            string posNum = numerotxt.Text;
            posNum = posNum.Replace("-", "");

            if (posNum.Length > 10)
            {
                posNum = posNum.Substring(0, 10);
            }

            if (posNum.Length > 3)
            {
                posNum = posNum.Insert(3, "-");
            }

            if (posNum.Length > 7)
            {
                posNum = posNum.Insert(7, "-");
            }

            numerotxt.Text = posNum;
            numerotxt.SelectionStart = numerotxt.Text.Length;
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtapellido.Focus();
                e.Handled = true;
            }
        }

        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tipodoccmbx.Focus();
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaClientes_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            RestablecerFormulario();
        }

        private void seleccionimagenbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Seleccionar imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string codigoCliente = idclientetxt.Text;
                    string destinoCarpeta = @"C:\SistemaArchivos\Clientes";
                    string extension = Path.GetExtension(openFileDialog.FileName);
                    string nuevaRuta = Path.Combine(destinoCarpeta, codigoCliente + extension);

                    try
                    {
                        imagencliente.Image = null;

                        if (File.Exists(nuevaRuta))
                        {
                            string tempFileName = Path.Combine(destinoCarpeta, Path.GetRandomFileName());
                            File.Move(nuevaRuta, tempFileName);

                            File.Delete(tempFileName);
                        }

                        File.Copy(openFileDialog.FileName, nuevaRuta, true);

                        imagencliente.Image = Image.FromFile(nuevaRuta);

                        MessageBox.Show("Imagen asociada al cliente con éxito.");
                        identtxt.Enabled = false;

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
                int idCliente = Convert.ToInt32(fila.Cells["IdCliente"].Value);

                string rutaImagenes = @"C:\SistemaArchivos\Clientes\";
                string rutaImagenCliente = Path.Combine(rutaImagenes, idCliente + ".jpg");

                if (File.Exists(rutaImagenCliente))
                {
                    clienteimg.Image = Image.FromFile(rutaImagenCliente);
                }
                else
                {
                    clienteimg.Image = Proyecto_restaurante.Properties.Resources.perfilcliente;
                }
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (tabladatos.SelectedRows.Count > 0)
            {
                int idCliente = Convert.ToInt32(tabladatos.SelectedRows[0].Cells["IdCliente"].Value);

                EditarCliente = 1;

                CargarDatosCliente(idCliente);

                tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarDatosCliente(int idCliente)
        {

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();

                string query = @"
                SELECT 
                    c.IdCliente,
                    c.IdPersona,
                    c.IdTipoDoc,
                    p.Nombre,
                    p.Apellido,
                    p.Email,
                    p.Activo
                FROM Cliente c
                INNER JOIN Persona p ON c.IdPersona = p.IdPersona
                WHERE c.IdCliente = @IdCliente";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ClienteID = idCliente;
                PersonaID = Convert.ToInt32(dr["IdPersona"]);

                txtnombre.Text = dr["Nombre"].ToString();
                txtapellido.Text = dr["Apellido"].ToString();
                emailtxt.Text = dr["Email"].ToString();
                estadochk.Checked = Convert.ToBoolean(dr["Activo"]);

                tipodoccmbx.SelectedValue = Convert.ToInt32(dr["IdTipoDoc"]);

                dr.Close();

                string queryDoc = @"
                SELECT Numero 
                FROM PersonaDocumento
                WHERE IdPersona = @IdPersona AND EsPrincipal = 1";

                SqlCommand cmdDoc = new SqlCommand(queryDoc, conexion);
                cmdDoc.Parameters.AddWithValue("@IdPersona", PersonaID);

                object numeroDoc = cmdDoc.ExecuteScalar();
                identtxt.Text = numeroDoc?.ToString() ?? "";

                telefonocliente.Rows.Clear();

                string queryTels = @"
                SELECT NombreTelefono, Numero, EsPrincipal
                FROM PersonaTelefono
                WHERE IdPersona = @IdPersona";

                SqlCommand cmdTels = new SqlCommand(queryTels, conexion);
                cmdTels.Parameters.AddWithValue("@IdPersona", PersonaID);

                SqlDataReader drTels = cmdTels.ExecuteReader();

                while (drTels.Read())
                {
                    telefonocliente.Rows.Add(
                        drTels["NombreTelefono"].ToString(),
                        drTels["Numero"].ToString(),
                        Convert.ToBoolean(drTels["EsPrincipal"])
                    );
                }

                drTels.Close();

                direccioncliente.Rows.Clear();

                string queryDire = @"
                SELECT Nombre, Direccion, EsPrincipal
                FROM PersonaDireccion
                WHERE IdPersona = @IdPersona";

                SqlCommand cmdDire = new SqlCommand(queryDire, conexion);
                cmdDire.Parameters.AddWithValue("@IdPersona", PersonaID);

                SqlDataReader drDir = cmdDire.ExecuteReader();

                while (drDir.Read())
                {
                    direccioncliente.Rows.Add(
                        drDir["Nombre"].ToString(),
                        drDir["Direccion"].ToString(),
                        Convert.ToBoolean(drDir["EsPrincipal"])
                    );
                }

                idclientetxt.Text = idCliente.ToString();

                drDir.Close();
            }
        }

        private void filtro_CheckedChanged(object sender, EventArgs e)
        {
            if (filtrochk.Checked)
            {
                ConsultaClientes_Load(sender, e);
                filtrochk.Image = Proyecto_restaurante.Properties.Resources.sicheck;
            }
            else
            {
                ConsultaClientes_Load(sender, e);
                filtrochk.Image = Proyecto_restaurante.Properties.Resources.nocheck;
            }
        }

        private void estadochk_CheckedChanged(object sender, EventArgs e)
        {
            if (estadochk.Checked == true)
            {
                estadochk.Text = "Activo";
                estadochk.ForeColor = Color.Lime;
            }
            else if (estadochk.Checked == false)
            {

                estadochk.Text = "Inactivo";
                estadochk.ForeColor = Color.Red;
            }
        }

        private void identtxt_TextChanged(object sender, EventArgs e)
        {
            if (tipodoccmbx.SelectedIndex == 0)
            {
                string posicion = identtxt.Text; posicion = posicion.Replace("-", "");

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

                identtxt.Text = posicion; identtxt.SelectionStart = identtxt.Text.Length;
            }
            else if (tipodoccmbx.SelectedIndex == 1)
            {
                string posicion = identtxt.Text; posicion = posicion.Replace("-", "");
                if (posicion.Length > 11)
                {
                    posicion = posicion.Substring(0, 11);
                }
                if (posicion.Length > 3)
                {
                    posicion = posicion.Insert(3, "-");
                }

                identtxt.Text = posicion; identtxt.SelectionStart = identtxt.Text.Length;
            }
        }

        private void tipodoccmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            identtxt_TextChanged(null, null);
            identtxt.Clear();
        }

        private void bajarTelefono_Click(object sender, EventArgs e)
        {
            if (nombrenumerotxt.Text == "" || numerotxt.Text == "")
            {
                MessageBox.Show("Campos Vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(telefonocliente);

            row.Cells[0].Value = nombrenumerotxt.Text;
            row.Cells[1].Value = numerotxt.Text;
            row.Cells[2].Value = numPrincipalcmbx.Checked;

            telefonocliente.Rows.Add(row);

            if (TelActivado == 1)
            {
                numPrincipalcmbx.Checked = false;
                numPrincipalcmbx.Enabled = false;
            }

            nombrenumerotxt.Clear();
            numerotxt.Clear();
            numPrincipalcmbx.Checked = false;

            if(numPrincipalcmbx.Enabled == false)
            {
                TelActivado = 0;
            }
        }

        private void bajardireccion_Click(object sender, EventArgs e)
        {
            if (nombredirecciontxt.Text == "" || direcciontxt.Text == "")
            {
                MessageBox.Show("Campos Vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(direccioncliente);

            row.Cells[0].Value = nombredirecciontxt.Text;
            row.Cells[1].Value = direcciontxt.Text;
            row.Cells[2].Value = principalDireccion.Checked;

            direccioncliente.Rows.Add(row);

            if (DirActivado == 1)
            {
                principalDireccion.Checked = false;
                principalDireccion.Enabled = false;
            }
            else
            {
                principalDireccion.Checked = false;
                principalDireccion.Enabled = true;
            }

            nombredirecciontxt.Clear();
            direcciontxt.Clear();
            principalDireccion.Checked = false; 

            if (principalDireccion.Enabled == false)
            {
                DirActivado = 0;
            }
        }

        private void numPrincipalcmbx_CheckedChanged(object sender, EventArgs e)
        {
            if (numPrincipalcmbx.Checked == true)
            {
                TelActivado = 1;
            }
        }

        private void principalDireccion_CheckedChanged(object sender, EventArgs e)
        {
            if (principalDireccion.Checked == true)
            {
                DirActivado = 1;
            }
        }

        private void eliminarNumero_Click(object sender, EventArgs e)
        {
            if (telefonocliente.SelectedRows.Count > 0)
            {
                int fila = telefonocliente.SelectedRows[0].Index;
                telefonocliente.Rows.RemoveAt(fila);
                EliminarNum = 0;

                if(telefonocliente.Rows.Count == 0)
                {
                    TelActivado = 0;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void eliminarDireccion_Click(object sender, EventArgs e)
        {
            if (direccioncliente.SelectedRows.Count > 0)
            {
                int fila = direccioncliente.SelectedRows[0].Index;
                direccioncliente.Rows.RemoveAt(fila);
                EliminarDir = 0;

                if (direccioncliente.Rows.Count == 0)
                {
                    DirActivado = 0;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void telefonocliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EliminarNum = 1;
        }

        private void direccioncliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EliminarDir = 1;
        }

        private void ConsClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && EliminarNum == 1 && e.KeyCode == Keys.Delete)
            {
                eliminarNumero.PerformClick();
            }

            if (tabControl1.SelectedIndex == 1 && EliminarDir == 1 && e.KeyCode == Keys.Delete)
            {
                eliminarDireccion.PerformClick();
            }
        }

        private void identtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BuscarRNC();
            }
        }

        private void BuscarRNC()
        {
            if (tipodoccmbx.SelectedIndex != 1)
                return;

            string archivoDGII = @"C:\SistemaArchivos\DGIITXT\DGII_RNC.TXT";

            if (!File.Exists(archivoDGII))
            {
                MessageBox.Show("No se encontró el archivo DGII_RNC.TXT", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string rncBuscado = identtxt.Text.Replace("-", "").Trim();

            if (rncBuscado.Length == 0)
                return;

            try
            {
                using (StreamReader sr = new StreamReader(archivoDGII))
                {
                    string linea;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        if (linea.StartsWith(rncBuscado + "|"))
                        {
                            string[] partes = linea.Split('|');

                            if (partes.Length < 3)
                                continue;

                            string nombre = partes[1].Trim();
                            string estado = partes[partes.Length - 2].Trim().ToUpper();
                            
                            if (estado == "ACTIVO")
                            {
                                txtnombre.Text = nombre;
                                return;
                            }
                            else
                            {
                                MessageBox.Show("RNC Suspendido.", "Información",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }

                MessageBox.Show("RNC no encontrado en el archivo DGII.", "No encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error leyendo archivo: " + ex.Message);
            }
        }
    }
}
